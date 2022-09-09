using Authorization.Controller;
using NUnit.Framework;

namespace AuthorizationTest
{
    public class Test {
        [Test]
        public void GetTest()
        {
                ValuesController valuesController = new ValuesController();
                var result = valuesController.Get();

                Assert.IsNotNull(result);

            }
        [Test]
            public void GetbyidTest()
            {
                ValuesController valuesController = new ValuesController();
                var result = valuesController.Get(2159447);

                Assert.IsNotNull(result);

            }


        }
    }