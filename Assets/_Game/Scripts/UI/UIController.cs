using Zenject;

namespace MergeAndServe.UI
{
    public class UIController : BaseUIView
    {
        [Inject] private TaskView _taskView;

        public void Initialize()
        {
            _taskView.Initialize();
        }
    }
}