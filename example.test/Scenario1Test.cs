using Autofac;
using example.DIContainer;
using NUnit.Framework;

namespace example.test
{
    [TestFixture]
    public class Scenario1Test
    {
        public IContainer container;

        [SetUp]
        public void Setup()
        {
            DiContaner.AddRegistration<DataGeneratorApplication>();
            container = DiContaner.Register();            
        }

        [TestFixture]
        internal class Generate: Scenario1Test
        {
            [Test]
            public void Generate_Test()
            {
                var dataGeneratorApp = container.Resolve<DataGeneratorApplication>();
                dataGeneratorApp.Get(ScenarioEnum.Scenario1).GenerateData();
            }
        }
    }    
}