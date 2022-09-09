using EmployeeMicroservice.Repository;
using NUnit.Framework;

namespace EmployeeMicroserviceTest
{
    public class Tests
    {
        private EmployeeRepo empRepo;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetprofileTest()
        {
            empRepo = new EmployeeRepo();
            var result = empRepo.Getprofile(2159447);
            Assert.IsNotNull(result);
            //Assert.Pass();
        }

        [Test]
        public void GetprofileByIdTest()
        {
            empRepo = new EmployeeRepo();
            var result = empRepo.Getprofile(2159447);
            Assert.AreEqual(2159447,result.EmployeeId);
            //Assert.Pass();
        }
    }
}