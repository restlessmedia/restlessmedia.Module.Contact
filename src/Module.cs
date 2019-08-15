using Autofac;
using restlessmedia.Module.Contact.Data;

namespace restlessmedia.Module.Contact
{
  public class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      containerBuilder.RegisterType<ContactDataProvider>().As<IContactDataProvider>().SingleInstance();
      containerBuilder.RegisterType<ContactService>().As<IContactService>().SingleInstance();
    }
  }
}