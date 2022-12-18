using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Odev.ViewModels
{
    public class TeacherIndex
    {
        [Display(Name = "Öğretmen Numarası")]
        public int TeacherID { get; set; }

        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Display(Name = "Okul İsmi")]
        public string SchoolName { get; set; }

        [Display(Name = "Kurs Sayısı")]
        public int CourseCount { get; set; }

    }
}
