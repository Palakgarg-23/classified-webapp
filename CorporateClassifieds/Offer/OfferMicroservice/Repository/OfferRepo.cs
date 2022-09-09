using OfferMicroservice.Infrastructure;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferMicroservice.Repository
{
    public class OfferRepo : IOffer
    {
        private static List<Offer> offers;
        public OfferRepo()
        {
            offers = new List<Offer>
            {

                 new Offer { EmployeeId=2159447,OfferId = 1, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate =new DateTime(2022,07,28), Details="Apple iPhone 13 Pro Max",ClosedDate=new DateTime(2022,08,02),EngagedDate=new DateTime(2022,08,01)},

                 new Offer { EmployeeId=2142912,OfferId = 2, Status = "Engaged", Likes = 55, Category = "Electronics", OpenedDate = new DateTime(2022,07,20),ClosedDate=new DateTime(2022,07,29) , Details="IFB Washing Machine",EngagedDate=new DateTime(2022,07,30)},

                 new Offer { EmployeeId=2144009,OfferId = 3, Status = "Engaged", Likes = 20, Category = "Pets", OpenedDate = new DateTime(2022,07,21),ClosedDate=new DateTime(2022,07,23) , Details="Golden Retriever for Adoption",EngagedDate=new DateTime(2022,07,23)},

                 new Offer { EmployeeId=2159071,OfferId = 4, Status = "Available", Likes = 25, Category = "Electronics", OpenedDate = new DateTime(2022,07,30),ClosedDate=new DateTime(2022,08,02) , Details="Samsung Galaxy S20",EngagedDate=new DateTime(2022,08,01)},

                 new Offer { EmployeeId=2141156,OfferId = 5, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate = new DateTime(2022,07,09),ClosedDate=new DateTime(2022,07,15) , Details="HP Laptop",EngagedDate=new DateTime(2022,07,13)},

                 new Offer { EmployeeId=2142922,OfferId = 6 ,Status = "Engaged", Likes = 24, Category = "Books", OpenedDate = new DateTime(2022,07,15),EngagedDate=new DateTime(2022,07,25), ClosedDate=new DateTime(2022,07,23),Details="Wings Of Fire"},

                 new Offer {EmployeeId=2141156,OfferId = 7, Status = "Available", Likes = 25, Category = "Pets", OpenedDate =new DateTime(2022,07,18), Details="German Shepherd for Adoption",ClosedDate=new DateTime(2022,07,21),EngagedDate=new DateTime(2022,07,19)},

                 new Offer { EmployeeId=2159071,OfferId = 8, Status = "Engaged", Likes = 30, Category = "Electronics", OpenedDate = new DateTime(2022,07,04),ClosedDate=new DateTime(2022,07,06) , Details="Epson Printer",EngagedDate=new DateTime(2022,07,05)},

                 new Offer { EmployeeId=2159447,OfferId = 9, Status = "Engaged", Likes = 47, Category = "Furniture", OpenedDate = new DateTime(2022,07,11),ClosedDate=new DateTime(2022,07,21) , Details="Sofa Set",EngagedDate=new DateTime(2022,08,20)},

                 new Offer { EmployeeId=2142912,OfferId = 10, Status = "Closed", Likes = 18, Category = "Books", OpenedDate = new DateTime(2022,06,21),EngagedDate=new  DateTime(2022,06,23), ClosedDate=new DateTime(2022,07,05),Details="Harry Potter Books"},


            };
        }
        public Offer Edit(Offer updatedOffer)
        {
            Offer offer = offers.FirstOrDefault(c => c.OfferId == updatedOffer.OfferId && c.EmployeeId == updatedOffer.EmployeeId);
            return offer;
        }

        public Offer Engage(int offerId)
        {
            Offer offer = offers.FirstOrDefault(c => c.OfferId == offerId);
            return offer;
        }

        public Offer Like(int offerId)
        {
            Offer offer = offers.FirstOrDefault(c => c.OfferId == offerId);
            return offer;
        }

        public IEnumerable<Offer> OfferByCategory(string category)
        {
            var offer = from c in offers where c.Category == category select c;
            return offer;
        }

        public Offer OfferById(int id)
        {
            var offer = offers.FirstOrDefault(c => c.OfferId == id);
            return offer;
        }

        public IEnumerable<Offer> OfferByOpenedDate(string openedDate)
        {
            var offer = from c in offers where c.OpenedDate.ToString("dd-MM-yyyy") == openedDate select c;
            return offer;
        }

        public IEnumerable<Offer> OfferByTopThreeLikes()
        {
            var offer = (from c in offers where 1 == 1 orderby c.Likes descending select c).Take(3);
            return offer;
        }


        public IEnumerable<Offer> Post(Offer newOffer)
        {
           
                offers.Add(newOffer);
           

            return offers;
        }
        public IEnumerable<Offer> OfferList()
        {
            return offers;
        }
    }
}
