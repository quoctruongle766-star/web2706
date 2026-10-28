using System.ComponentModel.DataAnnotations;

namespace Lqtlesson11lap4.Models
{
    public class LqtMajor
    {
        public LqtMajor()
        {
            Learners = new HashSet<LqtLearner>();
        }

        [Key]
        public int MajorID { get; set; }
        public string MajorName { get; set; } = string.Empty;
        public virtual ICollection<LqtLearner> Learners { get; set; }
    }
}
