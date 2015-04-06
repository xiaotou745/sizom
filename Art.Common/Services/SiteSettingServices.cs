using AC.SpringUtils;
using Art.Service.Basic;
using Art.Service.Basic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.Common.Services
{
    /// <summary>
    /// 网站基本信息
    /// </summary>
    public class SiteSettingServices
    {
        private readonly ISiteSettingService siteSettingService;

        private SiteSettingServices()
        {
            siteSettingService = ServiceLocator.GetService<ISiteSettingService>();
        }

        public static SiteSettingServices Create()
        {
            SiteSettingServices result = new SiteSettingServices();
            return result;
        }

        public SiteSettingDTO GetSiteSetting()
        {
            return siteSettingService.GetSetting();
        }
    }
}
