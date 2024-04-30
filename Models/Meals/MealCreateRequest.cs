using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.Meals
{
    public class MealCreateRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
		public string Description { get; set; } = string.Empty;
        [Required]
		public string Type { get; set; } = string.Empty;
        [Required]
		public double Proteins { get; set; }
        [Required]
		public double Fats { get; set; }
        [Required]
		public double Carbs { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}