using System.Collections.Generic;
using MergeAndServe.Enums;
using UnityEngine;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(ItemCollection), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(ItemCollection))]
    public class ItemCollection : ScriptableObject
    {
        public int Id;
        public ItemType Type;
        public List<ItemData> Items;
        
        public string ShortCode => $"{Type}_{Id}";
    }
}