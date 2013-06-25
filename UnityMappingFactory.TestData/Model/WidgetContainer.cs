using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory.TestData.Model
{
    /// <summary>
    /// Contains a collection of widgets.
    /// </summary>
    public interface IWidgetContainer
    {
        /// <summary>
        /// The collection of widgets.
        /// </summary>
        /// <value>
        /// The widgets.
        /// </value>
        ICollection<IWidget> Widgets { get; } 
    }

    /// <summary>
    /// Simple implementation of the <see cref="IWidgetContainer"/>.
    /// </summary>
    public class WidgetContainer : IWidgetContainer
    {
        public ICollection<IWidget> Widgets { get; set; }

        public WidgetContainer()
        {
            //Mock up some widgets...
            this.Widgets = new List<IWidget>(new IWidget[] 
            {
                new TextWidget() {Text = "First"},
                new ImageWidget() {SourceLocation = "Second"},
                new TextWidget() {Text = "Third"},
                new TextWidget() {Text = "Fourth"}
            });            
        }
    }
}
