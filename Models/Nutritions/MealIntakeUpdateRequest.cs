using System.Text.Json.Serialization;
using TihomirsBakery.Models.Nutritions.AddedMeals;

namespace TihomirsBakery.Models.Nutritions
{
    public class MealIntakeUpdateRequest
    {
        public MealType MealType { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }

        [JsonIgnore]
        public List<AddedMealCreateRequest> AddedMeals { get; set; }
    }
}
