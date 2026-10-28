using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lqtlesson11lap4.Models
{
    public class LqtCourse
    {
        public LqtCourse()
        {
            Enrollments = new HashSet<LqtEnrollment>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
        public virtual ICollection<LqtEnrollment> Enrollments { get; set; }
    }
}
