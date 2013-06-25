using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using UnityMappingFactory.TestData.DataAccess;
using UnityMappingFactory.TestData.Model;
using UnityMappingFactory.TestData.ViewModel;

namespace UnityMappingFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            try
            {
                container.RegisterType<IUnitOfWork, UnitOfWork>();
                container.RegisterType<IWidgetController, WidgetController>();

                /* Registering ViewModels */

                //Standard ViewModels
                container.RegisterType<IWidgetContainerViewModel, WidgetContainerViewModel>();

                //Control ViewModels
                container.RegisterType<IImageWidgetViewModel, ImageWidgetViewModel>();
                container.RegisterType<ITextWidgetViewModel, TextWidgetViewModel>();


                /* Mapping Model to ViewModel */

                container.RegisterFactory<IWidgetContainer, IWidgetContainerViewModel>().AddDefaultMap();

                container.RegisterFactory<IWidget, IWidgetViewModel>()
                    .AddMap<IImageWidget, IImageWidgetViewModel>()
                    .AddMap<ITextWidget, ITextWidgetViewModel>();

                /* Run Program */

                var controller = container.Resolve<IWidgetController>();
                controller.ShowWidgits(1);

                /* End Program */

                Console.WriteLine();
                Console.WriteLine("Please press any key to continue. . .");
                Console.ReadKey(true);
            }
            finally
            {
                container.Dispose();
            }

        }
    }
}
