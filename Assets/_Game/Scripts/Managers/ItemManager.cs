using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using MergeAndServe.Data;
using MergeAndServe.Enums;
using MergeAndServe.Services;
using Zenject;

namespace MergeAndServe.Game
{
    public class ItemManager
    {
        #region Fields

        [Inject] private OGAddressableService _addressableService;

        private Dictionary<string, List<ItemData>> _collections;
        private Dictionary<string, ItemData> _items;
        private Dictionary<string, ItemData> _products;
        private Dictionary<string, ItemData> _generator;

        #endregion

        #region Public Methods

        public async UniTask Initialize(List<string> collections)
        {
            _collections = new Dictionary<string, List<ItemData>>();
            _items = new Dictionary<string, ItemData>();
            _products = new Dictionary<string, ItemData>();
            _generator = new Dictionary<string, ItemData>();

            for (int i = 0; i < collections.Count; i++)
            {
                var collection = await _addressableService.LoadItemCollectionData(collections[i]);
                List<ItemData> items = new List<ItemData>();
                for (int j = 0; j < collection.Items.Count; j++)
                {
                    var item = collection.Items[j];
                    items.Add(item);

                    if (item.Type == ItemType.Generator)
                        _generator.Add(item.ShortCode, item);
                    else if (item.Type == ItemType.Product)
                        _products.Add(item.ShortCode, item);

                    _items.Add(item.ShortCode, item);
                }

                _collections.Add(collection.ShortCode, items);
            }
        }

        public ItemData GetNextItemData(string itemShortCode)
        {
            ItemData result = null;
            var collectionShortCode = GetCollectionShortCodeByItemShortCode(itemShortCode);
            var itemData = GetItemData(itemShortCode);
            var collection = _collections[collectionShortCode];
            int index = itemData.Level;

            if (index < collection.Count)
            {
                result = collection[index];
            }

            return result;
        }

        public ItemData GetItemData(string shortCode)
        {
            return _items[shortCode];
        }

        public ItemData GetRandomProductData()
        {
            int index = UnityEngine.Random.Range(0, _products.Count);
            return _items.ElementAt(index).Value;
        }

        public (Enums.ItemType type, int collectionId, int level) GetItemInfoByShortCode(string shortCode)
        {
            string[] components = shortCode.Split('_');

            Enums.ItemType type = (Enums.ItemType)Enum.Parse(typeof(Enums.ItemType), components[0]);
            int collectionId = int.Parse(components[1]);
            int level = int.Parse(components[2]);

            return (type, collectionId, level);
        }

        public string GetCollectionShortCodeByItemShortCode(string shortCode)
        {
            var itemInfo = GetItemInfoByShortCode(shortCode);
            return $"{itemInfo.type}_{itemInfo.collectionId}";
        }

        #endregion
    }
}