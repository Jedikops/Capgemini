using Capgemini.Controllers;
using Capgemini.Controllers.API;
using Capgemini.Tests.FakeClasses;
using System;

namespace Capgemini.Tests.XUnit.Fixtures
{
    public class ControllersFixture : IDisposable
    {
        #region Declarations 

        private FakeDataManager _dm;
        private CustomersController _customerApiController;
        private HomeController _homeController;

        #endregion

        #region Properties

        public CustomersController CustomerApiController
        {
            get
            {
                if (_customerApiController == null)
                    _customerApiController = new CustomersController(_dm);
                return _customerApiController;
            }
        }
        public HomeController HomeController
        {
            get
            {
                if (_homeController == null)
                    _homeController = new HomeController(new FakeDataManager());
                return _homeController;

            }
        }

        #endregion

        public ControllersFixture()
        {
            _dm = new FakeDataManager();
        }
        public void Dispose()
        {
            if (_customerApiController != null)
                _customerApiController.Dispose();

            if (_homeController != null)
                _homeController.Dispose();
        }
    }
}
