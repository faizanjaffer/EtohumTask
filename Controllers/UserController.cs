using EtohumTask.DAL;
using EtohumTask.DAL.Repository;
using EtohumTask.Models;
using Hangfire;
using System.Data;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace EtohumTask.Controllers
{
    /// <summary>
    /// Controller for the User Model. It will perform CRUD Operations.
    /// </summary>
    public class UserController : Controller
    {
        private IUserRepository _UserRepository;

        /// <summary>
        /// Constructor assigning Repository with DBContext object.
        /// </summary>
        public UserController()
        {
            this._UserRepository = new UserRepository(new UsersEmailDBContext());
        }

        /// <summary>
        /// HttpGet - Gets all the Users from Repository.
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            var Users = from User in _UserRepository.GetUsers()
                        select User;
            return View(Users);
        }

        /// <summary>
        /// HttpGet - Create a new User Object on Create View.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }

        /// <summary>
        /// HttpPost - Insert new User object to repository <paramref name="User"/>, save it and assign EmailSending Task to Background Queue.
        /// </summary>
        /// <exception cref="DataException">Thrown when model could not be inserted to repository.
        /// <returns>
        /// Create User View.
        /// </returns>
        [HttpPost]
        public ActionResult Create(User User)
        {
            try
            {
                //Validate the Model
                if (ModelState.IsValid)
                {
                    //Insert new User object to repository
                    _UserRepository.AddUser(User);
                    _UserRepository.Save();

                    /// <summary>
                    /// If using Hangfire Library.
                    /// </summary>
                    /// <example>
                    /// <code>
                    /// BackgroundJob.Enqueue(() => SendMailAsync(User.EmailAddress));
                    /// </code>
                    /// </example>

                    /// <summary>
                    /// Assign EmailSending Task to Background Queue..
                    /// </summary>
                    HostingEnvironment.QueueBackgroundWorkItem(ct => SendMailAsync(User.EmailAddress));

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("error", "An error occured.");
            }
            return View(User);
        }

        /// <summary>
        /// HttpPost - Insert new User object to repository <paramref name="User"/>, save it and assign EmailSending Task to Background Queue.
        /// </summary>
        /// <exception cref="DataException">Thrown when model could not be inserted to repository.
        [HttpPost]
        public ActionResult SendEmail(string FriendsEmail)
        {
            try
            {
                /// <summary>
                /// If using Hangfire Library.
                /// </summary>
                /// <example>
                /// <code>
                /// BackgroundJob.Enqueue(() => SendMailAsync(User.EmailAddress));
                /// </code>
                /// </example>

                HostingEnvironment.QueueBackgroundWorkItem(ct => SendMailAsync(FriendsEmail));

            }
            catch (System.Exception ex)
            {
                return Content(ex.Message);
            }
            return View();
        }

        /// <summary>
        /// Contains the SMTP Code for sending email.
        /// </summary>
        /// <returns>
        /// Email success or not.
        /// </returns>
        [NonAction]
        private bool SendMailAsync(string email)
        {
            //SMTP Code goes here
            return true;

        }
    }
}