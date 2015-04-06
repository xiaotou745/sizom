using System.Collections.Generic;
using Art.Service.Topic.DTO;
using AC.Page;

namespace Art.Service.Topic
{
    /// <summary>
    /// ҵ���߼���ITopicService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:51:52
    /// </summary>
    public interface ITopicService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="topicDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(TopicDTO topicDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="topicDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(TopicDTO topicDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int topicId);

        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        TopicDTO GetById(int topicId);

        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<TopicDTO> Query(TopicQueryDTO topicQueryDTO);

        IPagedList<TopicDTO> QueryPaged(TopicQueryDTO queryInfo, Paginator pager);
    }
}