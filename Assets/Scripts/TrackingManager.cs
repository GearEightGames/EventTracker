// Copyright by GearEight Games © 2019
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu]
    public class TrackingManager : ScriptableObject
    {
        #region Private Fields

        [SerializeField]
        private string savefile;

        [SerializeField]
        private char separator;

        [SerializeField]
        private TrackedEvent[] trackedEvents;

        private Dictionary<string, int> trackedValues;

        public void DumpData()
        {
            foreach (var entry in trackedValues)
            {
                Debug.Log($"{entry.Key}: {entry.Value}");
            }
        }

        #endregion Private Fields

        #region Public Methods

        public void Init()
        {
            trackedValues = new Dictionary<string, int>();
            for (int i = 0; i < trackedEvents.Length; i++)
            {
                trackedEvents[i].Add += ValueAdded;
                trackedEvents[i].Set += ValueSet;
                if (trackedValues.ContainsKey(trackedEvents[i].Identifier))
                    continue;

                trackedValues.Add(trackedEvents[i].Identifier, 0);
            }

            Load();
        }

        public void Shutdown()
        {
            for (int i = 0; i < trackedEvents.Length; i++)
            {
                trackedEvents[i].Add -= ValueAdded;
                trackedEvents[i].Set -= ValueSet;
            }

            Save();
        }

        #endregion Public Methods

        #region Private Methods

        private void Load()
        {
            if (!File.Exists(savefile))
                return;

            string[] lines = File.ReadAllLines(savefile);

            for (int i = 0; i < lines.Length; i++)
            {
                int splitPos = lines[i].LastIndexOf('~');
                string identifier = lines[i].Substring(0, splitPos).Trim();
                string valueAsText = lines[i].Substring(splitPos + 1).Trim();
                if (int.TryParse(valueAsText, out int value))
                {
                    if (!trackedValues.ContainsKey(identifier))
                        continue;
                    trackedValues[identifier] = value;
                }
            }
        }

        private void Save()
        {
            List<string> data = new List<string>(trackedValues.Count);
            foreach (var valueEntry in trackedValues)
            {
                data.Add(string.Join(separator.ToString(), valueEntry.Key, valueEntry.Value.ToString()));
            }

            if (File.Exists(savefile))
                File.Delete(savefile);
            File.WriteAllLines(savefile, data);
        }

        private void ValueAdded(TrackedEvent trackedEvent, int value)
        {
            trackedValues[trackedEvent.Identifier] += value;
        }

        private void ValueSet(TrackedEvent trackedEvent, int value)
        {
            trackedValues[trackedEvent.Identifier] = value;
        }

        #endregion Private Methods
    }
}