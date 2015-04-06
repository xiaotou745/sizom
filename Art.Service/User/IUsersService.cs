using System.Collections.Generic;
using Art.Service.User.DTO;
using AC.Page;

namespace Art.Service.User
{
    /// <summary>
    /// ҵ���߼���IUsersService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:52
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="usersDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(UsersDTO usersDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="usersDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(UsersDTO usersDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int userId);

        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        UsersDTO GetById(int userId);

        /// <summary>
        /// �û����Ƿ��Ѵ���
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool Exists(string userName);

        #region Query methods.
        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<UsersDTO> Query(UsersQueryDTO usersQueryDTO);

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<UsersDTO> QueryPaged(UsersQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}