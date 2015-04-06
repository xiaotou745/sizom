using AC.SpringUtils;
using Art.Service.User;
using Common.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Json;

namespace Art.Service.Tests.User
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass()]
    public class UsersServiceTest
    {
        private IUsersService usersService;
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();

        [TestInitialize]
        public void SetUpFixture()
        {
            ServiceLocator.Init();
            usersService = ServiceLocator.GetService<IUsersService>();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var user = usersService.GetById(1);
            logger.Info(JsonSerializer.Serialize(user));
            Assert.IsNotNull(user);
        }

    }
}
