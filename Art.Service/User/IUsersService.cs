using System.Collections.Generic;
using Art.Service.User.DTO;
using AC.Page;

namespace Art.Service.User
{
    /// <summary>
    /// 业务逻辑类IUsersService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:52
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// 新增一条记录
        ///<param name="usersDTO">要新增的对象</param>
        /// </summary>
        int Create(UsersDTO usersDTO);

        /// <summary>
        /// 修改一条记录
        ///<param name="usersDTO">要修改的对象</param>
        /// </summary>
        void Modify(UsersDTO usersDTO);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        void Remove(int userId);

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        UsersDTO GetById(int userId);

        /// <summary>
        /// 用户名是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool Exists(string userName);

        #region Query methods.
        /// <summary>
        /// 查询方法
        /// </summary>
        IList<UsersDTO> Query(UsersQueryDTO usersQueryDTO);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<UsersDTO> QueryPaged(UsersQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}