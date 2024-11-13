namespace WebAPIHotelsBooking.BusinessLogic.Memento
{
    public interface IMemento<T>
    {
        public T GetState();
        public DateTime GetDate();
    }
}
