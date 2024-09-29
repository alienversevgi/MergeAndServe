using BaseX;
using MergeAndServe.Enums;
using UnityEngine;

namespace MergeAndServe.Data
{
    [System.Serializable]
    public class CellData : IProtoData<ProtoCellData>
    {
        public Vector2Int Position;
        public Enums.CellType Type;
        public string ItemShortCode;

        public ProtoCellData GetProtoData()
        {
            return new ProtoCellData()
            {
                PositionX = Position.x,
                PositionY = Position.y,
                CellType = (int)Type,
                ItemShortCode = ItemShortCode
            };
        }

        public void SetProtoData(ProtoCellData data)
        {
            Position.x = data.PositionX;
            Position.y = data.PositionY;
            Type = (CellType)data.CellType;
            ItemShortCode = data.ItemShortCode;
        }
    }
}