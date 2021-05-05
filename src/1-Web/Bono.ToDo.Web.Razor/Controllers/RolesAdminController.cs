
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Data.Entity;
//using System.Threading.Tasks;
//using System.Threading;
//using System.Net;
//using Microsoft.AspNet.Identity;
//using Vibbra.ToDo.Presentation.Web.ViewModels;
//using Vibbra.ToDo.Infrastructure.CrossCutting.Identity.Model;
//using Vibbra.ToDo.Infrastructure.CrossCutting.Identity.Configuration;
//using Vibbra.ToDo.Domain.Entities;

//namespace  Vibbra.ToDo.Presentation.Web.Controllers
//{
//    [Authorize(Roles = Role.ADMIN_ROLE)]
//    public class RolesAdminController : BaseController
//    {
//        protected readonly ApplicationUserManager userManager;

//        protected readonly ApplicationRoleManager roleManager;

//        public RolesAdminController(ApplicationUserManager UserManager, ApplicationRoleManager RoleManager)
//        {
//            this.userManager = UserManager;
//            this.roleManager = RoleManager;
//        }

//        //
//        // GET: /Roles/
//        public ActionResult Index()
//        {
//            return View(roleManager.Roles);
//        }

//        //
//        // GET: /Roles/Details/5
//        public async Task<ActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            var role = await roleManager.FindByIdAsync(id);
//            return View(role);
//        }

//        //
//        // GET: /Roles/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /Roles/Create
//        [HttpPost]
//        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                var role = new ApplicationRole(roleViewModel.Name, roleViewModel.Name);
//                var roleresult = await roleManager.CreateAsync(role);
//                if (!roleresult.Succeeded)
//                {
//                    ModelState.AddModelError("", roleresult.Errors.First().ToString());
//                    return View();
//                }
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return View();
//            }
//        }

//        //
//        // GET: /Roles/Edit/Admin
//        public async Task<ActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            var role = await roleManager.FindByIdAsync(id);
//            if (role == null)
//            {
//                return HttpNotFound();
//            }
//            return View(role);
//        }

//        //
//        // POST: /Roles/Edit/5
//        [HttpPost]

//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] ApplicationRole role)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = await roleManager.UpdateAsync(role);
//                if(!result.Succeeded)
//                {
//                    ModelState.AddModelError("", result.Errors.First().ToString());
//                    return View();   
//                }
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return View();
//            }
//        }

//        //
//        // GET: /Roles/Delete/5
//        public async Task<ActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            var role = await roleManager.FindByIdAsync(id);
//            if (role == null)
//            {
//                return HttpNotFound();
//            }
//            return View(role);
//        }

//        //
//        // POST: /Roles/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(string id)
//        {
//            if (ModelState.IsValid)
//            {
//                if (id == null)
//                {
//                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//                }
//                var role = await roleManager.FindByIdAsync(id);
//                var result = await roleManager.DeleteAsync(role);
//                if (!result.Succeeded)
//                {
//                    ModelState.AddModelError("", result.Errors.First().ToString());
//                    return View();
//                }
//                return RedirectToAction("Index");
//            }
//            else
//            {
//                return View();
//            }
//        }
//    }
//}
