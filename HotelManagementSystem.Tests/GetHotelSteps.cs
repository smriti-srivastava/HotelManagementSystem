using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetHotelSteps
    {
        
        List<Hotel> _hotelList;
        private List<int> _addedHotels = AddHotelSteps.AddedIds;

        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            _hotelList = HotelsApiCaller.GetHotels();
        }

        [Then(@"Reponse should have the details of all the hotels added")]
        public void ThenReponseShouldHaveTheDetailsOfHotelsAdded()
        {
           foreach(int id in _addedHotels)
            {
                var hotel = _hotelList.Find(ht => ht.Id == id);
                hotel.Should().NotBeNull(string.Format("Hotel with Id {0} is not present", hotel));
            }
        }
    }
}
