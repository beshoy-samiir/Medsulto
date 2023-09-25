namespace Eva_project.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string EstimatedTime  { get; set;}
        public string? CoverImage { get; set;}
        public string PracticeLevel { get; set; }
        public string License { get; set; }
        public int InstructorId { get; set; } 
        public string Title { get; set;}
        public DateTime? PostedDate { get; set;}
        public string? TargetAudience { get; set; }
        public int? NumberOfDoctorsAttended { get; set; }
        public string? CourseOutline { get; set; }
        public string? Ratings { get; set; }
        public virtual ICollection<CourseSpeciality> CourseSpecialities { get; set; }

    }
}
