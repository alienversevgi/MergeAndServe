using BaseX.Scripts;
using MergeAndServe.Data;
using MergeAndServe.Settings;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Game
{
    public class DataManager : MonoBehaviour
    {
        #region Fields

        [field: SerializeField] public GridData GridData { get; set; }
        [field: SerializeField] public TaskData TaskData { get; set; }

        [Inject] private GameSettings _gameSettings;

        #endregion

        #region Unity Methods

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                SaveAllData();
            }
        }

        private void OnApplicationQuit()
        {
            SaveAllData();
        }

        #endregion

        #region Public Methods

        public void Initialize()
        {

            LoadAllData();
        }

        #endregion

        #region Private Methods

        private void SaveAllData()
        {
            DataHandler.SaveData(GridData, nameof(GridData));
            DataHandler.SaveData(TaskData, nameof(TaskData));
        }

        private void LoadAllData()
        {
            GridData = ScriptableObject.CreateInstance<GridData>();
            TaskData = ScriptableObject.CreateInstance<TaskData>();
            DataHandler.LoadData(GridData, nameof(GridData), _gameSettings.StarterGrid);
            DataHandler.LoadData(TaskData, nameof(TaskData), _gameSettings.StarterTaskData);
        }

        #endregion
    }
}