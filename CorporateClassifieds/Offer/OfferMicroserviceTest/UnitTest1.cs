using NUnit.Framework;
using OfferMicroservice.Repository;

namespace OfferMicroserviceTest
{
    public class Tests
    {
        private OfferRepo offerRepo;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EngageTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.Engage(1);
            Assert.IsNotNull(result);
            //Assert.Pass();
        }

        [Test]
        public void LikeTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.Like(1);
            Assert.AreEqual(10,result.Likes);
            //Assert.Pass();
        }

        [Test]
        public void OfferByCategoryTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.OfferByCategory("Electronics");
            Assert.IsNotNull(result);
            //Assert.Pass();
        }

        [Test]
        public void OfferByIdTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.OfferById(1);
            Assert.AreEqual(2159447,result.EmployeeId);
            //Assert.Pass();
        }

        [Test]
        public void OfferByTopThreeLikesTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.OfferByTopThreeLikes();
            Assert.IsNotNull(result);
            //Assert.Pass();
        }

        [Test]
        public void OfferListTest()
        {
            offerRepo = new OfferRepo();
            var result = offerRepo.OfferList();
            Assert.IsNotNull(result);
            //Assert.Pass();
        }


    }
}