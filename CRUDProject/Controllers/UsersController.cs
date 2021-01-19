using CRUDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CRUDProject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<UserData> listuser;
            HttpResponseMessage response = Service.WebApiClient.GetAsync("Users").Result;
            listuser = response.Content.ReadAsAsync<IEnumerable<UserData>>().Result;
            return View(listuser);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new UserData());
            else
            {
                HttpResponseMessage response = Service.WebApiClient.GetAsync("Users/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<UserData>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(UserData user)
        {
            if (user.User_Id == 0)
            {
                HttpResponseMessage response = Service.WebApiClient.PostAsJsonAsync("Users", user).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = Service.WebApiClient.PutAsJsonAsync("Users/" + user.User_Id,user).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Service.WebApiClient.DeleteAsync("Users/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}