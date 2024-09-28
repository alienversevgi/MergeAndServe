using UnityEngine;

namespace MergeAndServe.Interfaces
{
    public interface IDraggable
    {
        void Drag(Vector2 point);
        void Release();
    }
}