using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()  //Viewresult is derived from ActionResult , so you can change this to Viewresult
                                        // Read about Action Result
        //public ViewResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
              Movie = movie,
              Customers =customers
            } ;

            return View(viewModel);  //View is a helper method which is derived from Controller class - 
              
            //More ways to pass data
            //ViewData["Movie"] = movie; // use viewdata is property of controller - viewdictionary - dont use this method
           // return View();
            
            //Viewbag - Dynamic type - introduced in MVC2
            //ViewBag.Movie = movie;




            //return new ViewResult(); is the same thing
            //return Content("Hello World"); --Type of Action result
            //return HttpNotFound(); -- returns 404 error
            //return Emptyresult();
            //return RedirectToAction("Index","Home", new {page =1, sortby = "name"});



        }

        [Route("movies/release/{year}/{month:regex(\\d{4}):range(1,12)}")]  //new way to route - see routingconfig
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }


        public ActionResult Edit(int Id)  //This Id is used in Routerconfig.cs
        {
            return Content("ID = " + Id);
        }

        //movies
        public ActionResult Index(int? pageindex, string sortby) //Make parameters nullable
        {
            if (!pageindex.HasValue)
                pageindex = 1;
            if (String.IsNullOrWhiteSpace(sortby))
                sortby = "Name";
            return Content(String.Format("pageIndex={0}&sortby={1}", pageindex, sortby));


        }

    }
}