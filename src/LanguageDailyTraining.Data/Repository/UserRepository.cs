using LanguageDailyTraining.Data.Context;
using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using LanguageDailyTraining.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LanguageDailyTrainingContext context;

        public UserRepository(LanguageDailyTrainingContext context)
        {
            this.context = context;
        }

        public IUnitOfWork unitOfWork => context;

        public async Task<User> GetById(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(User user)
        {
            await context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
