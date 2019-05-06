using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProjectManager.DataAccess
{
    public partial class ProjectmanagerContext : DbContext
    {
        
        public ProjectmanagerContext() : base("name=ProjectMangerDbConString")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            

        }

       
        public virtual DbSet<ParentTask> ParentTasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentTask>().HasKey(e => e.ParentId);
            modelBuilder.Entity<ParentTask>().ToTable("ParentTask", "dbo");
            modelBuilder.Entity<ParentTask>().Property(e => e.ParentId).HasColumnName("Parent_ID");
            modelBuilder.Entity<ParentTask>().Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

            modelBuilder.Entity<Project>().HasKey(e => e.ProjectId);
            modelBuilder.Entity<Project>().ToTable("Project", "dbo");
            modelBuilder.Entity<Project>().Property(e => e.ProjectId).HasColumnName("Project_ID");
            modelBuilder.Entity<Project>().Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            modelBuilder.Entity<Project>().Property(e => e.EndDate).HasColumnType("datetime");
            modelBuilder.Entity<Project>().Property(e => e.StartDate).HasColumnType("datetime");
            modelBuilder.Entity<Project>().Property(e => e.UserId).HasColumnName("User_ID");

            modelBuilder.Entity<Task>().HasKey(e => e.TaskId);
            modelBuilder.Entity<Task>().ToTable("Task", "dbo");
            modelBuilder.Entity<Task>().Property(e => e.TaskId).HasColumnName("Task_ID");
            modelBuilder.Entity<Task>().Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime");
            modelBuilder.Entity<Task>().Property(e => e.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<Task>().Property(e => e.ParentId).HasColumnName("Parent_ID");
            modelBuilder.Entity<Task>().Property(e => e.ProjectId).HasColumnName("Project_ID");
            modelBuilder.Entity<Task>().Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime");
            modelBuilder.Entity<Task>().Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            modelBuilder.Entity<Task>().Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

            modelBuilder.Entity<User>().HasKey(e => e.UserId);
            modelBuilder.Entity<User>().ToTable("User", "dbo");
            modelBuilder.Entity<User>().Property(e => e.UserId).HasColumnName("User_ID");
            modelBuilder.Entity<User>().Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            modelBuilder.Entity<User>().Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            modelBuilder.Entity<User>().Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}