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
    /// 实体类NewsDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public class NewsDTO
    {
        /// <summary>
        /// 资讯ID
        /// </summary>
        public int NewsId { get; set; }

        /// <summary>
        /// 新闻类型
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
    /// 查询对象类NewsQueryDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    public class NewsQueryDTO
    {
        public bool IsDeleted { get; set; }
        public string OrderBy { get; set; }
    }
}