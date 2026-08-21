using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Net.NetworkInformation;

namespace Student_Portal.Models
{
    public class StudentMaster
    {
        [Key]
        public int StudentID { get; set; }
        public string FirstName   { get; set; }
        public string MiddleName { get; set; }
        public string LastName    { get; set; }
        public string MobileNo    { get; set; }
        public string EmailAddress { get; set; }
        public DateOnly BirthDate   { get; set; }
        public int DepartmentID    { get; set; }
        public int CourseID    { get; set; }
        public bool Status  { get; set; }
        public string Gender  { get; set; }
        public string Address { get; set; }

        [ForeignKey(nameof(DepartmentID))]
        public virtual DepartmentMaster? DepartmentMaster { get; set; }
        [ForeignKey(nameof(CourseID))]
        public virtual CourseMaster? CourseMaster { get; set; }
    }
}
