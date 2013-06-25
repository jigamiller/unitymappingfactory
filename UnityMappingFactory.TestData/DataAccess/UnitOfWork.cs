using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityMappingFactory.TestData.DataAccess
{
    /// <summary>
    /// Mock UnitOfWork. 
    /// </summary>
    /// <remarks>
    /// See Pattern details: http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    /// </remarks>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Mock Repository. See Pattern details: http://msdn.microsoft.com/en-us/library/ff649690.aspx
        /// </summary>
        IWidgetRepository WidgetRepository { get; }
    }

    /// <summary>
    /// Mock implementation of UnitOfWork.
    /// </summary>
    /// <remarks>
    /// See Pattern details: http://msdn.microsoft.com/en-us/magazine/dd882510.aspx
    /// </remarks>
    public class UnitOfWork : IUnitOfWork
    {
        public IWidgetRepository WidgetRepository { get; private set; }

        public UnitOfWork()
        {
            this.WidgetRepository = new WidgetRepository();
        }
    }
}
