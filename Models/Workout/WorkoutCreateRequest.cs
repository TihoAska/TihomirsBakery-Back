using System.ComponentModel.DataAnnotations.Schema;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Models.Workout
{
    public class WorkoutCreateRequest
    {
        public string Name { get; set; }
        public WorkoutType Type { get; set; }
        public TimeOnly Duration { get; set; }
        public int TotalCalories { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
