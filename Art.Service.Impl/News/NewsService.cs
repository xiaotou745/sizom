using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.News;
using Art.Service.News;
using Art.Service.News.DTO;
using AC.Util;

namespace Art.Service.Impl.News
{
    /// <summary>
    /// Service��NewsService ��ժҪ˵����
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
        /// ����һ����¼
        /// </summary>
        public int Create(NewsDTO newsDTO)
        {
            return newsDao.Insert(newsDTO);
        }

        /// <summary>
        /// �޸�һ����¼
        /// </summary>
        public void Modify(NewsDTO newsDTO)
        {
            newsDao.Update(newsDTO);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        public void Remove(int newsId)
        {
            newsDao.Delete(newsId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public NewsDTO GetById(int newsId)
        {
            return newsDao.GetById(newsId);
        }

        /// <summary>
        /// ��ѯ����
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