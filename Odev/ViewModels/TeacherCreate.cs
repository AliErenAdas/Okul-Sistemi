using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Odev.ViewModels
{
    public enum EducationType
    {
        Teorik,
        Pratik
    }
    public class TeacherCreate
    {
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu Alanın Girilmesi Zorunludur.")]
        [MaxLength(30, ErrorMessage = "30 karakterden fazlası girilemez")]
        public string Name { get; set; }

        [Display(Name = "Okul İsmi")]
        public int SchoolID { get; set; }

        [Display(Name = "Kurs İsmi")]
        public int CourseID { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public EducationType EducationType { get; set; }
    }
}
