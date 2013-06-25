using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.Model;

namespace UnityMappingFactory.TestData.DataAccess
{
    /// <summary>
    /// Mock Repository. 
    /// </summary>
    /// <remarks>
    /// See Pattern details: http://msdn.microsoft.com/en-us/library/ff649690.aspx
    /// </remarks>
    public interface IWidgetRepository
    {
        /// <summary>
        /// Finds the widget with the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        IWidgetContainer Find(int id);
    }

    /// <summary>
    /// Mock implementation of a Repository. 
    /// </summary>
    /// <remarks>
    /// See Pattern details: http://msdn.microsoft.com/en-us/library/ff649690.aspx
    /// </remarks>
    public class WidgetRepository : IWidgetRepository
    {
        public IWidgetContainer Find(int id)
        {
            return new WidgetContainer();
        }
    }
}
