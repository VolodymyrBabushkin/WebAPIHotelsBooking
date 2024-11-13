using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;

namespace WebAPIHotelsBooking.BusinessLogic.Command
{
    public class CommandUpdate<T> : ICommand where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly BaseEntity _entity;
        private BaseEntity? _previous;

        public CommandUpdate(IRepository<T> repository, BaseEntity entity)
        {
            _repository = repository;
            _entity = entity;
        }

        public async Task Execute()
        {
            _previous = await _repository.Get(_entity.Id);
            if (_previous != null)
            {
                _previous = (T)_previous.Clone();
            }
            await _repository.Update((T)_entity);
        }

        public async Task Undo()
        {
            if (_previous == null) return;
            await _repository.Update((T)_previous);
        }
    }
}
