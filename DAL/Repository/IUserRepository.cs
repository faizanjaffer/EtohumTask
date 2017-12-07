using EtohumTask.Models;
using System;
using System.Collections.Generic;

namespace EtohumTask.DAL.Repository
{
    /// <summary>
    /// Repository Interface for CRUD operations.
    /// </summary>
    public interface IUserRepository : IDisposable
    {
        /// <summary>
        /// Get the List of all Users and return it.
        /// </summary>
        /// <returns>
        /// List of all Users.
        /// </returns>
        IEnumerable<User> GetUsers();

        /// <summary>
        /// Get the Single User by the <paramref name="UserId"/> and returns it.
        /// </summary>
        /// <returns>
        /// Single User Object.
        /// </returns>
        User GetUserByID(int UserId);

        /// <summary>
        /// Insert User Object to the Database. <paramref name="user"/>.
        /// </summary>
        void AddUser(User user);

        /// <summary>
        /// Delete User from the Database by. <paramref name="UserId"/>.
        /// </summary>
        void DeleteUser(int UserId);

        /// <summary>
        /// Update User in the Database by. <paramref name="UserId"/>.
        /// </summary>
        void UpdateUser(User user);

        /// <summary>
        /// Save the changes in the Database.
        /// </summary>
        void Save();
    }
}