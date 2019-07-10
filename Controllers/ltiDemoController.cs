using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ltidemo.lib;

namespace ltidemo.Controllers
{
    public class ltiDemoController : Controller
    {
        // GET: ltiDemo
        public ActionResult Index()
        {
			//parse all of the form variables received in the launch request, 
			// this is when we receive the lti and oauth variables, during the launch request
			//IMPORTANT NOTE:
			//if this is not a launch requst from Canvas, there will be no lti or oauth variables!
			clsLtiParams ltiParms = new clsLtiParams(Request.Form);

			//validate the oauth signature, throw exception if validation fails
			string oauth_signature = string.Empty;
			ltiParms.ltiParams.TryGetValue("oauth_signature", out oauth_signature);
			if (LtiLibrary.Core.OAuth.OAuthUtility.GenerateSignature(Request.HttpMethod, Request.Url, Request.Form, clsLtiParams.SharedSecret) != oauth_signature)
				throw new HttpException("Authentication Error: OAuth Failed");

			return View();	
        }

		public ActionResult Welcome(string name = "LTI Launch", int numTimes = 1)
		{
			//parse all of the form variables received in the launch request, 
			// this is when we receive the lti and oauth variables, during the launch request
			//IMPORTANT NOTE:
			//if this is not a launch requst from Canvas, there will be no lti or oauth variables!
			clsLtiParams ltiParms = new clsLtiParams(Request.Form);

			//validate the oauth signature, throw exception if validation fails
			string oauth_signature = string.Empty;
			ltiParms.ltiParams.TryGetValue("oauth_signature", out oauth_signature);
			if (ltiParms.ltiParams["oauth_signature"] == null || LtiLibrary.Core.OAuth.OAuthUtility.GenerateSignature(Request.HttpMethod, Request.Url, Request.Form, clsLtiParams.SharedSecret) != oauth_signature)
				throw new HttpException("Authentication Error: OAuth Failed");

			ViewBag.Message = "Hello " + name;
			ViewBag.NumTimes = numTimes;
			return View();
		}
    }
}