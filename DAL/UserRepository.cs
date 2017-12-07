using EtohumTask.DAL.Repository;
using EtohumTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EtohumTask.DAL
{
    /// <summary>
    /// User Class implementing Repository Interface to implement CRUD Operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private UsersEmailDBContext _context;

        /// <summary>
        /// Constructor assigning the DBContext.
        /// </summary>
        public UserRepository(UsersEmailDBContext UserContext)
        {
            this._context = UserContext;
        }

        /// <summary>
        /// Get the List of all Users and returns it.
        /// </summary>
        /// <returns>
        /// List of all Users.
        /// </returns>
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Get the Single User by the <paramref name="UserId"/> and returns it.
        /// </summary>
        /// <returns>
        /// Single User Object.
        /// </returns>
        public User GetUserByID(int id)
        {
            return _context.Users.Find(id);
        }

        /// <summary>
        /// Insert User Object to the Database. <paramref name="user"/>.
        /// </summary>
        public void AddUser(User User)
        {
            _context.Users.Add(User);
        }

        /// <summary>
        /// Delete User from the Database by. <paramref name="UserId"/>.
        /// </summary>
        public void DeleteUser(int UserID)
        {
           //Not Implemented as it isn't required in the given Task.
        }

        /// <summary>
        /// Update User in the Database by. <paramref name="UserId"/>.
        /// </summary>
        public void UpdateUser(User User)
        {
            //Not Implemented as it isn't required in the given Task. 
        }

        /// <summary>
        /// Save the changes in the Database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        /// <summary>
        /// Dispose the object if already not disposed.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Force garbage collector to dispose object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}