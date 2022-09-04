using Model;

namespace Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void TestName()
        {
            Person person = new Person("JOE");
            Assert.AreEqual(person.Name, "Joe");
        }
    }
}