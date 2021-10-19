﻿using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.ValueObjects;
using System.Collections.Generic;

namespace LanguageDailyTraining.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }

        public IEnumerable<TrainingPlan> TrainingPlans { get; private set; }

        public User(string name, string email) : base()
        {
            Name = name;
            Email = new Email(email);

            Validate();
        }

        public void Validate()
        {
            AssertionConcerns.AssertArgumentNotEmpty(Name, "Name cannot be null or empty");
        }
    }
}