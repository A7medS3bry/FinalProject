
namespace FinalProject.Domain.IRepository
{    
    public interface IUnitOfWork 
    {
        IJobPostRepository JobPostRepository { get; }
        void Save();
        
    }
}
