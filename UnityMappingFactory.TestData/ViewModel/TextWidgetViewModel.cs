using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.Model;

namespace UnityMappingFactory.TestData.ViewModel
{
    /// <summary>
    /// Contains everything neccessary to display an <see cref="ITextWidget"/> on screen.
    /// </summary>
    public interface ITextWidgetViewModel : IWidgetViewModel
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        string Text { get; }
    }

    /// <summary>
    /// Simple implementation of the <see cref="ITextWidgetViewModel"/>.
    /// </summary>
    public class TextWidgetViewModel : WidgetViewModel, ITextWidgetViewModel
    {
        public string Text { get; private set; }

        public TextWidgetViewModel(ITextWidget textWidget)
            : base(textWidget)
        {
            //specific mapping here...
            this.Text = textWidget.Text;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Text;
        }
    }
}
