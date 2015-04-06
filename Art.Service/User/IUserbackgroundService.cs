using System.Collections.Generic;
using Art.Service.User.DTO;

namespace Art.Service.User
{
    /// <summary>
    /// 业务逻辑类IUserbackgroundService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    public interface IUserbackgroundService
    {
        /// <summary>
        /// 新增一条记录
        ///<param name="userbackgroundDTO">要新增的对象</param>
        /// </summary>
        int Create(UserbackgroundDTO userbackgroundDTO);

        /// <summary>
        /// 修改一条记录
        ///<param name="userbackgroundDTO">要修改的对象</param>
        /// </summary>
        void Modify(UserbackgroundDTO userbackgroundDTO);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        void Remove(int backgroundId);

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        UserbackgroundDTO GetById(int backgroundId);

        /// <summary>
        /// 查询方法
        /// </summary>
        IList<UserbackgroundDTO> Query(UserbackgroundQueryDTO userbackgroundQueryDTO);
    }
}