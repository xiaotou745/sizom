using System.Collections.Generic;
using Art.Service.User.DTO;

namespace Art.Service.User
{
    /// <summary>
    /// ҵ���߼���IUserbackgroundService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public interface IUserbackgroundService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="userbackgroundDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(UserbackgroundDTO userbackgroundDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="userbackgroundDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(UserbackgroundDTO userbackgroundDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int backgroundId);

        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        UserbackgroundDTO GetById(int backgroundId);

        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<UserbackgroundDTO> Query(UserbackgroundQueryDTO userbackgroundQueryDTO);
    }
}