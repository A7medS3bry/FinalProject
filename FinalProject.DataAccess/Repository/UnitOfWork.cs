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
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;

        public IJobPostRepository JobPostRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            JobPostRepository = new JobPostRepository(_context);
        }

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
