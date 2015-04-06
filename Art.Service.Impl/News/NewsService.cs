using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.News;
using Art.Service.News;
using Art.Service.News.DTO;
using AC.Util;

namespace Art.Service.Impl.News
{
    /// <summary>
    /// Service类NewsService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:31
    /// </summary>
    [Spring(ConstructorArgs = "newsDao:newsDao")]
    public class NewsService : INewsService
    {
        private readonly NewsDao newsDao;

        public NewsService(NewsDao newsDao)
        {
            this.newsDao = newsDao;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(NewsDTO newsDTO)
        {
            return newsDao.Insert(newsDTO);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(NewsDTO newsDTO)
        {
            newsDao.Update(newsDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int newsId)
        {
            newsDao.Delete(newsId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public NewsDTO GetById(int newsId)
        {
            return newsDao.GetById(newsId);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<NewsDTO> Query(NewsQueryDTO newsQueryDTO)
        {
            return newsDao.Query(newsQueryDTO);
        }


        public AC.Page.IPagedList<NewsDTO> QueryPaged(NewsQueryDTO queryInfo, AC.Page.Paginator pager)
        {
            AssertUtils.ArgumentNotNull(queryInfo, "queryInfo");
            AssertUtils.ArgumentNotNull(pager, "pager");
            AssertUtils.ArgumentNotNull(queryInfo.OrderBy, "queryInfo.OrderBy");

            return newsDao.QueryPaged(queryInfo, pager);
        }
    }
}