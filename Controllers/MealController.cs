using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Meal;
using TihomirsBakery.Services;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class MealController : ControllerBase
	{

		private IMealService _mealService;
        public MealController(IMealService mealService)
        {
			_mealService = mealService;
        }

        [HttpGet]
		public async Task<ActionResult<List<Meal>>> Get(CancellationToken cancellationToken)
		{
			try
			{
				var result = await _mealService.GetAll(cancellationToken);
				return Ok(result);
			} 
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Meal>> GetById(CancellationToken cancellationToken, int id)
		{
			try
			{
				var result = await _mealService.GetById(cancellationToken, id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		public async Task<ActionResult<List<Meal>>> GetByNameFromQuery(CancellationToken cancellationToken, [FromQuery]string name)
		{
			try
			{
				var result = await _mealService.GetByName(cancellationToken, name);
				return Ok(result);
			} 
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<ActionResult<List<Meal>>> Create(CancellationToken cancellationToken, MealCreateRequest meal)
		{
			try
			{
				var result = await _mealService.Create(cancellationToken, meal);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<ActionResult<List<Meal>>> Update(CancellationToken cancellationToken, MealUpdateRequest request)
		{
			try
			{
				var result = await _mealService.Update(cancellationToken, request);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<List<Meal>>> Delete(CancellationToken cancellationToken, int id)
		{
			try
			{
				var result = await _mealService.Delete(cancellationToken, id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
