using System;

namespace Art.Service.User.DTO
{
    /// <summary>
    /// 地区表
    /// </summary>
    public class LocationDTO
    {
        /// <summary>
        /// location id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int? CountryId { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int? ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int? CityId { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsDeleted { get; set; }

    }
    /// <summary>
    /// 实体类UsersDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:30
    /// </summary>
    public class UsersDTO
    {
        /// <summary>
        /// 默认艺术品
        /// </summary>
        public UserWorksDTO DefaultWork { get; set; }

        /// <summary>
        /// 用户ID（自增PK）
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名(邮箱)
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户类型（1普通用户2艺术家3管理员）
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public int? Location { get; set; }
        public LocationDTO LocationInfo { get; set; }

        /// <summary>
        /// 艺术类型
        /// </summary>
        public ArtType ArtType { get; set; }
        /// <summary>
        /// 艺术类型名称
        /// </summary>
        public string ArtTypeName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 删除标识（0未删除 1删除）
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long HotCount { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }
    }

    /// <summary>
    /// 查询对象类UsersQueryDTO 。(属性说明自动提取数据库字段的描述信息)
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:30
    /// </summary>
    public class UsersQueryDTO
    {
        /// <summary>
        /// 用户状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        /// 是否删除，默认为false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType? UserType { get; set; }

        /// <summary>
        /// 艺术类型(关联表ArtType)
        /// </summary>
        public ArtType? ArtType { get; set; }

        public string OrderBy { get; set; }
    }
}