// Copyright by GearEight Games © 2019
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu()]
    public class TrackedEvent : ScriptableObject
    {
        #region Private Fields

        [SerializeField]
        private string identifier;

        #endregion Private Fields

        #region Public Delegates

        public delegate void TrackedEventHandler(TrackedEvent trackedEvent, int value);

        #endregion Public Delegates

        #region Public Events

        public event TrackedEventHandler Add;

        public event TrackedEventHandler Set;

        #endregion Public Events

        #region Public Properties

        public string Identifier
        {
            get { return identifier; }
        }

        #endregion Public Properties

        #region Public Methods

        public void AddValue(int value)
        {
            Add?.Invoke(this, value);
        }

        public void SetValue(int value)
        {
            Set?.Invoke(this, value);
        }

        #endregion Public Methods
    }
}