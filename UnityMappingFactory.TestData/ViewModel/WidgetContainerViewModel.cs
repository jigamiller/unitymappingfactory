using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.Model;

namespace UnityMappingFactory.TestData.ViewModel
{
    /// <summary>
    /// Contains a collection of widget view models.
    /// </summary>
    public interface IWidgetContainerViewModel
    {
        /// <summary>
        /// Gets the widget view models.
        /// </summary>
        /// <value>
        /// The widget view models.
        /// </value>
        ObservableCollection<IWidgetViewModel> WidgetViewModels { get; }
    }

    /// <summary>
    /// Simple implementation of the <see cref="IWidgetContainerViewModel"/>.
    /// </summary>
    public class WidgetContainerViewModel : IWidgetContainerViewModel
    {
        public ObservableCollection<IWidgetViewModel> WidgetViewModels { get; private set; }

        public WidgetContainerViewModel(IWidgetContainer widgetContainer, IFactory<IWidget, IWidgetViewModel> factory)
        {
            this.WidgetViewModels = new ObservableCollection<IWidgetViewModel>();
            foreach (var w in widgetContainer.Widgets)
                this.WidgetViewModels.Add(factory.Create(w));
 
            //Write to console to see widgets
            foreach (var wvm in this.WidgetViewModels)
                Console.WriteLine(wvm);
        }
    }
}
