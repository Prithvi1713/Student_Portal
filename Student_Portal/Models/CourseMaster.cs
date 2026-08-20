using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Portal.Models
{
    public class CourseMaster
    {
        [Key]
        public int courseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int DepartmentID { get; set; }
        public bool Status { get; set; }
        [ForeignKey(nameof(DepartmentID))]
        public virtual DepartmentMaster? DepartmentMaster { get; set; }
    }
}
