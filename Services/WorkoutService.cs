using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TihomirsBakery.Models.Workout;
using TihomirsBakery.Repository.IRepository;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkoutService(IUnitOfWork unitOfWork, IMapper autoMapper, IHttpContextAccessor httpContext)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _httpContextAccessor = httpContext;
        }

        public async Task<IEnumerable<Workout>> GetAll(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Workouts.GetAll(cancellationToken);
        }

        public async Task<Workout> GetWorkoutForTodayByUserId(int userId, CancellationToken cancellationToken)
        {
            return await  _unitOfWork.Workouts.GetWorkoutForTodayByUserId(userId, cancellationToken);
        }

        public async Task<Workout> GetById(int id, CancellationToken cancellationToken)
        {
            return await  _unitOfWork.Workouts.GetById(id, cancellationToken);
        }

        public async Task<Workout> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Workouts.GetByUserId(userId, cancellationToken);
        }

        public async Task<Workout> Create(WorkoutCreateRequest createRequest, CancellationToken cancellationToken)
        {
            var workout = _autoMapper.Map<Workout>(createRequest);
            var user = await _unitOfWork.Users.GetById(cancellationToken, int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue("Id"))) ?? throw new Exception ("User is nulL!");

            workout.UserId = user.Id;
            workout.User = user;
            workout.DateCreated = DateTime.Now.ToUniversalTime();

            _unitOfWork.Workouts.Add(workout);
            await _unitOfWork.SaveChangesAsync();

            return workout;
        }

        public async Task<Workout> Update(WorkoutUpdateRequest updateRequest, CancellationToken cancellationToken)
        {
            var workoutFromDb = await _unitOfWork.Workouts.GetWorkoutForTodayByUserId(int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue("Id")), cancellationToken);

            workoutFromDb.Name = updateRequest.Name;
            workoutFromDb.WorkoutType = updateRequest.Type;
            workoutFromDb.Duration = updateRequest.Duration;
            workoutFromDb.TotalCalories = updateRequest.TotalCalories;

            _unitOfWork.Workouts.Update(workoutFromDb);
            await _unitOfWork.SaveChangesAsync();

            return workoutFromDb;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var workoutFromDb = await _unitOfWork.Workouts.GetById(id, cancellationToken) ?? throw new Exception("Workout with the given ID was not found!");

            _unitOfWork.Workouts.Remove(workoutFromDb);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTodaysWorkoutByUserId(int userId, CancellationToken cancellationToken)
        {
            var workoutFromDb = await _unitOfWork.Workouts.GetWorkoutForTodayByUserId(userId, cancellationToken) ?? throw new Exception("Workout with the given USER ID was not found!");

            _unitOfWork.Workouts.Remove(workoutFromDb);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}