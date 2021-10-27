using LanguageDailyTraining.Domain.Core;
using System;

namespace LanguageDailyTraining.Domain.Entities
{
    public class Sentence : Entity
    {
        public Guid TrainingPlanId { get; private set; }
        public string Description { get; private set; }
        public string Meaning { get; private set; }
        public int Hits { get; private set; }
        public int Errors { get; private set; }
        public bool Active { get; private set; }
        public DateTime LastTimeCheck { get; private set; }

        public TrainingPlan TrainingPlan { get; private set; }

        public Sentence(Guid trainingPlanId, string description, string meaning) : base()
        {
            TrainingPlanId = trainingPlanId;
            Description = description;
            Meaning = meaning;
            Hits = 0;
            Errors = 0;
            Active = true;
            LastTimeCheck = DateTime.Now;

            Validate();
        }

        public void Validate()
        {
            AssertionConcerns.AssertArgumentNotEmpty(Description, "Description cannot be null or empty");
            AssertionConcerns.AssertArgumentNotEmpty(Meaning, "Meaning cannot be null or empty");
            AssertionConcerns.AssertArgumentNotEquals(TrainingPlanId, Guid.Empty, "TrainingPlanId cannot be empty");
        }
    }
}
