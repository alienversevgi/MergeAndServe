using System.Collections.Generic;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(OrderData), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(OrderData))]
    public class OrderData : ScriptableObject
    {
        public int Id;
        public List<string> Items;
    }
}