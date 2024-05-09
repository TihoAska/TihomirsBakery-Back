using System.ComponentModel.DataAnnotations.Schema;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Models.Nutritions
{
    public class DailyIntake
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbs { get; set; }
        public double TotalFats { get; set; }
        public List<MealIntake> MealIntakes { get; set; }
    }
}
