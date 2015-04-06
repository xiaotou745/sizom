using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.Topic;
using Art.Service.Topic;
using Art.Service.Topic.DTO;
using AC.Page;
using AC.Util;

namespace Art.Service.Impl.Topic
{
    /// <summary>
    /// Service类TopicService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:51:52
    /// </summary>
    [Spring(ConstructorArgs = "topicDao:topicDao")]
    public class TopicService : ITopicService
    {
        private readonly TopicDao topicDao;

        public TopicService(TopicDao topicDao)
        {
            this.topicDao = topicDao;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(TopicDTO topicDTO)
        {
            return topicDao.Insert(topicDTO);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(TopicDTO topicDTO)
        {
            topicDao.Update(topicDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int topicId)
        {
            topicDao.Delete(topicId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TopicDTO GetById(int topicId)
        {
            return topicDao.GetById(topicId);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<TopicDTO> Query(TopicQueryDTO topicQueryDTO)
        {
            return topicDao.Query(topicQueryDTO);
        }

        public IPagedList<TopicDTO> QueryPaged(TopicQueryDTO queryInfo, Paginator pager)
        {
            AssertUtils.ArgumentNotNull(queryInfo, "queryInfo");
            AssertUtils.ArgumentNotNull(pager, "pager");
            AssertUtils.ArgumentNotNull(queryInfo.OrderBy, "queryInfo.OrderBy");

            return topicDao.QueryPaged(queryInfo, pager);
        }
    }
}