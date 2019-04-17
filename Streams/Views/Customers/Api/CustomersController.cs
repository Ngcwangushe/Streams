using Streams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Streams.Dtos;
using AutoMapper;

namespace Streams.Views.Customers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        //()Method <>deligate reference to the Method

        //GET /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault();
            if(customer==null)
                return  NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomers( CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto );

        }

        //POST /api/customers
        [HttpPut]
        public void UpdateCustomers(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(m=>m.Id== id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            
            _context.SaveChanges();

        }

        //DELETE /api/customers
        [HttpDelete]
        public void DeleteCustomers(Customer customer, int id)
        {
          
            var customerInDb = _context.Customers.SingleOrDefault(m => m.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }

    }
}
