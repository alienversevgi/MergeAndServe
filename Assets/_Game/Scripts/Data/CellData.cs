using UnityEngine;

namespace MergeAndServe.Data
{
    [System.Serializable]
    public class CellData
    {
        public Vector2Int Position;
        public Enums.CellType Type;
        public string ItemShortCode;
    }
}