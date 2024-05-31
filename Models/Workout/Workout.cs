using System.ComponentModel.DataAnnotations.Schema;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Models.Workout
{
    public class Workout
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Name { get; set; }
        public WorkoutType WorkoutType { get; set; }
        public TimeOnly Duration { get; set; }
        public int TotalCalories { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
