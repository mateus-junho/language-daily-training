
namespace LanguageDailyTraining.Domain.Core
{
    public class AssertionConcerns
    {
        public static void AssertArgumentNotEmpty(string value, string message)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new DomainException(message);
            }
        }

        public static void AssertArgumentEquals(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(message);
            }
        }

    }
}
