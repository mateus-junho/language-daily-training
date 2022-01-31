using System;

namespace LanguageDailyTraining.Domain.Core
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork unitOfWork { get; }
    }
}
