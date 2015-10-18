namespace Sitecore.SharedSource.Mvc.CastleWindsor
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using System;

    public static class Container
    {
        private static IWindsorContainer container = new WindsorContainer();

        public static IWindsorContainer InnerContainer
        {
            get
            {
                return container;
            }
        }

        public static void Register(params IRegistration[] registrations)
        {
            container.Register(registrations);
        }

        public static void Release(object instance)
        {
            container.Release(instance);
        }

        public static object Resolve(Type service)
        {
            return container.Resolve(service);
            
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static Array ResolveAll(Type service)
        {
            return container.ResolveAll(service);
        }

        public static T[] ResolveAll<T>()
        {
            return container.ResolveAll<T>();
        }
    }
}