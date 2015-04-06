using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.User;
using Art.Service.User;
using Art.Service.User.DTO;
using AC.Util;

namespace Art.Service.Impl.User
{
    /// <summary>
    /// Service类UserWorksService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    [Spring(ConstructorArgs = "userWorksDao:userWorksDao")]
    public class UserWorksService : IUserWorksService
    {
        private readonly UserWorksDao userWorksDao;

        public UserWorksService(UserWorksDao userWorksDao)
        {
            this.userWorksDao = userWorksDao;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(UserWorksDTO userWorksDTO)
        {
            return userWorksDao.Insert(userWorksDTO);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(UserWorksDTO userWorksDTO)
        {
            userWorksDao.Update(userWorksDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int worksId)
        {
            userWorksDao.Delete(worksId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserWorksDTO GetById(int worksId)
        {
            return userWorksDao.GetById(worksId);
        }

        public IList<UserWorksDTO> GetByUserId(int userId)
        {
            return userWorksDao.GetByUserId(userId);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<UserWorksDTO> Query(UserWorksQueryDTO userWorksQueryDTO)
        {
            return userWorksDao.Query(userWorksQueryDTO);
        }


        public AC.Page.IPagedList<UserWorksDTO> QueryPaged(UserWorksQueryDTO queryInfo, AC.Page.Paginator pager)
        {
            AssertUtils.ArgumentNotNull(queryInfo, "queryInfo");
            AssertUtils.ArgumentNotNull(pager, "pager");
            AssertUtils.ArgumentNotNull(queryInfo.OrderBy, "queryInfo.OrderBy");

            return userWorksDao.QueryPaged(queryInfo, pager);
        }


        public UserWorksDTO GetUserDefaultWork(int userId)
        {
            if (userId <= 0)
            {
                return null;
            }
            return userWorksDao.GetUserDefaultWork(userId);
        }
    }
}