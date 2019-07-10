using System.Collections.Generic;
using System.Collections.Specialized;

namespace ltidemo.lib
{
	public class clsLtiParams
	{
		public Dictionary<string, string> ltiParams = new Dictionary<string, string>();
		public static string ConsumerKey = (System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"] != null) ? System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"].ToString() : "DefaultConsumerKey";
		public static string SharedSecret = (System.Configuration.ConfigurationManager.AppSettings["SharedSecret"] != null) ? System.Configuration.ConfigurationManager.AppSettings["SharedSecret"].ToString() : "DefaultSharedSecret";

		public clsLtiParams()
		{		
		}

		public clsLtiParams(NameValueCollection vars)
		{
			if(vars != null && vars.Count > 0)
			{
				foreach(string key in vars.Keys)
				{
					ltiParams.Add(key, vars[key]);
				}
			}
		}

	}
}