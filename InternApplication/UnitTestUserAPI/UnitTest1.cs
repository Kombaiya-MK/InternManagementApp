using UserAPI.Services;

namespace UnitTestUserAPI
{
    public class Tests
    {

        UserRepo _user;
        [SetUp]
        public void Setup()
        {
            _user = new UserRepo();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}