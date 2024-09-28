using Newtonsoft.Json;
using MergeAndServe.Data;
using MergeAndServe.Settings;
using UnityEngine;
using Zenject;

namespace MergeAndServe.Game
{
    public class DataManager : MonoBehaviour
    {
        #region Fields

        [field: SerializeField]
        public GridData GridData { get; set; }

        public TaskData TaskData  { get; set; }

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
            SaveData(Const.DataPrefKey.GRID_DATA, GridData);
        }

        private void LoadAllData()
        {
            GridData = LoadData(Const.DataPrefKey.GRID_DATA, _gameSettings.StarterGrid);
            TaskData = LoadData(Const.DataPrefKey.TASK_DATA, _gameSettings.StarterTaskData);
        }

        private T LoadData<T>(string key, T defaultData) where T : ScriptableObject
        {
            string json = PlayerPrefs.GetString(key, string.Empty);
            T data = ScriptableObject.CreateInstance<T>();

            if (string.IsNullOrEmpty(json))
            {
                data = Instantiate(defaultData);
            }
            else
            {
                JsonUtility.FromJsonOverwrite(json, data);
            }

            return data;
        }

        private void SaveData<T>(string key, T data) where T : ScriptableObject
        {
            string json = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(key, json);
            Debug.Log($"Save {key} : " + json);
        }

        #endregion
    }
}