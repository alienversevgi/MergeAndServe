using MergeAndServe.Data;
using Zenject;

namespace MergeAndServe.Game
{
    public class Product : BaseItem
    {
        #region Fields

        public ProductData Data { get; private set; }

        #endregion

        #region Public Methods

        public override void Initialize(ItemData itemData)
        {
            base.Initialize(itemData);
            Data = (ProductData)itemData;
        }

        #endregion
        
        public class Pool : MonoMemoryPool<Product>
        {
            protected override void OnCreated(Product item)
            {
                item.gameObject.name += $"_{NumTotal}";
                base.OnCreated(item);
            }
        }
    }
}
