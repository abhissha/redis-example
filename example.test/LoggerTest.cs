using Autofac;
using example.DIContainer;
using NUnit.Framework;
using Serilog;

namespace example.test
{
    [TestFixture]
    public class LoggerTest
    {
        public IContainer container;
        public ILogger logger;

        [SetUp]
        public void Setup()
        {
            container = DiContaner.Register();
            logger = container.Resolve<ILogger>();
        }

        [TestFixture]
        internal class log: LoggerTest
        {
            [Test]
            public void Generate_Test()
            {
                logger.Information("I m writing something");
            }
        }
    }    
}