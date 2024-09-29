using System.Collections.Generic;
using System.Linq;
using BaseX;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(OrderData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(OrderData))]
    public class OrderData : ScriptableObject, IProtoData<ProtoOrderData>
    {
        public int Id;
        public List<string> Items;

        public ProtoOrderData GetProtoData()
        {
            return new ProtoOrderData()
            {
                Id = Id,
                Items =
                {
                    Items.ToArray()
                }
            };
        }

        public void SetProtoData(ProtoOrderData data)
        {
            Id = data.Id;
            Items = data.Items.ToList();
        }
    }
}