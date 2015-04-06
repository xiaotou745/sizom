using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.User;
using Art.Service.User;
using Art.Service.User.DTO;
using AC.Util;

namespace Art.Service.Impl.User
{
    /// <summary>
    /// Service��UserWorksService ��ժҪ˵����
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
        /// ����һ����¼
        /// </summary>
        public int Create(UserWorksDTO userWorksDTO)
        {
            return userWorksDao.Insert(userWorksDTO);
        }

        /// <summary>
        /// �޸�һ����¼
        /// </summary>
        public void Modify(UserWorksDTO userWorksDTO)
        {
            userWorksDao.Update(userWorksDTO);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        public void Remove(int worksId)
        {
            userWorksDao.Delete(worksId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
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
        /// ��ѯ����
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