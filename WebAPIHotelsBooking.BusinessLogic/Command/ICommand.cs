using System.Windows.Input;
using WebAPIHotelsBooking.DataAccess.Entities;

namespace WebAPIHotelsBooking.BusinessLogic.Command
{
    public interface ICommand
    {
        public Task Execute();
        public Task Undo();
    }
}
