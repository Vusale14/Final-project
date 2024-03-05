namespace Backend.Entities
{
    public class CourseCategory
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Category Category { get; set; } = null;
    }
}
