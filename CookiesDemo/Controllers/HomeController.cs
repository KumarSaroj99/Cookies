using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Web;
using System.Web.Mvc;

namespace CookiesDemo.Controllers
{
    

    
        public class HomeController : Controller
        {
            // Action to create a cookie
            public ActionResult CreateCookie()
            {
                // Create a cookie
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["UserName"] = "John Doe";
                cookie["Email"] = "john.doe@example.com";

                // Set cookie expiration time
                cookie.Expires = DateTime.Now.AddDays(1);

                // Add the cookie to the response
                Response.Cookies.Add(cookie);

                ViewBag.Message = "Cookie Created Successfully!";
                return View();
            }

            // Action to read the cookie
            public ActionResult ReadCookie()
            {
                // Read the cookie from the request
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    ViewBag.UserName = cookie["UserName"];
                    ViewBag.Email = cookie["Email"];
                }
                else
                {
                    ViewBag.Message = "No Cookie Found!";
                }

                return View();
            }

            // Action to delete the cookie
            public ActionResult DeleteCookie()
            {
                HttpCookie cookie = Request.Cookies["UserInfo"];
                if (cookie != null)
                {
                    // Set the cookie's expiration date to a past date to remove it
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);

                    ViewBag.Message = "Cookie Deleted Successfully!";
                }
                else
                {
                    ViewBag.Message = "No Cookie Found!";
                }

                return View();
            }
        }
    }

