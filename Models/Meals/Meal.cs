namespace TihomirsBakery.Models.Meals
{
	public class Meal
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Type { get; set; } = string.Empty;
		public double Proteins { get; set; }
		public double Fats { get; set; }
		public double Carbs { get; set; }
		public int Calories { get; set; }
	}
}
