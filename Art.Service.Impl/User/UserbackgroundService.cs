using System.Collections.Generic;
using AC.SpringUtils;
using AC.Util;
using Art.Dao.User;
using Art.Service.User;
using Art.Service.User.DTO;

namespace Art.Service.Impl.User
{
    /// <summary>
    /// Service��UserbackgroundService ��ժҪ˵����
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
        /// ����һ����¼
        /// </summary>
        public int Create(UserbackgroundDTO userbackgroundDTO)
        {
            AssertUtils.ArgumentNotNull(userbackgroundDTO, "userbackgroundDTO");
            AssertUtils.Greater(userbackgroundDTO.UserId, 0);

            return userbackgroundDao.Insert(userbackgroundDTO);
        }

        /// <summary>
        /// �޸�һ����¼
        /// </summary>
        public void Modify(UserbackgroundDTO userbackgroundDTO)
        {
            userbackgroundDao.Update(userbackgroundDTO);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        public void Remove(int backgroundId)
        {
            userbackgroundDao.Delete(backgroundId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public UserbackgroundDTO GetById(int backgroundId)
        {
            return userbackgroundDao.GetById(backgroundId);
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public IList<UserbackgroundDTO> Query(UserbackgroundQueryDTO userbackgroundQueryDTO)
        {
            return userbackgroundDao.Query(userbackgroundQueryDTO);
        }
    }
}