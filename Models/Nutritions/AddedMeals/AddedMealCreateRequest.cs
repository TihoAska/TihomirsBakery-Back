namespace TihomirsBakery.Models.Nutritions.AddedMeals
{
    public class AddedMealCreateRequest
    {
        public string Name { get; set; }
        public int MealIntakeId { get; set; }
        public MealType MealType { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fats { get; set; }
    }
}
