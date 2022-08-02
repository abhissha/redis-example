using Autofac;
using example.DIContainer;
using NUnit.Framework;

namespace example.test
{
    [TestFixture]
    public class Tests
    {
        public IContainer container;

        [SetUp]
        public void Setup()
        {
            container = DiContaner.Register();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}