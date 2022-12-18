using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Odev.ViewModels
{
    public class TeacherDetail
    {
        [Display(Name = "İsim")]
        public string Name { get; set; }
        [Display(Name = "Kurslar")]
        public List<string> Courses { get; set; }
        [Display(Name = "Okul Adı")]
        public List<string> SchoolName { get; set; }
    }
}
