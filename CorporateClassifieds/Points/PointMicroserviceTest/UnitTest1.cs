using NUnit.Framework;
using PointsMicroservice.Repository;

namespace PointMicroserviceTest
{
    public class Tests
    {
        private LikeRepo pointRepo;
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void LikeInTwoDaysCountTest()
        //{
        //    pointRepo = new LikeRepo();
        //    var date = System.DateTime(2022, 05, 01);
        //    var result = pointRepo.LikeInTwoDaysCount(1, System.DateTimeKind(2022, 05, 01));
        //    Assert.Pass();
        //}
        [Test]
        public void EmployeeIdTest()
        {
            pointRepo = new LikeRepo();
            var result=pointRepo.PointsByEmployeeId(2159447);
            Assert.IsNotNull(result);
        }

        [Test]
        public void PointsByEmployeeIdTest()
        {
            pointRepo = new LikeRepo();
            var result = pointRepo.PointsByEmployeeId(2159447);
            Assert.AreEqual(34,result.TotalPoints);
        }

    }
}