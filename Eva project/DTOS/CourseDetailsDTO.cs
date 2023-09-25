namespace Eva_project.DTOS
{
    public class CourseDetailsDTO
    {
        public string? CoverImage { get; set; }
        public DateTime? DatePosted { get; set; }
        public string Title { get; set; }
        public string? CourseSpecialty { get; set; }
        public string EstimatedTime { get; set; }
        public string LevelOfPractice { get; set; }
        public string License { get; set; }
        public string TargetAudience { get; set; }
        public int NumberOfDoctorsAttended { get; set; }
        public string CourseOutline { get; set; }
        public string Ratings { get; set; }
    }
}
