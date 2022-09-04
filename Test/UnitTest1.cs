using Model;
namespace Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Person person = new Person();
        person.Name = "Joe";
        Assert.AreEqual(person.Name, "Joe");
    }
}
