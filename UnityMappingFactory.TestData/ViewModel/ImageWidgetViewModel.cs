using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.Model;

namespace UnityMappingFactory.TestData.ViewModel
{
    /// <summary>
    /// Contains everything neccessary to display an <see cref="IImageWidget"/> on screen.
    /// </summary>
    public interface IImageWidgetViewModel : IWidgetViewModel
    {
        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        string ImageURL { get; }
    }

    /// <summary>
    /// Simple implementation of the <see cref="IImageWidgetViewModel"/>.
    /// </summary>
    public class ImageWidgetViewModel : WidgetViewModel, IImageWidgetViewModel
    {
        public string ImageURL { get; private set; }

        public ImageWidgetViewModel(IImageWidget imageWidget)
            : base(imageWidget)
        {
            //specific mapping here...
            this.ImageURL = imageWidget.SourceLocation;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.ImageURL;
        }
    }
}
