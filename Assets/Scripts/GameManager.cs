// Copyright by GearEight Games © 2019
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Private Fields

        [SerializeField]
        private TrackingManager trackingManager;

        #endregion Private Fields

        #region Private Methods

        private void OnApplicationQuit()
        {
            trackingManager.DumpData();
            trackingManager.Shutdown();
        }

        private void Start()
        {
            trackingManager.Init();
        }

        #endregion Private Methods
    }
}