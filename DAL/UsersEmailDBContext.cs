using EtohumTask.Models;
using System.Data.Entity;

namespace EtohumTask.DAL
{
    /// <summary>
    /// The DBContext class for the Connection to Database.
    /// Contains name of Connectionstring and property of Collection of enitities.
    /// </summary>
    public class UsersEmailDBContext : DbContext
    {
        /// <summary>
        /// Constructor specifying the name of connectionstring.
        /// </summary>
        public UsersEmailDBContext()
            : base("name=DBConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
