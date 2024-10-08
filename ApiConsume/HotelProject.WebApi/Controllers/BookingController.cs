﻿using HotelProject.BusinessLayer.Abstract;
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

        [HttpGet("UpdateReservation")]
        public IActionResult UpdateReservation(int id)
        {
            _bookingservice.TBookingStatusChangeApproved(id);
            return Ok();
        }

        [HttpGet("CancelReservation")]
        public IActionResult CancelReservation(int id)
        {
            _bookingservice.TBookingStatusChangeCancel(id);
            return Ok();
        }

        [HttpGet("WaitReservation")]
        public IActionResult WaitReservation(int id)
        {
            _bookingservice.TBookingStatusChangeWait(id);
            return Ok();
        }

        [HttpGet("Last6Booking")]
        public IActionResult Last6Booking()
        {
            var values = _bookingservice.TLast6Booking();
            return Ok(values);
        }
    }
}
