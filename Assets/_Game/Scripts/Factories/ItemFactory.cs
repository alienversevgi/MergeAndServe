using MergeAndServe.Data;
using MergeAndServe.Game;
using Zenject;

namespace MergeAndServe.Factorys
{
    public class ItemFactory
    {
        #region Fields

        [Inject] private Product.Pool _productPool;
        [Inject] private Generator.Pool _generatorPool;
        [Inject] private ItemManager _itemManager;

        #endregion

        #region Public Methods

        public BaseItem SpawnItem(string shortCode) 
        {
            var data = _itemManager.GetItemData(shortCode);
            BaseItem item = null;
            switch (data.Type)
            {
                case Enums.ItemType.Product:
                    item = _productPool.Spawn();
                    break;
                case Enums.ItemType.Generator:
                    item = _generatorPool.Spawn();
                    break;
            }

            item.Initialize(data);
            
            return item;
        }

        public void DisposeItem(BaseItem baseItem)
        {
            var itemInfo = _itemManager.GetItemInfoByShortCode(baseItem.BaseData.ShortCode);

            switch (itemInfo.type)
            {
                case Enums.ItemType.Product:
                    _productPool.Despawn((Product) baseItem);
                    break;
                case Enums.ItemType.Generator:
                    _generatorPool.Despawn((Generator) baseItem);
                    break;
            }
        }

        #endregion
    }
}