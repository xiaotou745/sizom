using System;

namespace Art.Service.News.DTO
{
    public class NewsType
    {
        public int TypeId { get; set; }

        public string TypeName { get; set; }

        public string TypeClassName { get; set; }
    }
    /// <summary>
    /// ʵ����NewsDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public class NewsDTO
    {
        /// <summary>
        /// ��ѶID
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public NewsType NewsType { get; set; }

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
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsSummary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NewsContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IsDeleted { get; set; }
    }

    /// <summary>
    /// ��ѯ������NewsQueryDTO ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public class NewsQueryDTO
    {
        public bool IsDeleted { get; set; }
        public string OrderBy { get; set; }
    }
}