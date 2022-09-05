using Model;

namespace Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestNameOnCreate()
        {
            Person person = new Person("JOE");
            Assert.AreEqual(person.Name, "Joe");
        }

        [TestMethod]
        public void TestNameOnSet()
        {
            Person person = new Person();
            person.Name = "JOE";
            Assert.AreEqual(person.Name, "Joe");
        }
    }
}