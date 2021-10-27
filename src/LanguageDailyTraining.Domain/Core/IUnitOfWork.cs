using System.Threading.Tasks;

namespace LanguageDailyTraining.Domain.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
