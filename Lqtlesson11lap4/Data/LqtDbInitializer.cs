using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lqtlesson11lap4.Models;

namespace Lqtlesson11lap4.Data
{
    public class LqtDbInitializer
    {
        public static void LqtInitialize(IServiceProvider serviceProvider)
        {
            using (var context = new LqtSchoolContext(serviceProvider.GetRequiredService<DbContextOptions<LqtSchoolContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Majors.Any())
                {
                    return;
                }

                var majors = new LqtMajor[]
                {
                    new LqtMajor { MajorName = "IT" },
                    new LqtMajor { MajorName = "Economics" },
                    new LqtMajor { MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                var learners = new LqtLearner[]
                {
                    new LqtLearner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01"), MajorID = 1 },
                    new LqtLearner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01"), MajorID = 2 }
                };

                foreach (var l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                var courses = new LqtCourse[]
                {
                    new LqtCourse { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new LqtCourse { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new LqtCourse { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };

                foreach (var c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                var enrollments = new LqtEnrollment[]
                {
                    new LqtEnrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new LqtEnrollment { LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                    new LqtEnrollment { LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                    new LqtEnrollment { LearnerID = 2, CourseID = 4041, Grade = 7.0f }
                };

                foreach (var e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }

        public static void Initialize(IServiceProvider serviceProvider) => LqtInitialize(serviceProvider);
    }
}
