using Art.Service.News.DTO;
using Art.Service.Topic.DTO;
using Art.Service.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.Web.Models
{
    /// <summary>
    /// 首页模型类
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// 热门艺术品
        /// </summary>
        public IList<UserWorksDTO> HotWorks;

        /// <summary>
        /// 热门艺术家
        /// </summary>
        public IList<UsersDTO> HotArtists;

        /// <summary>
        /// 最新入驻艺术家
        /// </summary>
        public IList<UsersDTO> RecentRegistedArtists;

        /// <summary>
        /// 最新资讯
        /// </summary>
        public IList<NewsDTO> NewsLasted;

        /// <summary>
        /// 最新专题
        /// </summary>
        public IList<TopicDTO> TopicLasted;
    }
}