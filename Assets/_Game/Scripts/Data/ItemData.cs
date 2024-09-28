using UnityEngine;

namespace MergeAndServe.Data
{
    public class ItemData : ScriptableObject
    {
        public Enums.ItemType Type;
        public int CollectionId;
        public int Level;

        public string ShortCode => $"{Type}_{CollectionId}_{Level}";
    }
}