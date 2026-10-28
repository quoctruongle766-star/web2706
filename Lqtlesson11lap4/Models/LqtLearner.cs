using System.ComponentModel.DataAnnotations;

namespace Lqtlesson11lap4.Models
{
    public class LqtLearner
    {
        public LqtLearner()
        {
            Enrollments = new HashSet<LqtEnrollment>();
        }

        [Key]
        public int LearnerID { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstMidName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual LqtMajor? Major { get; set; }
        public virtual ICollection<LqtEnrollment> Enrollments { get; set; }
    }
}
