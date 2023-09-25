namespace Eva_project.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseSpeciality> CourseSpecialities { get; set; }
    }
}
