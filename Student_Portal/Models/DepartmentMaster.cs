using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Student_Portal.Models
{
    public class DepartmentMaster
    {
        [Key]
        public int DepartmentId { get; set;}
        [Required(ErrorMessage =" Please Enter Department Name")]
        [Display(Name ="Department Name ")]

        public string DepartmentName { get; set; }
        [Required(ErrorMessage =" Please Enter Department Description")]
        [Display(Name = "Department Description")]

        public string DepartmentDescription { get; set; }
        [Display(Name = " Status")]
        public bool isActive { get; set; }
    }
}
