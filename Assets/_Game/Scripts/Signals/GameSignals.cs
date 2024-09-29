using MergeAndServe.Data;
using MergeAndServe.Game;
using MergeAndServe.UI;

namespace MergeAndServe.Signals
{
    public static class GameSignals
    {
        public struct ItemDragReleased
        {
            public Cell Current;
            public Cell Triggered;
        }
        
        public struct MergeCompleted
        {
            public BaseItem Item;
        }
        
        public struct ItemProduced
        {
            public BaseItem Item;
        }
        
        public struct ItemDestroyed
        {
            public BaseItem Item;
        }
        
        public struct ItemMarked
        {
            public string OrderId;
            public string ItemShortCode { get; set; }
        }
        
        public struct ItemUnmarked
        {
            public string OrderId;
            public string ItemShortCode { get; set; }
        }

        public struct OrderItemsServed
        {
            public string Id;
        }
        
        public struct ServeRequested
        {
            public OrderData OrderData;
            public OrderView View;
        }

        public struct BoardFull
        {
        }

        public struct OrdersRefilled
        {
            
        }
    }
}