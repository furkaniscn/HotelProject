using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        private readonly IBookingService _bookingservice;
        public BookingController(IBookingService bookingservice)
        {
            _bookingservice = bookingservice;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingservice.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingservice.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingservice.TGetById(id);
            _bookingservice.TDelete(values);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingservice.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingservice.TGetById(id);
            return Ok(values);
        }
        [HttpPut("UpdateReservation")]
        public IActionResult UpdateReservation(Booking booking)
        {
            _bookingservice.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpPut("UpdateReservation2")]
        public IActionResult UpdateReservation2(int id)
        {
            _bookingservice.TBookingStatusChangeApproved2(id);
            return Ok();
        }
    }
}
