using WebAPIHotelsBooking.DataAccess.Entities;
using WebAPIHotelsBooking.DataAccess.Repositories;

namespace WebAPIHotelsBooking.BusinessLogic.Command
{
    public class CommandCreate<T> : ICommand where T : BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly BaseEntity _entity;

        public CommandCreate(IRepository<T> repository, BaseEntity entity)
        {
            _repository = repository;
            _entity = entity;
        }

        public Task Execute()
        {
            return _repository.Create((T)_entity);
        }

        public Task Undo()
        {
            return _repository.Delete(_entity.Id);
        }
    }
}
