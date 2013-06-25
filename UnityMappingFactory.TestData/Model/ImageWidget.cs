using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory.TestData.Model
{
    /// <summary>
    /// Contains image related data.
    /// </summary>
    public interface IImageWidget : IWidget
    {
        /// <summary>
        /// Gets the source location of the image.
        /// </summary>
        /// <value>
        /// The source location.
        /// </value>
        string SourceLocation { get; }
    }

    /// <summary>
    /// Simple implementation of the <see cref="IImageWidget"/>.
    /// </summary>
    public class ImageWidget : IImageWidget
    {
        #region IImageWidget Members

        public string SourceLocation { get; set; }

        #endregion
    }
}
