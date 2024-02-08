using Microsoft.Owin.Security.Notifications;
using SignatureBusinessSolutionsWebApp.DTOs;
using SignatureBusinessSolutionsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignatureBusinessSolutionsWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var loggedInUser = User.Identity.Name;

            var userInDb = db.Users
                .FirstOrDefault(x => x.Email == loggedInUser);

            var info = db.Informations
                .FirstOrDefault(x => x.ApplicationUserId == userInDb.Id);

            return View(info);
        }

        [HttpPost]
        public JsonResult Index(InformationModel model)
        {
            try
            {
                var userLoggedIn = User.Identity.Name;

                if (model.CellNo == null || model.AddressLine1 == null || model.PostalAddress1 == null || model.PostalCode == 0)
                {
                    var errorUserInfo = new UserInformationDTO()
                    {
                        StatusCode = 400,
                        StatusTitle = "Error",
                        StatusMessage = "Fields are empty (Cell No., Address 1, Postal Address 1, Postal Code). Try again."
                    };

                    return Json(errorUserInfo, JsonRequestBehavior.DenyGet);
                };

                var successUserInfoDTO = SaveUserInfo(model, userLoggedIn);

                return Json(successUserInfoDTO, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var exceptionUserInfoDTO = new UserInformationDTO()
                {
                    StatusCode = 500,
                    StatusTitle = "Exception",
                    StatusMessage = $"{e.Message}"
                };

                return Json(exceptionUserInfoDTO, JsonRequestBehavior.DenyGet);
            }
        }

        public UserInformationDTO SaveUserInfo(InformationModel model, string user)
        {
            try
            {
                var userInDb = db.Users
                    .FirstOrDefault(x => x.Email == user);

                model.ApplicationUserId = userInDb.Id;

                db.Informations.Add(model);
                db.SaveChanges();

                var successUserInfoDTO = new UserInformationDTO()
                {
                    StatusCode = 200,
                    StatusTitle = "Success",
                    StatusMessage = "User Information saved successfully!"
                };

                return successUserInfoDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}