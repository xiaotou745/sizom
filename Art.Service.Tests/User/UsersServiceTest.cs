using AC.SpringUtils;
using Art.Service.User;
using Common.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Service.Tests.User
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class UsersServiceTest
    {
        private IUsersService usersService;
        private static readonly ILog logger = LogManager.GetCurrentClassLogger();
        public void SetUpFixture()
        {
            ServiceLocator.Init();
            usersService = ServiceLocator.GetService<IUsersService>();
        }
        [Test]
        public void GetByIdTest()
        {
            var user = usersService.GetById(1);
            Assert.IsNotNull(user);
        }
    }
}
