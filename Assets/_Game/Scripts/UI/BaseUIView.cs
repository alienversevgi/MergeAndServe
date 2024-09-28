using UnityEngine;
using Zenject;

namespace MergeAndServe.UI
{
    public class BaseUIView : MonoBehaviour
    {
        [Inject] protected SignalBus SignalBus;
    }
}