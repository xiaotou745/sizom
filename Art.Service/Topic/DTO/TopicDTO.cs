using System;

namespace Art.Service.Topic.DTO
{
    /// <summary>
    /// ʵ����TopicDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:51:52
    /// </summary>
    public class TopicDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TopicType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TopicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }
    }

    /// <summary>
    /// ��ѯ������TopicQueryDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:51:52
    /// </summary>
    public class TopicQueryDTO
    {
        public string OrderBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}