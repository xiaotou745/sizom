using System.Collections.Generic;
using AC.SpringUtils;
using Art.Dao.Basic;
using Art.Service.Basic;
using Art.Service.Basic.DTO;

namespace Art.Service.Impl.Basic
{
    /// <summary>
    /// Service��SiteSettingService ��ժҪ˵����
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
        /// ����һ����¼
        /// </summary>
        public int Create(SiteSettingDTO siteSettingDTO)
        {
            return siteSettingDao.Insert(siteSettingDTO);
        }

        /// <summary>
        /// �޸�һ����¼
        /// </summary>
        public void Modify(SiteSettingDTO siteSettingDTO)
        {
            siteSettingDao.Update(siteSettingDTO);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        public void Remove(int id)
        {
            siteSettingDao.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public SiteSettingDTO GetById(int id)
        {
            return siteSettingDao.GetById(id);
        }

        /// <summary>
        /// ��ѯ����
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