using System.ComponentModel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using AGL.Pets.Contract.Interfaces;
using AGL.Pets.Main.Data;
using AGL.Pets.Main.DataContext;
using AGL.Pets.Main.Repositories;

namespace AGL.Pets.Repository
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Castle.MicroKernel.Registration.Component.For<IPersonRepository>().ImplementedBy<PersonRepository>());
#if DEBUG
            container.Register(Castle.MicroKernel.Registration.Component.For<IDataContext>().ImplementedBy<FakeDataContext>());
#else
            container.Register(Component.For<IDataContext>().ImplementedBy<DataContext>());
#endif
        }
    }
}
