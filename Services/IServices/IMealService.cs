using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Meal;

namespace TihomirsBakery.Services
{
	public interface IMealService
	{
		Task<IEnumerable<Meal>> GetAll(CancellationToken cancellationToken);
		Task<Meal> GetById(CancellationToken cancellationToken, int id);
		Task<List<Meal>> GetByName(CancellationToken cancellationToken, string name);
		Task<Meal> Create(CancellationToken cancellationToken, MealCreateRequest meal);
		Task<Meal> Update(CancellationToken cancellationToken, MealUpdateRequest request);
		Task<bool> Delete(CancellationToken cancellationToken, int id);
	}
}
