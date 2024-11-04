using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    /// <summary>
    /// Controller for handling HTTP requests related to activities.
    /// Inherits from BaseApiController, which provides base functionality for API controllers.
    /// </summary>
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context; // Database context for accessing the Activities data.

        /// <summary>
        /// Constructor that initializes the ActivitiesController with the DataContext.
        /// </summary>
        /// <param name="context">An instance of DataContext to interact with the database.</param>
        public ActivitiesController(DataContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Retrieves a list of all activities from the database.
        /// </summary>
        /// <returns>A list of Activity objects wrapped in an ActionResult.</returns>
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {

            return await _context.Activities.ToListAsync();
        }

        /// <summary>
        /// Retrieves a specific activity by its unique identifier.
        /// </summary>
        /// <param name="Id">The unique identifier (GUID) of the activity.</param>
        /// <returns>The Activity object if found; otherwise, null.</returns>
        [HttpGet("{Id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid Id)
        {
            return await _context.Activities.FindAsync(Id);
        }
    }
}