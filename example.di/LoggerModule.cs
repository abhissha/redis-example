using Autofac;
using AutofacSerilogIntegration;
using Serilog;
using System;

namespace example.DIContainer
{
    public class LoggerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                                    .WriteTo.Console()
                                    .WriteTo.File("log.txt")
                                    .CreateLogger();
                builder.RegisterLogger();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
