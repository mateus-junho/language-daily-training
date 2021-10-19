using LanguageDailyTraining.Domain.Core;
using System;
using System.Collections.Generic;

namespace LanguageDailyTraining.Domain.Entities
{
    public class TrainingPlan : Entity
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public int SentenceQuantity { get; private set; }
        public int Iterations { get; private set; }

        public User User { get; private set; }
        public IEnumerable<Sentence> Sentences { get; private set; }

        public TrainingPlan(Guid userId, string name, int sentenceQuantity, int iterations) : base()
        {
            UserId = userId;
            Name = name;
            SentenceQuantity = sentenceQuantity;
            Iterations = iterations;
        }
    }
}
