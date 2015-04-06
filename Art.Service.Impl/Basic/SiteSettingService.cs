using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.Basic;
using Art.Service.Basic;
using Art.Service.Basic.DTO;

namespace Art.Service.Impl.Basic
{
    /// <summary>
    /// Service类SiteSettingService 的摘要说明。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 18:49:43
    /// </summary>
    [Spring(ConstructorArgs = "siteSettingDao:siteSettingDao")]
    public class SiteSettingService : ISiteSettingService
    {
        private readonly SiteSettingDao siteSettingDao;

        public SiteSettingService(SiteSettingDao siteSettingDao)
        {
            this.siteSettingDao = siteSettingDao;
        }

        /// <summary>
        /// 新增一条记录
        /// </summary>
        public int Create(SiteSettingDTO siteSettingDTO)
        {
            return siteSettingDao.Insert(siteSettingDTO);
        }

        /// <summary>
        /// 修改一条记录
        /// </summary>
        public void Modify(SiteSettingDTO siteSettingDTO)
        {
            siteSettingDao.Update(siteSettingDTO);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Remove(int id)
        {
            siteSettingDao.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public SiteSettingDTO GetById(int id)
        {
            return siteSettingDao.GetById(id);
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        public IList<SiteSettingDTO> Query(SiteSettingQueryDTO siteSettingQueryDTO)
        {
            return siteSettingDao.Query(siteSettingQueryDTO);
        }


        public SiteSettingDTO GetSetting()
        {
            return siteSettingDao.GetSetting();
        }
    }
}