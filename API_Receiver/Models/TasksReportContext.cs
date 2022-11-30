using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Receiver.Models
{
    public partial class TasksReportContext : DbContext
    {
        public TasksReportContext()
        {
        }

        public TasksReportContext(DbContextOptions<TasksReportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobTaskNew> JobTaskNews { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TasksReport;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTaskNew>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__JobTaskN__7C6949B154FB84FC");

                entity.ToTable("JobTaskNew");

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
