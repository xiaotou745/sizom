using Art.Common.Services;
using Art.Service.Basic.DTO;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace System.Web.Mvc
{
    public static class ControllerUtil
    {
        ///// <summary>
        ///// get website server domain url
        ///// </summary>
        ///// <param name="helper"></param>
        ///// <returns></returns>
        //public static String GetWebServerUrl(this HtmlHelper helper)
        //{
        //    return SystemService.WebSiteServer;
        //}
        ///// <summary>
        ///// 获取图片的全路径
        ///// </summary>
        ///// <param name="helper"></param>
        ///// <param name="imgurl"></param>
        ///// <param name="widht"></param>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public static String GetFullImagePath(this HtmlHelper helper, string imgurl, int widht, int height)
        //{
        //    try
        //    {
        //        SystemService.GetPicResize(imgurl, widht, height);
        //        return UploadHelper.GetImageWebPath(imgurl.Substring(0, imgurl.IndexOf(".")) + "_" + widht + "_" + height + "_cut" + imgurl.Substring(imgurl.IndexOf(".")));
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        ///// <summary>
        ///// 获取图片的全路径
        ///// </summary>
        ///// <param name="helper"></param>
        ///// <param name="imgurl"></param>
        ///// <param name="widht"></param>
        ///// <param name="height"></param>
        ///// <returns></returns>
        //public static String GetFullImagePath(this HtmlHelper helper, string imgurl, int widht, int height, string type)
        //{
        //    try
        //    {
        //        SystemService.GetPicResize(imgurl, widht, height);
        //        return UploadHelper.GetImageWebPath(imgurl.Substring(0, imgurl.IndexOf(".")) + "_" + widht + "_" + height + "_cut" + imgurl.Substring(imgurl.IndexOf(".")));
        //    }
        //    catch
        //    {
        //        return "";
        //    }
        //}
        /// <summary>
        /// 站点设置
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static SiteSettingDTO GetSiteSetting(this HtmlHelper helper)
        {
            return SiteSettingServices.Create().GetSiteSetting();
        }

        //public static IList<Topic> GetTopicBanner(this HtmlHelper helper)
        //{
        //    return HomeService.GetTopicBanner(5, "CreateTime", "desc");
        //}

        //public static String GetFullImagePath(this HtmlHelper helper, string imgurl)
        //{
        //    return UploadHelper.GetImageWebPath(imgurl);
        //}

        /// <summary>
        /// 导航索引
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="controllername"></param>
        /// <param name="actionname"></param>
        /// <returns></returns>
        public static int GetCurrentIndex(this HtmlHelper helper, string controllername, string actionname)
        {
            if (controllername.ToLower() == "artists")
            {
                return 2;
            }
            if (controllername.ToLower() == "artistaccount" || controllername.ToLower() == "account" || controllername.ToLower() == "adminaccount")
            {
                return 5;
            }
            if (controllername.ToLower() == "home")
            {
                if (actionname.ToLower() == "index")
                {
                    return 1;
                }
                if (actionname.ToLower() == "artworks")
                {
                    return 3;
                }
                else if (actionname.ToLower() == "artists")
                {
                    return 2;
                }
                else if (actionname.ToLower() == "news")
                {
                    return 4;
                }
                else
                {
                    return 6;
                }
            }
            return 6;
        }
    }
}