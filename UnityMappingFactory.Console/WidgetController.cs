using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityMappingFactory.TestData.DataAccess;
using UnityMappingFactory.TestData.Model;
using UnityMappingFactory.TestData.ViewModel;

namespace UnityMappingFactory
{
    /// <summary>
    /// Mock of a MVC Controller
    /// </summary>
    public interface IWidgetController
    {
        /// <summary>
        /// Mock of MVC Controller Action that shows some widgits.
        /// </summary>
        /// <param name="containerId">The container id.</param>
        void ShowWidgits(int? containerId);
    }

    /// <summary>
    /// Mock implementation of a MVC Controller
    /// </summary>
    public class WidgetController : IWidgetController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFactory<IWidgetContainer, IWidgetContainerViewModel> _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetController"/> class.
        /// </summary>
        /// <param name="unitOfWork">Inject the unit of work for data access.</param>
        /// <param name="factory">Inject the factory that will create the neccessary ViewModel from the Model.</param>
        public WidgetController(IUnitOfWork unitOfWork, IFactory<IWidgetContainer, IWidgetContainerViewModel> factory)
        {
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public void ShowWidgits(int? containerId)
        {
            IWidgetContainer container = null;
            if (containerId.HasValue)
                container = _unitOfWork.WidgetRepository.Find(containerId.Value);

            IWidgetContainerViewModel viewModel = _factory.Create(container);
        }
    }
}
