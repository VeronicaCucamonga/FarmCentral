using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmCentralWebApp.Models;
using System.Data.SqlClient;

namespace FarmCentralWebApp.Controllers
{
    //---------- CODE ATTRIBUTION ----------
    //Author: C# Code Academy
    //Published Date: 21 October 2018
    //Title: Create Login Page in Asp.net (MVC 5 & SQL Server)
    //URL: https://youtu.be/-860xZK5mRg

    //Employee controller that logs an employee registered in database
    public class EmployeeAccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: EmployeeAccount
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=LAPTOP-Q7QC0955; database=FarmCentral; integrated security=SSPI ";
        }

        [HttpPost]
        public ActionResult Verify(FarmerAccount acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tblEmployee where username='" + acc.Email + "' and password='" + acc.Password + "';";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
        }
    }
    //---------- CODE ATTRIBUTION ENDS ----------
}