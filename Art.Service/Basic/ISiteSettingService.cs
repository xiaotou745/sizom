using System.Collections.Generic;
using Art.Service.Basic.DTO;

namespace Art.Service.Basic
{
    /// <summary>
    /// ҵ���߼���ISiteSettingService ��ժҪ˵����
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 18:49:43
    /// </summary>
    public interface ISiteSettingService
    {
        /// <summary>
        /// ����һ����¼
        ///<param name="siteSettingDTO">Ҫ�����Ķ���</param>
        /// </summary>
        int Create(SiteSettingDTO siteSettingDTO);

        /// <summary>
        /// �޸�һ����¼
        ///<param name="siteSettingDTO">Ҫ�޸ĵĶ���</param>
        /// </summary>
        void Modify(SiteSettingDTO siteSettingDTO);

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        void Remove(int id);

        /// <summary>
        /// ����Id�õ�һ������ʵ��
        /// </summary>
        SiteSettingDTO GetById(int id);

        SiteSettingDTO GetSetting();

        /// <summary>
        /// ��ѯ����
        /// </summary>
        IList<SiteSettingDTO> Query(SiteSettingQueryDTO siteSettingQueryDTO);
    }
}