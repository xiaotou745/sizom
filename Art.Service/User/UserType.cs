using System.ComponentModel;

namespace Art.Service.User
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        [Description("普通用户")]
        Normal = 1,

        /// <summary>
        /// 艺术家
        /// </summary>
        [Description("艺术家")]
        Artist = 2,

        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin = 3,
    }
}