using FinalProject.DataAccess.Data;
using FinalProject.Domain.IRepository;
using FinalProject.Domain.Models.SkillAndCat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;

        public IJobPostRepository JobPostRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IJobPostRepository jobPostRepository)
        {
            _context = context;
            JobPostRepository = jobPostRepository;
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
