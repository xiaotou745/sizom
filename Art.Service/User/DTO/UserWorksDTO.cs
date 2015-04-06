using System;

namespace Art.Service.User.DTO
{
    /// <summary>
    /// 实体类UserWorksDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public class UserWorksDTO
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int WorksId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FinishTime { get; set; }

        /// <summary>
        /// 艺术品类型(关联表ArtType)
        /// </summary>
        public int WorksType { get; set; }

        /// <summary>
        /// 艺术品类型名称
        /// </summary>
        public string WorksTypeName { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 艺术品图片地址
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorksName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorksDescription { get; set; }

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
        public int Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? WorkSizeHeight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? WorkSizeType { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 热门数量
        /// </summary>
        public long HotCount { get; set; }
    }

    /// <summary>
    /// 查询对象类UserWorksQueryDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public class UserWorksQueryDTO
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// 是否删除，默认为false
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy { get; set; }
    }
}