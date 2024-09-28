using UnityEngine;

namespace MergeAndServe.Scripts.Utils
{
    public static class DataUtil 
    {
        public static void ClearAllData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            
            Debug.Log("Data deleted successfully!");
        }
    }
}