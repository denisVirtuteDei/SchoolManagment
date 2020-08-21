namespace SchoolTableCursed.DB_Classes
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SchoolTableContext : DbContext
    {
        public SchoolTableContext()
            : base("name=SchoolTableContext")
        {
        }

        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<Week> Week { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Exercise)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.GroupFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Student)
                .WithRequired(e => e.Groups)
                .HasForeignKey(e => e.GroupFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Exercise)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.SubjNameFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Exercise)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TeacherFK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Week>()
                .HasMany(e => e.Exercise)
                .WithRequired(e => e.Week)
                .HasForeignKey(e => e.AWeek)
                .WillCascadeOnDelete(false);
        }
    }
}
