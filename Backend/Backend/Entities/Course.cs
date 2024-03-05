namespace Backend.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public decimal? Rating { get; set; } = null!;
        public string LearnersNumber { get; set; } = null!;
        public decimal? OldPrice { get; set; } = null!;
        public decimal? NewPrice { get; set;} = null!;
        public string Image {  get; set; } = null!;
        public ICollection<CourseCategory> CourseCategories { get; set; }
    }
}
