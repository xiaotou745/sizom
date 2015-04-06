namespace Art.Service.User.DTO
{
    /// <summary>
    /// 实体类UserbackgroundDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public class UserbackgroundDTO
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int BackgroundId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 是否删除(0未删除）
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int BgOrder { get; set; }
    }

    /// <summary>
    /// 查询对象类UserbackgroundQueryDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public class UserbackgroundQueryDTO
    {
    }
}