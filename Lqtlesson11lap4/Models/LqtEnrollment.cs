using System.ComponentModel.DataAnnotations;

namespace Lqtlesson11lap4.Models
{
    public class LqtEnrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int LearnerID { get; set; }
        public float Grade { get; set; }
        public virtual LqtLearner? Learner { get; set; }
        public virtual LqtCourse? Course { get; set; }
    }
}
