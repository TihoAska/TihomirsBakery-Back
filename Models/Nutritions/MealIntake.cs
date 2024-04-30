using System.ComponentModel.DataAnnotations.Schema;

namespace TihomirsBakery.Models.Nutritions
{
    public class MealIntake
    {
        public int Id { get; set; }
        public int DailyIntakeId { get; set; }

        [ForeignKey("DailyIntakeId")]
        public DailyIntake DailyIntake { get; set; }
        public MealType MealType { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}
