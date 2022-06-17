using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmCentralWebApp.Models
{
    //---------- CODE ATTRIBUTION ----------
    //Author: C# Code Academy
    //Published Date: 21 October 2018
    //Title: Create Login Page in Asp.net (MVC 5 & SQL Server)
    //URL: https://youtu.be/-860xZK5mRg

    //Farmer Model that checks farmer inputs registered in database
    public class FarmerAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    //---------- CODE ATTRIBUTION ENDS ----------
}