﻿using System;
using Facebook;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }
      
        private Uri RediredtUri

        {

            get

            {

                var uriBuilder = new UriBuilder(Request.Url);

                uriBuilder.Query = null;

                uriBuilder.Fragment = null;

                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;

            }

        }


        [AllowAnonymous]

        public ActionResult Facebook()

        {

            var fb = new FacebookClient();

            var loginUrl = fb.GetLoginUrl(new

            {


                client_id = "947711432780088",

                client_secret = "84eb99bcb39da64b0952788fe2df996b",

                redirect_uri = RediredtUri.AbsoluteUri,

                response_type = "code",

                scope = "email"



            });
            return Redirect(loginUrl.AbsoluteUri);


        }


        public ActionResult FacebookCallback(string code)

        {

            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = "947711432780088",

                client_secret = "84eb99bcb39da64b0952788fe2df996b",

                redirect_uri = RediredtUri.AbsoluteUri,

                code = code




            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");

            string email = me.email;

            TempData["email"] = me.email;

            TempData["first_name"] = me.first_name;

            TempData["lastname"] = me.last_name;

            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("About","Home");

        }
     }
    }