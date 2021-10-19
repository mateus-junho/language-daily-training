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

        private const int SENTENCE_QUANTITY_MIN = 1;
        private const int SENTENCE_QUANTITY_MAX = 999;
        private const int ITERATIONS_QUANTITY_MIN = 1;
        private const int ITERATIONS_QUANTITY_MAX = 10;

        public TrainingPlan(Guid userId, string name, int sentenceQuantity, int iterations) : base()
        {
            UserId = userId;
            Name = name;
            SentenceQuantity = sentenceQuantity;
            Iterations = iterations;

            Validate();
        }

        public void Validate()
        {
            AssertionConcerns.AssertArgumentNotEmpty(Name, "Name cannot be null or empty");
            AssertionConcerns.AssertArgumentRange(SentenceQuantity, SENTENCE_QUANTITY_MIN, SENTENCE_QUANTITY_MAX,
                $"SentenceQuantity should be between {SENTENCE_QUANTITY_MIN} and {SENTENCE_QUANTITY_MAX}");
            AssertionConcerns.AssertArgumentRange(Iterations, ITERATIONS_QUANTITY_MIN, ITERATIONS_QUANTITY_MAX,
                $"SentenceQuantity should be between {ITERATIONS_QUANTITY_MIN} and {ITERATIONS_QUANTITY_MAX}");
        }
    }
}
