using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory.TestData.Model
{
    /// <summary>
    /// Contains text related data.
    /// </summary>
    public interface ITextWidget : IWidget
    {
        /// <summary>
        /// Gets the text for this widget.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        string Text { get; }
    }

    /// <summary>
    /// Simple implementation of the <see cref="ITextWidget"/>.
    /// </summary>
    public class TextWidget : ITextWidget
    {
        #region ITextWidget Members

        public string Text { get; set; }

        #endregion
    }
}
