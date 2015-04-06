using System.Collections.Generic;
using Art.Service.News.DTO;
using AC.Page;

namespace Art.Service.News
{
    /// <summary>
    /// 业务逻辑类INewsService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// 新增一条记录
        ///<param name="newsDTO">要新增的对象</param>
        /// </summary>
        int Create(NewsDTO newsDTO);

        /// <summary>
        /// 修改一条记录
        ///<param name="newsDTO">要修改的对象</param>
        /// </summary>
        void Modify(NewsDTO newsDTO);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        void Remove(int newsId);

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        NewsDTO GetById(int newsId);

        #region Query. Query Paged.
        /// <summary>
        /// 查询方法
        /// </summary>
        IList<NewsDTO> Query(NewsQueryDTO newsQueryDTO);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<NewsDTO> QueryPaged(NewsQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}