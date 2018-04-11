using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace smarttraining
{
    static class User
    {
        public static Profile profile = new Profile();

        public static string Register(string email, string password)
        {
            profile.Resp = XHR.XmlHttpRequest("register.php?email=" + email + "&password=" + password);
            return profile.Resp;
            
        }

        public static string Login(string email, string password)
        {
            profile.U_Key = XHR.XmlHttpRequest("login.php?email=" + email + "&password=" + password, "");
            profile.U_Email = email;
            GetMyProfile();
            return profile.U_Key;
        }
		public static string Logout()
		{
			profile = null;
			return profile.U_Key;
		}
		public static string SecondReg(string fname, string lname, string pname, int sex=0, DateTime dob=default(DateTime), string pno="", string address="")
        {
            profile.Resp = XHR.XmlHttpRequest("secondreg.php?email=" + profile.U_Email
            + "&fname=" + fname + "&lname=" + lname + "pname=" + pname + "&sex=" + sex + "&dob=" + dob.ToString() + "&pno=" + pno +
            "&address=" + address);
            return "wkwkkw";
        }

        public static void GetMyProfile()
        {
            profile = Profile.GetProfile(profile.U_Email,profile.U_Key);
            System.Diagnostics.Debug.WriteLine(profile.U_Email);
        }
    }
}


