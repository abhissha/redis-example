using Autofac;
using example.DIContainer;

namespace example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DiContaner.AddRegistration<Application>();
            DiContaner.AddRegistration<MediaTrApplication>();
            var container = DiContaner.Register();
           // container.Resolve<Application>().Run();                      
            //container.Resolve<MediaTrApplication>().Run();
        }
    }
}
