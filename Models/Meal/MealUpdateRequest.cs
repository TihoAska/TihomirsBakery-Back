using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.Meal
{
    public class MealUpdateRequest
    {
        [Required]
        public int Id { get; set; }
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