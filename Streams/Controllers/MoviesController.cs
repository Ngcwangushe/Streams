using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Streams.Models;
using Streams.ViewModels;

namespace Streams.Controllers
{
    public class MoviesController : Controller
    {
       private ApplicationDbContext _context;//DbContext to access the database
        public MoviesController()
        {//Initialise dbContext with a constructor
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ViewResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList();
            if (User.IsInRole("CanManageMovies"))

                return View("List", movie);
            
            return View("ReadOnlyList", movie);         
        }
       
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);//Sing record from db
            if (movie == null)
                return HttpNotFound();
            //Set/initialize Ecapsulateing objects
            var viewModel = new MovieFormViewModel(movie)
            {
               
                Genres = _context.Genres.ToList()//Initialize membershiptypes--get from db
            };
            return View("MovieForm", viewModel/*pass viewModel to this view*/);//Override default view convention--not Edit
        }

        //get single item from the list of items
        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id) ;//Get items from the database
            //if (customer == null)
              //  return HttpNotFound();
            return View(customer);
        }
        /*
         Save to Data base
         
             
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie/*Model binding*/)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {  
                    Genres = _context.Genres.ToList()
                };
                
                return View("MovieForm", viewModel /*pass viewModel to this view*/); //Override default view convention--not Edit
            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);// Not inthe databse yet-Inthe memory
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == movie.Id);//Get from db--create database object
                //----------------------------------------------
                //assigni ts properties
                customerInDb.Name = movie.Name;
                customerInDb.ReleaseDate = movie.ReleaseDate;
                customerInDb.GenreId = movie.GenreId;
                customerInDb.NumberInStock = movie.NumberInStock;

                //TryUpdateModel(customerInDb, "", new string [] {"Name", "Email"});
                //--update properties base on key value pears in request data/ flord(Changes everything)
            }

        _context.SaveChanges();//persist the changes-all or noting //change tracking mechanism(in DbContext)
        //DbContext go through all modified statements-generate sql statements on runtime
        //and run them on the database--
        return RedirectToAction("Index", "Movies");
    }
    /*
      [HttpPost]
     public ActionResult Save(Movie movie)
     {
         if (!ModelState.IsValid)
         {
             var viewModel = new MovieFormViewModel(movie)
             {
                 Genres = _context.Genres.ToList()
             };

             return View("MovieForm", viewModel);
         }

         if (movie.Id == 0)
         {
             movie.DateAdded = DateTime.Now;
             _context.Movies.Add(movie);
         }
         else
         {
             var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
             movieInDb.Name = movie.Name;
             movieInDb.GenreId = movie.GenreId;
             movieInDb.NumberInStock = movie.NumberInStock;
             movieInDb.ReleaseDate = movie.ReleaseDate;
         }

         _context.SaveChanges();

         return RedirectToAction("Index", "Movies");
     }
     */




    /*
    public ActionResult Index(int? pageIndex, string sortBy)
    {
        if (!pageIndex.HasValue)
            pageIndex = 1;
        if (String.IsNullOrWhiteSpace(sortBy))
            sortBy = "Name";
        return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
    }

    [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
    public ActionResult ByReleaseDate(int year, int month)
    {
        return Content(year + "/" + month);
    }*/


}
}