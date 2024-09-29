using UnityEngine;

namespace BaseX.Utils
{
    public static class DataUtil 
    {
        public static void ClearAllData()
        {
            PlayerPrefs.Save();
            
            Debug.Log("Data deleted successfully!");
        }
    }
}