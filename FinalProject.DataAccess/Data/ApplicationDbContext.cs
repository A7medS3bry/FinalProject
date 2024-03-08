
using FinalProject.Domain.Models.ApplicationUserModel;
using FinalProject.Domain.Models.FavoritesTable;
using FinalProject.Domain.Models.JobPostAndContract;
using FinalProject.Domain.Models.NotificationAndMessageModel;
using FinalProject.Domain.Models.ProtfolioModle;
using FinalProject.Domain.Models.RatingModel;
using FinalProject.Domain.Models.RegisterNeeded;
using FinalProject.Domain.Models.ReportModel;
using FinalProject.Domain.Models.SkillAndCat;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region LanguageUserRelation
            modelBuilder.Entity<ApplicationUserLanguage>()
                .HasKey(al => new { al.ApplicationUserId, al.LanguageValue });

            modelBuilder.Entity<ApplicationUserLanguage>()
                .HasOne(al => al.ApplicationUser)
                .WithMany(u => u.UserLanguages)
                .HasForeignKey(al => al.ApplicationUserId);

            modelBuilder.Entity<ApplicationUserLanguage>()
                .HasOne(al => al.Language)
                .WithMany(l => l.UserLanguages)
                .HasForeignKey(al => al.LanguageValue);
            #endregion

            #region UserSkillRelation
            modelBuilder.Entity<UserSkill>()
                .HasKey(a => new { a.UserId, a.SkillId });

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId);
            #endregion

            #region SkillCategoryRelation
            modelBuilder.Entity<SkillCategory>().HasKey(sc => new { sc.SkillId, sc.CategoryId });
            modelBuilder.Entity<SkillCategory>().HasOne(sc =>sc.Skill).WithMany(s => s.SkillCategories).HasForeignKey(sc => sc.SkillId);
            modelBuilder.Entity<SkillCategory>().HasOne(sc => sc.Category).WithMany(c => c.SkillCategories).HasForeignKey(sc => sc.CategoryId);

            #endregion

            #region JobPostUserRelatio

            modelBuilder.Entity<JobPost>()
                    .HasOne(j => j.ApplicationUser)
                    .WithMany(u => u.JobPosts)
                    .HasForeignKey(j => j.UserId);

            #endregion

            #region ProfileWithUser
            modelBuilder.Entity<Protfolio>()
                    .HasOne(j => j.ApplicationUser)
                    .WithMany(u => u.Protfolios)
                    .HasForeignKey(j => j.UserId);
            #endregion

            #region JobPostCatogry
            modelBuilder.Entity<JobPost>().HasOne(a => a.Category).WithMany(a => a.JobPosts).HasForeignKey(a => a.CategoryId);
            #endregion

            #region JobPostSkill
            modelBuilder.Entity<JobPostSkill>().HasKey(a => new { a.SkillId , a.JobPostId});
            modelBuilder.Entity<JobPostSkill>().HasOne(a=>a.Skill).WithMany(a => a.JobPostSkill).HasForeignKey(a => a.SkillId);
            modelBuilder.Entity<JobPostSkill>().HasOne(a=>a.JobPost).WithMany(a=>a.JobPostSkill).HasForeignKey(a => a.JobPostId);
            #endregion

            #region ReviewFreelancerAndUser

            modelBuilder.Entity<Review>().HasOne(a => a.Client).WithMany().HasForeignKey(a => a.ClientId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>().HasOne(a => a.Freelancer).WithMany().HasForeignKey(a => a.FreelancerId).OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Reportes
            modelBuilder.Entity<Reports>().HasOne(a => a.Client).WithMany().HasForeignKey(a => a.ClientId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reports>().HasOne(a => a.Freelancer).WithMany().HasForeignKey(a => a.FreelancerId).OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Contract
            modelBuilder.Entity<Contract>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contract>()
                .HasOne(a => a.Freelancer)
                .WithMany()
                .HasForeignKey(a => a.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region ApplyTask
            modelBuilder.Entity<ApplyTask>()
                .HasOne(a => a.Review)
                .WithOne(r => r.ApplyTask)
                .HasForeignKey<Review>(r => r.ApplyTaskId);
            modelBuilder.Entity<ApplyTask>()
                .HasOne(a => a.Client)
                .WithMany()
                .HasForeignKey(a => a.ClientId);
            modelBuilder.Entity<ApplyTask>()
                .HasOne(a => a.Freelancer)
                .WithMany()
                .HasForeignKey(a => a.FreelancerId);
            #endregion

            #region Notification
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.ApplyTask)
                .WithMany(a => a.Notifications)
                .HasForeignKey(n => n.ApplyTaskId);
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.JobPost)
                .WithMany(j => j.Notifications)
                .HasForeignKey(n => n.JobPostId);
            #endregion
            #region Favoirtes
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.Freelancer)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.FreelancerId);
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.Jobpost)
                .WithMany(j => j.Favorites)
                .HasForeignKey(f => f.JobpostId);
            #endregion
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ApplicationUserLanguage> ApplicationUserLanguages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Protfolio> Protfolios { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ApplyTask> ApplyTasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Favorites> Favorites { get; set; }


    }
}
