using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        public static List<int> AddedIds = new List<int>();
        private List<Hotel> hotels = new List<Hotel>();

        [Given(@"User provided valid Id '(.*)' and '(.*)' for hotel")]
        [Given(@"User provided valid Id '(.*)' and '(.*)' for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }


        [Given(@"User has called AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            if (hotel != null)
            {
                AddedIds.Add(hotel.Id);
            }
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
            
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
