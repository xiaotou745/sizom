using AC.Page;
using AC.SpringUtils;
using Art.Service.News;
using Art.Service.News.DTO;
using Art.Service.Topic;
using Art.Service.Topic.DTO;
using Art.Service.User;
using Art.Service.User.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Common.Services
{
    [Spring(Id = "homeIndexServices", 
        ConstructorArgs = "userService:usersService;userWorksService:userWorksService;topicService:topicService;newsService:newsService")]
    public class HomeIndexServices
    {
        private readonly IUsersService userService;
        private readonly IUserWorksService userWorksService;
        private readonly ITopicService topicService;
        private readonly INewsService newsService;

        public HomeIndexServices(IUsersService userService, IUserWorksService userWorksService, ITopicService topicService, INewsService newsService)
        {
            this.userService = userService;
            this.userWorksService = userWorksService;
            this.topicService = topicService;
            this.newsService = newsService;
        }
        
        /// <summary>
        /// 获取4个最热门艺术家
        /// </summary>
        /// <returns></returns>
        public IList<UsersDTO> GetHotArtists()
        {
            UsersQueryDTO queryInfo = new UsersQueryDTO
            {
                UserType = UserType.Artist,
                IsDeleted = false,
                OrderBy = "HotCount desc",
            };
            Paginator pager = new Paginator
            {
                PageSize = 4,//查询4个
                PageIndex = 1,//第一页
            };

            IPagedList<UsersDTO> pagedUsers = userService.QueryPaged(queryInfo, pager);
            IList<UsersDTO> lstUsers = pagedUsers.ContentList;

            foreach (var user in lstUsers)
            {
                user.DefaultWork = userWorksService.GetUserDefaultWork(user.UserId);
            }
            return lstUsers;
        }
        
        /// <summary>
        /// 获取4个最热门艺术品列表
        /// </summary>
        /// <returns></returns>
        public IList<UserWorksDTO> GetHotWorks()
        {
            UserWorksQueryDTO queryInfo = new UserWorksQueryDTO
            {
                IsDeleted = false,
                OrderBy = "uw.HotCount desc",
            };
            Paginator pager = new Paginator
            {
                PageIndex = 1,
                PageSize = 4,
            };
            var hotWorks = userWorksService.QueryPaged(queryInfo, pager);
            return hotWorks.ContentList;
        }

        /// <summary>
        /// 获取最新的7条新闻资讯
        /// </summary>
        /// <returns></returns>
        public IList<NewsDTO> GetLastedNews()
        {
            NewsQueryDTO queryInfo = new NewsQueryDTO
            {
                IsDeleted = false,
                OrderBy = "CreateTime desc",
            };
            Paginator pager = new Paginator
            {
                PageIndex = 1,
                PageSize = 7,
            };
            var lstNews = newsService.QueryPaged(queryInfo, pager);
            return lstNews.ContentList;
        }

        /// <summary>
        /// 获取最新注册的6个艺术家
        /// </summary>
        /// <returns></returns>
        public IList<UsersDTO> GetRecentRegistedArtist()
        {
            UsersQueryDTO queryInfo = new UsersQueryDTO
            {
                UserType = UserType.Artist,
                IsDeleted = false,
                OrderBy = "CreateTime desc",
            };
            Paginator pager = new Paginator
            {
                PageSize = 6,//查询4个
                PageIndex = 1,//第一页
            };

            IPagedList<UsersDTO> pagedUsers = userService.QueryPaged(queryInfo, pager);
            IList<UsersDTO> lstUsers = pagedUsers.ContentList;

            foreach (var user in lstUsers)
            {
                user.DefaultWork = userWorksService.GetUserDefaultWork(user.UserId);
            }
            return lstUsers;
        }

        /// <summary>
        /// 获取最近的三个专题
        /// </summary>
        /// <returns></returns>
        public IList<TopicDTO> GetLastedTopic()
        {
            TopicQueryDTO queryInfo = new TopicQueryDTO
            {
                IsDeleted = false,
                OrderBy = "CreateTime desc",
            };
            Paginator pager = new Paginator
            {
                PageIndex = 1,
                PageSize = 3,
            };
            var lstTopics = topicService.QueryPaged(queryInfo, pager);
            return lstTopics.ContentList;
        }
    }
}
