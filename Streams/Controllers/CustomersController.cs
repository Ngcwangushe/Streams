using System.Data.Entity; 
using Streams.Models;
using Streams.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Streams.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;//Add  DbContext to access the database
        public CustomersController()
        {//Initialise dbContext with a constructor
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {//proper way to dispose of an object--the override of the base class
            _context.Dispose();
        }
        // GET: Movies
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);         
        }

        
          public ActionResult New()//New Customer
        {
            var membershipTypes = _context.MembershipTypes.ToList();//Get list from db
            var viewModel = new CustomerFormViewModel()//Initialise viewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }


        /*Add customers to database
         1. Add to db context
         2. Save changes
         3.Redirect User
             */
        [HttpPost]//can only post with this action
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer/*Model binding*/)
           {
               if (!ModelState.IsValid)
               {
                  var viewModel = new CustomerFormViewModel()
                    {
                    Customer = customer,//Set customer to this object
                    MembershipTypes = _context.MembershipTypes.ToList()//Initialize membershiptypes--get from db
                    };
                  return View("CustomerForm", viewModel/*pass viewModel to this view*/);//Override default view convention--not Edit
               }

               if (customer.Id == 0)
                _context.Customers.Add(customer);// Not inthe databse yet-Inthe memory
            else
               {
                   var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);//Get from db--create database object
                   //----------------------------------------------
                   //assigni ts properties
                   customerInDb.Name = customer.Name;
                   customerInDb.Birthdate = customer.Birthdate;
                   customerInDb.MembershipTypeId = customer.MembershipTypeId;
                   customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                //TryUpdateModel(customerInDb, "", new string [] {"Name", "Email"});
                //--update properties base on key value pears in request data/ flord(Changes everything)
            }

            _context.SaveChanges();//persist the changes-all or noting //change tracking mechanism(in DbContext)
                                       //DbContext go through all modified statements-generate sql statements on runtime
                                       //and run them on the database--
              return RedirectToAction("Index", "Customers");
          }

          public ActionResult Edit(int id)
          {
              var customer = _context.Customers.SingleOrDefault(c =>c.Id == id);//Sing record from db
              if (customer == null)
                  return HttpNotFound();
              //Set/initialize Ecapsulateing objects
              var viewModel = new CustomerFormViewModel()
              {
                  Customer = customer,//Set customer to this object
                  MembershipTypes = _context.MembershipTypes.ToList()//Initialize membershiptypes--get from db
              };
              return View("CustomerForm", viewModel/*pass viewModel to this view*/);//Override default view convention--not Edit
          }

        //get single item from the list of items
        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id) ;//Get items from the database
            //if (customer == null)
              //  return HttpNotFound();
            return View(customer);
        }


/*
        [HttpPost]
       /// [ValidateAntiForgeryToken]
     
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
*/
        //generate a list of Items
        /*  private IEnumerable<Customer> GetCustomers() {
              return new List<Customer>
              {
                  new Customer { Id = 1, Name = "John Smith"},
                  new Customer { Id = 2, Name = "Mary Williams"}
              };


          }
          
         
         public ActionResult Create(Customer customer)//Model binding
        {
            _context.Customers.Add(customer);// Not inthe databse yet-Inthe memory
            _context.SaveChanges();//persist the changes-all or noting //change tracking mechanism(in DbContext)
            //DbContext go through all modified statements-generate sql statements on runtime
            //and run them on the database--
            return RedirectToAction("Index", "Customer");
        }




         */
    }
}