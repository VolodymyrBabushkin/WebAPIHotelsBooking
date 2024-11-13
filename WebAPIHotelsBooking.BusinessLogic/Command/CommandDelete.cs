using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;

namespace WebAPIHotelsBooking.BusinessLogic.Command
{
    public class CommandDelete<T> : ICommand where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly string _id;
        private T? _deleted;

        public CommandDelete(IRepository<T> repository, string id)
        {
            _repository = repository;
            _id = id;
        }

        public async Task Execute()
        {
            _deleted = await _repository.Get(_id);
            if (_deleted != null)
            {
                _deleted = (T)_deleted.Clone();
            }
            await _repository.Delete(_id);
        }

        public async Task Undo()
        {
            if (_deleted == null) return;
            await _repository.Create(_deleted);
            await _repository.Update(_deleted);
        }
    }
}