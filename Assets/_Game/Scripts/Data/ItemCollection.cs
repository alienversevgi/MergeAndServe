using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MergeAndServe.Data
{
    [CreateAssetMenu(fileName = nameof(ItemCollection), menuName = Const.SOPath.SO_DATA_MENU_PATH + nameof(ItemCollection))]
    public class ItemCollection : ScriptableObject
    {
        public string ShortCode;
        public List<AssetReference> Items;
    }
}