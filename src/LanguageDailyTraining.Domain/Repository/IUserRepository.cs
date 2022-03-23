using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetById(Guid id);

        Task<IEnumerable<User>> GetAll();

        Task Add(User user);

        void Update(User user);

        void Delete(User user);
    }
}
