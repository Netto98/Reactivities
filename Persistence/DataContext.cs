using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /// <summary>
    /// DataContext class, which acts as the bridge between the application and the database.
    /// Inherits from DbContext to handle database operations and manage entities.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Constructor for DataContext, initializing it with database options.
        /// </summary>
        /// <param name="options">Options for configuring the DbContext, typically passed from the application startup.</param>
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Represents the Activities table in the database. 
        /// DbSet provides functionality to query, add, update, and delete Activity records.
        /// </summary>
        public DbSet<Activity> Activities { get; set; }
    }
}