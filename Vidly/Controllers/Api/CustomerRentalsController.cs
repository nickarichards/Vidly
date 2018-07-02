using System;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.ViewModels;
using System.Data.Entity;
using System.Web;

namespace Vidly.Controllers.Api
{
    public class CustomerRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomerRentals(int id)
        {           
            var customerRentals = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Where(r => r.Customer.Id == id & r.DateReturned == null)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(customerRentals);
        }

        [HttpPut]
        public IHttpActionResult ReturnMovie(int id)
        {  
            
            var rental = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Single(r => r.Id == id);

            rental.DateReturned = DateTime.Today;

            var movie = _context.Movies.Single(m => m.Id == rental.Movie.Id);
            movie.NumberAvailable++;

            _context.SaveChanges();

            var customerRentals = _context.Rentals
                .Where(r => r.Customer.Id == rental.Customer.Id)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(customerRentals);
        }


    }
}
