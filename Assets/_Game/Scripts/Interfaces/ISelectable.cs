namespace MergeAndServe.Interfaces
{
    public interface ISelectable
    {
        void Select();
        void SelectionCompleted();
        void Deselect();
    }
}