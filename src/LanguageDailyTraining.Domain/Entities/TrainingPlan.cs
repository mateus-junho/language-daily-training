using LanguageDailyTraining.Domain.Core;
using System;
using System.Collections.Generic;

namespace LanguageDailyTraining.Domain.Entities
{
    public class TrainingPlan : Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public int SentenceQuantity { get; private set; }
        public int Repetition { get; private set; }
        public DateTime RegisterDate { get; private set; }

        public User User { get; private set; }
        public IEnumerable<Sentence> Sentences { get; private set; }

        public const int SENTENCE_QUANTITY_MIN = 1;
        public const int SENTENCE_QUANTITY_MAX = 99;
        public const int REPETITION_QUANTITY_MIN = 0;
        public const int REPETITION_QUANTITY_MAX = 9;

        protected TrainingPlan() { }

        public TrainingPlan(Guid userId, string name, int sentenceQuantity, int repetition) : base()
        {
            UserId = userId;
            Name = name;
            SentenceQuantity = sentenceQuantity;
            Repetition = repetition;

            Validate();
        }

        public void Validate()
        {
            AssertionConcerns.AssertArgumentNotEmpty(Name, "Name cannot be null or empty");
            AssertionConcerns.AssertArgumentNotEquals(UserId, Guid.Empty, "UserId cannot be empty");
            AssertionConcerns.AssertArgumentRange(SentenceQuantity, SENTENCE_QUANTITY_MIN, SENTENCE_QUANTITY_MAX,
                $"SentenceQuantity should be between {SENTENCE_QUANTITY_MIN} and {SENTENCE_QUANTITY_MAX}");
            AssertionConcerns.AssertArgumentRange(Repetition, REPETITION_QUANTITY_MIN, REPETITION_QUANTITY_MAX,
                $"SentenceQuantity should be between {REPETITION_QUANTITY_MIN} and {REPETITION_QUANTITY_MAX}");
        }
    }
}
