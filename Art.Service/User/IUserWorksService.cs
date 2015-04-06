using System.Collections.Generic;
using Art.Service.User.DTO;
using AC.Page;

namespace Art.Service.User
{
    /// <summary>
    /// ҵ���߼���IUserWorksService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public interface IUserWorksService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="userWorksDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(UserWorksDTO userWorksDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="userWorksDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(UserWorksDTO userWorksDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int worksId);

        #region Get
        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        UserWorksDTO GetById(int worksId);

        IList<UserWorksDTO> GetByUserId(int userId);

        /// <summary>
        /// ��ȡ�û�Ĭ����Ʒ
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserWorksDTO GetUserDefaultWork(int userId);
        #endregion

        #region Query
        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<UserWorksDTO> Query(UserWorksQueryDTO userWorksQueryDTO);

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<UserWorksDTO> QueryPaged(UserWorksQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}