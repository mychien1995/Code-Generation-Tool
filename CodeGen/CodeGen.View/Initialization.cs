using CodeGen.Engine.Loaders;
using CodeGen.Engine.Translators;
using CodeGen.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.View
{
    public static class Initialization
    {
        public static void Initialize()
        {
            ServiceLocator.Initialize();
            ServiceLocator.RegisterType<IDatabaseLoader, DatabaseLoader>();
            ServiceLocator.RegisterType<ITemplateLoader, TemplateLoader>();
            ServiceLocator.RegisterType<ITemplateTranslator, TemplateTranslator>();
        }
    }
}
