using EducationalPlatform.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EducationalPlatform.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {


        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {


        }

        #region Dbsets
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Video> Videos { get; set; }


        public DbSet<ChooseQuestion> ChooseQuestions { get; set; }
        public DbSet<TrueOrFalseQuestion> TrueOrFalseQuestions { get; set; }

        public DbSet<WriteQuestion> WriteQuestions { get; set; }


        public DbSet<Question> Questions { get; set; }

        public DbSet<Content> Content { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-30J4B23\\SQLEXPRESS;Initial Catalog= OnlineGym ;Integrated Security=True;Connect Timeout=100;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>(entity =>
            {


                entity.HasMany(u => u.Enrollments)
                      .WithOne(e => e.User)
                      .HasForeignKey(e => e.UserId);
                entity.HasMany(u => u.Payments)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Description);
            });






            /////////////////RELATIONS//////////////


            // relation between Course and Content

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Contents)
                .WithMany(co => co.Courses)
                .UsingEntity<CourseContent>(
                   j => j
                    .HasOne(cc => cc.Content)
                    .WithMany(co => co.CourseContents)
                    .HasForeignKey(cc => cc.ContentId),

                     j => j
                     .HasOne(cc => cc.Course)
                    .WithMany(co => co.CourseContents)
                    .HasForeignKey(cc => cc.CourseId),

                     j =>
                     {
                         j.HasKey(cc => new { cc.CourseId, cc.ContentId });
                     }

                );

            //



            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.QuizQuestions)
                .WithMany(qu => qu.Quizs)
                .UsingEntity(e => e.ToTable("QuizQuestion"));


            modelBuilder.Entity<Assignment>()
              .HasMany(q => q.Questions)
              .WithMany(qu => qu.Assignments)
              .UsingEntity(e => e.ToTable("AssignmentQuestion"));





            modelBuilder.Entity<ChooseQuestion>()
              .HasMany(q => q.ChoiceList)
              .WithMany(qu => qu.ChooseQuestions)
              .UsingEntity(e => e.ToTable("ChooseQuestionAnswer"));

            modelBuilder.Entity<TrueOrFalseQuestion>()
              .HasMany(q => q.ChoiceList)
              .WithMany(qu => qu.TrueOrFalseQuestions).UsingEntity(e => e.ToTable("TrueOrFalseQuestionAnswer"));


            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "User", NormalizedName = "USER" }


                );

        }

    }


}
