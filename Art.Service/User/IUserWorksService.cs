using System.Collections.Generic;
using Art.Service.User.DTO;
using AC.Page;

namespace Art.Service.User
{
    /// <summary>
    /// 业务逻辑类IUserWorksService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    public interface IUserWorksService
    {
        /// <summary>
        /// 新增一条记录
        ///<param name="userWorksDTO">要新增的对象</param>
        /// </summary>
        int Create(UserWorksDTO userWorksDTO);

        /// <summary>
        /// 修改一条记录
        ///<param name="userWorksDTO">要修改的对象</param>
        /// </summary>
        void Modify(UserWorksDTO userWorksDTO);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        void Remove(int worksId);

        #region Get
        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        UserWorksDTO GetById(int worksId);

        IList<UserWorksDTO> GetByUserId(int userId);

        /// <summary>
        /// 获取用户默认作品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserWorksDTO GetUserDefaultWork(int userId);
        #endregion

        #region Query
        /// <summary>
        /// 查询方法
        /// </summary>
        IList<UserWorksDTO> Query(UserWorksQueryDTO userWorksQueryDTO);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="queryInfo"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        IPagedList<UserWorksDTO> QueryPaged(UserWorksQueryDTO queryInfo, Paginator pager);
        #endregion
    }
}