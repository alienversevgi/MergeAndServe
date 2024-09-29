using System.Collections.Generic;
using BaseX;
using Google.Protobuf.Collections;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(TaskData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(TaskData))]
    public class TaskData : ScriptableObject, IProtoData<ProtoTaskData>
    {
        public List<OrderData> Orders;

        public ProtoTaskData GetProtoData()
        {
            RepeatedField<ProtoOrderData> orders = new RepeatedField<ProtoOrderData>();
            for (int i = 0; i < Orders.Count; i++)
            {
                var protoData = Orders[i].GetProtoData();
                orders.Add(protoData);
            }

            return new ProtoTaskData()
            {
                Orders = { orders }
            };
        }

        public void SetProtoData(ProtoTaskData data)
        {
            Orders = new List<OrderData>();
            for (int i = 0; i < data.Orders.Count; i++)
            {
                var order = CreateInstance<OrderData>();
                order.SetProtoData(data.Orders[i]);
                Orders.Add(order);
            }
        }
    }
}