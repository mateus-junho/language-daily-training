﻿using LanguageDailyTraining.Data.Context;
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

        public IUnitOfWork unitOfWork => context;

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<User> GetById(Guid id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}