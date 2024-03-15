﻿using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Domain.IRepository
{
    public interface IJobPostRepository : IRepository<JobPost>
    {

        void Update(int id, JobPostDto jobPostDto);
        //void Create(JobPostDto jobPostDto);
        void Create(string userId, JobPostDto jobPostDto);

    }
}
