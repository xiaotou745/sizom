using System;
using System.Collections.Generic;
using AC.SpringUtils;
using AC.Transaction.Common;
using AC.Util;
using Art.Dao;
using Art.Dao.User;
using Art.Service.User;
using Art.Service.User.DTO;
using AC.Page;

namespace Art.Service.Impl.User
{
    /// <summary>
    /// Service类UsersService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:52
    /// </summary>
    [Spring(ConstructorArgs = "usersDao:usersDao;userbackgroundService:userbackgroundService")]
    public class UsersService : IUsersService
    {
        private readonly UsersDao usersDao;
        private readonly IUserbackgroundService userbackgroundService;

        public UsersService(UsersDao usersDao, IUserbackgroundService userbackgroundService)
        {
            this.usersDao = usersDao;
            this.userbackgroundService = userbackgroundService;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(UsersDTO usersDTO)
        {
            AssertUtils.ArgumentNotNull(usersDTO, "usersDTO");
            usersDTO.Location = 1;
            usersDTO.Birthday = DateTime.Now;
            usersDTO.ArtType = ArtType.DangDaiYiShu;
            usersDTO.PicUrl = "img/default/defaultuserpic.png";

            using (IUnitOfWork unitOfWork = SizomUnitOfWorkFactory.GetUnitOfWorkOfSizom())
            {
                var userId = usersDao.Insert(usersDTO);
                usersDTO.UserId = userId;
                UserbackgroundDTO userBackground1 = new UserbackgroundDTO()
                {
                    UserId = userId,
                    ImageUrl = "/img/default/defaultuserbanner.jpg",
                };
                UserbackgroundDTO userBackground2 = new UserbackgroundDTO()
                {
                    UserId = userId,
                    ImageUrl = "/img/default/defaultuserbanner.jpg",
                };
                userbackgroundService.Create(userBackground1);
                userbackgroundService.Create(userBackground2);
                unitOfWork.Complete();
            }

            return usersDTO.UserId;
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(UsersDTO usersDTO)
        {
            usersDao.Update(usersDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int userId)
        {
            usersDao.Delete(userId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersDTO GetById(int userId)
        {
            return usersDao.GetById(userId);
        }

        /// <summary>
        /// 验证用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Exists(string userName)
        {
            AssertUtils.ArgumentNotNull(userName, "userName");

            UsersDTO user = usersDao.GetByLoginName(userName);
            return user != null;
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<UsersDTO> Query(UsersQueryDTO usersQueryDTO)
        {
            return usersDao.Query(usersQueryDTO);
        }


        public AC.Page.IPagedList<UsersDTO> QueryPaged(UsersQueryDTO queryInfo, AC.Page.Paginator pager)
        {
            AssertUtils.ArgumentNotNull(queryInfo, "queryInfo");
            AssertUtils.ArgumentNotNull(pager, "pager");
            AssertUtils.ArgumentNotNull(queryInfo.OrderBy, "queryInfo.OrderBy");

            return usersDao.QueryPaged(queryInfo, pager);
        }
    }
}