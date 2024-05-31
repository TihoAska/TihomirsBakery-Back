using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Workout;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        IWorkoutService _workoutService { get; set; }
        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Workout>>> GetAll(CancellationToken cancellationToken) 
        {
            try
            {
                var result = await _workoutService.GetAll(cancellationToken);
                return Ok(result);
            }  
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Workout>> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.GetById(id, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Workout>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.GetByUserId(userId, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Workout>> GetWorkoutForTodayByUserId(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.GetWorkoutForTodayByUserId(userId, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> Create(WorkoutCreateRequest createRequest, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.Create(createRequest, cancellationToken);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Workout>> Update(WorkoutUpdateRequest updateRequest, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.Update(updateRequest, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.Delete(id, cancellationToken);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteTodaysWorkoutByUserId(int userId, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _workoutService.DeleteTodaysWorkoutByUserId(userId, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
