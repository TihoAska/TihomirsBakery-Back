using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Nutritions;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        IDailyIntakeService _dailyIntakeService;
        IMealIntakeService _mealIntakeService;

        public NutritionController(IDailyIntakeService dailyIntakeService, IMealIntakeService mealIntakeService)
        {
            _dailyIntakeService = dailyIntakeService;
            _mealIntakeService = mealIntakeService;
        }


        [HttpGet]
        public async Task<ActionResult<DailyIntake>> GetDailyIntakeForTodayByUserId(CancellationToken cancellationToken, int userId)
        {
            try
            {
                var result = await _dailyIntakeService.GetByUserIdForToday(cancellationToken, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MealIntake>> AddMeal(CancellationToken cancellationToken, [FromBody] MealIntakeCreateRequest createRequest)
        {
            try
            {
                var result = await _mealIntakeService.Create(cancellationToken, createRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<MealIntake>> EditMeal(CancellationToken cancellationToken, MealIntakeUpdateRequest updateRequest)
        {
            try
            {
                var result = await _mealIntakeService.Update(cancellationToken, updateRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
