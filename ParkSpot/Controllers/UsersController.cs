using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkSpot.DAL.DbAccess;
using ParkSpot.Models;
using Service.Services.UserService;

namespace ParkSpot.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet, ActionName(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            return View(await this._userService.RetrieveAllAsync());
        }

        // GET: Users/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var user = this._userService.Retrieve(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet, ActionName(nameof(Create))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName(nameof(Create))]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = new Guid();
                await this._userService.AddAsync(user);
                return RedirectToAction(nameof(Index));

            }
            return View(user);

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var user = this._userService.Retrieve(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this._userService.UpdateAsync(user);

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    //if (!UserExists(user.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            return View(user);
        }

        // GET: Users/Delete/5
        [HttpGet,ActionName(nameof(Delete))]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var user =  this._userService.Retrieve(id);

                return View(user);
            }
            catch
            {
                return NotFound();
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                this._userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
