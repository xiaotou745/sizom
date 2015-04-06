using System.Collections.Generic;
using AC.SpringUtils;
using AC.Util;
using Art.Dao.User;
using Art.Service.User;
using Art.Service.User.DTO;

namespace Art.Service.Impl.User
{
    /// <summary>
    /// Service类UserbackgroundService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    [Spring(ConstructorArgs = "userbackgroundDao:userbackgroundDao")]
    public class UserbackgroundService : IUserbackgroundService
    {
        private readonly UserbackgroundDao userbackgroundDao;

        public UserbackgroundService(UserbackgroundDao userbackgroundDao)
        {
            this.userbackgroundDao = userbackgroundDao;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(UserbackgroundDTO userbackgroundDTO)
        {
            AssertUtils.ArgumentNotNull(userbackgroundDTO, "userbackgroundDTO");
            AssertUtils.Greater(userbackgroundDTO.UserId, 0);

            return userbackgroundDao.Insert(userbackgroundDTO);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(UserbackgroundDTO userbackgroundDTO)
        {
            userbackgroundDao.Update(userbackgroundDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int backgroundId)
        {
            userbackgroundDao.Delete(backgroundId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserbackgroundDTO GetById(int backgroundId)
        {
            return userbackgroundDao.GetById(backgroundId);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<UserbackgroundDTO> Query(UserbackgroundQueryDTO userbackgroundQueryDTO)
        {
            return userbackgroundDao.Query(userbackgroundQueryDTO);
        }
    }
}