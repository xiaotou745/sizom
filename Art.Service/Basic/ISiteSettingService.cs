using System.Collections.Generic;
using Art.Service.Basic.DTO;

namespace Art.Service.Basic
{
    /// <summary>
    /// 业务逻辑类ISiteSettingService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 18:49:43
    /// </summary>
    public interface ISiteSettingService
    {
        /// <summary>
        /// 新增一条记录
        ///<param name="siteSettingDTO">要新增的对象</param>
        /// </summary>
        int Create(SiteSettingDTO siteSettingDTO);

        /// <summary>
        /// 修改一条记录
        ///<param name="siteSettingDTO">要修改的对象</param>
        /// </summary>
        void Modify(SiteSettingDTO siteSettingDTO);

        /// <summary>
        /// 删除一条记录
        /// </summary>
        void Remove(int id);

        /// <summary>
        /// 根据Id得到一个对象实体
        /// </summary>
        SiteSettingDTO GetById(int id);

        SiteSettingDTO GetSetting();

        /// <summary>
        /// 查询方法
        /// </summary>
        IList<SiteSettingDTO> Query(SiteSettingQueryDTO siteSettingQueryDTO);
    }
}