using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Receiver.Models
{
    public partial class TasksContext : DbContext
    {
        public TasksContext()
        {
        }

        public TasksContext(DbContextOptions<TasksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobTask> JobTasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Tasks;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTask>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__JobTask__7C6949B195EAEB8C");

                entity.ToTable("JobTask");

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
