using Backend.Entities;

namespace Backend.ViewModels
{
    public class HomeVM
    {
        public ICollection<Course> Courses { get; set; } = null!;
        public ICollection<Supporter> Supporters { get; set; } = null!;
        public ICollection<Category> Categories { get; set; } = null!;
    }
}
