using System.ComponentModel.DataAnnotations.Schema;

namespace Eva_project.Models
{
    public class CourseSpeciality
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int SpecialityId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course? Courses { get; set; }
        [ForeignKey(nameof(SpecialityId))]
        public virtual Speciality? Speciality { get; set; }

    }
}
