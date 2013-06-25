using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.Model;

namespace UnityMappingFactory.TestData.ViewModel
{
    /// <summary>
    /// Continues the interface hierarchy.
    /// </summary>
    public interface IWidgetViewModel : IViewModel
    {
    }

    /// <summary>
    /// Simple implementation of the <see cref="IWidgetViewModel"/>.
    /// </summary>
    public abstract class WidgetViewModel : IWidgetViewModel
    {
        protected WidgetViewModel(IWidget widget)
        {
            //any shared mapping can happen here...
        }
    }
}
