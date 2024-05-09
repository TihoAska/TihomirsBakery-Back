using System.ComponentModel.DataAnnotations.Schema;

namespace TihomirsBakery.Models.Nutritions.AddedMeals
{
    public class AddedMeal
    {
        public int Id { get; set; }
        public int MealIntakeId { get; set; }

        [ForeignKey("MealIntakeId")]
        public MealIntake MealIntake { get; set; }
        public MealType MealType { get; set; }
        public string? Name { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}
