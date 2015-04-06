using System.Collections.Generic;
using Art.Service.News.DTO;
using AC.Page;

namespace Art.Service.News
{
    /// <summary>
    /// ҵ���߼���INewsService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="newsDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(NewsDTO newsDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="newsDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(NewsDTO newsDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int newsId);

        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        NewsDTO GetById(int newsId);

        #region Query. Query Paged.
        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<NewsDTO> Query(NewsQueryDTO newsQueryDTO);

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<NewsDTO> QueryPaged(NewsQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}