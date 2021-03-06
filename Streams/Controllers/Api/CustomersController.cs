﻿using Streams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Streams.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Streams.Customers.Api
{
    public class CustomersController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDto = customersQuery
                .ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDto);
        }

        //()Method <>deligate reference to the Method
        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers
                .SingleOrDefault(c=>c.Id == id);
                
            return Ok(customer);
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
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateCustomers(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(m=>m.Id== id);

            if (customerInDb == null)
                return  NotFound();

            Mapper.Map(customerDto, customerInDb);

            
            _context.SaveChanges();
            return Ok();

        }

        //DELETE /api/customers
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteCustomers(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(m => m.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();

        }

    }
}
