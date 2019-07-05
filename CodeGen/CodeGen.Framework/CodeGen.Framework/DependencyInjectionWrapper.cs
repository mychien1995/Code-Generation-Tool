using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace CodeGen.Framework
{
    public class ServiceLocator
    {
        private static UnityContainer _container;

        public static T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }

        public static void RegisterType<TAbstract, TImplement>() where TImplement : TAbstract
        {
            _container.RegisterType<TAbstract, TImplement>();
        }

        public static void RegisterType<TInterface>()
        {
            _container.RegisterType<TInterface>();
        }

        public static void RegisterSingleton<T>()
        {
            _container.RegisterSingleton<T>();
        }

        public static void RegisterInstance<T>(T t)
        {
            _container.RegisterInstance<T>(t);
        }

        public static void Initialize()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
            }
        }
    }
}
