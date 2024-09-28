using System.Collections.Generic;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(TaskData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(TaskData))]
    public class TaskData : ScriptableObject
    {
        public List<OrderData> Orders;
    }
}