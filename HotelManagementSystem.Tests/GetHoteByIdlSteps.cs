using HotelManagementSystem.Models;
using System;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetHoteByIdlSteps
    {
        private int _hotelId;
        private Hotel _hotel;
        [Given(@"User has provided a valid hotel Id '(.*)' to be retrieved")]
        public void GivenUserHasProvidedAValidHotelId(int id)
        {
            _hotelId = id;
        }

        [When(@"User calls GetHotelById api")]
        public void WhenUserCallsGetHotelByIdApi()
        {
            _hotel = HotelsApiCaller.GetHotelById(_hotelId);
        }

        [Then(@"Reponse should have the details of hotel with id '(.*)'")]
        public void ThenReponseShouldHaveTheDetailsOfHotelWithId(int id)
        {
            _hotel.Id.Should().Be(id, string.Format("Hotel with Id {0} Not Found!", id));
        }


    }
}
