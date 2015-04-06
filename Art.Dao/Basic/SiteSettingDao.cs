#region 引用

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.SpringUtils;
using Art.Service.Basic.DTO;

#endregion

namespace Art.Dao.Basic
{
    /// <summary>
    /// 数据访问类SiteSettingDao。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 18:49:43
    /// </summary>
    [Spring]
    public class SiteSettingDao : Daobase
    {
        #region ISiteSettingRepos  Members

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public int Insert(SiteSettingDTO siteSettingDTO)
        {
            const string INSERT_SQL = @"
insert into SiteSetting(Contact,Tel,Fax,Email,Address,Logo,IcpNo)
values(@Contact,@Tel,@Fax,@Email,@Address,@Logo,@IcpNo)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("Contact", siteSettingDTO.Contact);
            dbParameters.AddWithValue("Tel", siteSettingDTO.Tel);
            dbParameters.AddWithValue("Fax", siteSettingDTO.Fax);
            dbParameters.AddWithValue("Email", siteSettingDTO.Email);
            dbParameters.AddWithValue("Address", siteSettingDTO.Address);
            dbParameters.AddWithValue("Logo", siteSettingDTO.Logo);
            dbParameters.AddWithValue("IcpNo", siteSettingDTO.IcpNo);


            object result = DbHelper.ExecuteScalar(ConnStringOfSizom, INSERT_SQL, dbParameters);
            if (result == null)
            {
                return 0;
            }
            return int.Parse(result.ToString());
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        public void Update(SiteSettingDTO siteSettingDTO)
        {
            const string UPDATE_SQL = @"
update  SiteSetting
set  Contact=@Contact,Tel=@Tel,Fax=@Fax,Email=@Email,Address=@Address,Logo=@Logo,IcpNo=@IcpNo
where  Id=@Id ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("Id", siteSettingDTO.Id);
            dbParameters.AddWithValue("Contact", siteSettingDTO.Contact);
            dbParameters.AddWithValue("Tel", siteSettingDTO.Tel);
            dbParameters.AddWithValue("Fax", siteSettingDTO.Fax);
            dbParameters.AddWithValue("Email", siteSettingDTO.Email);
            dbParameters.AddWithValue("Address", siteSettingDTO.Address);
            dbParameters.AddWithValue("Logo", siteSettingDTO.Logo);
            dbParameters.AddWithValue("IcpNo", siteSettingDTO.IcpNo);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete(int id)
        {
            const string DELETE_SQL = @"delete from SiteSetting where Id=@Id ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("Id", id);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        public IList<SiteSettingDTO> Query(SiteSettingQueryDTO siteSettingQueryDTO)
        {
            string condition = BindQueryCriteria(siteSettingQueryDTO);
            string QUERY_SQL = @"
select  Id,Contact,Tel,Fax,Email,Address,Logo,IcpNo
from  SiteSetting (nolock)" + condition;
            return DbHelper.QueryWithRowMapper(ConnStringOfSizom, QUERY_SQL, new SiteSettingRowMapper());
        }


        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        public SiteSettingDTO GetById(int id)
        {
            const string GETBYID_SQL = @"
select  Id,Contact,Tel,Fax,Email,Address,Logo,IcpNo
from  SiteSetting (nolock)
where  Id=@Id ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("Id", id);


            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new SiteSettingRowMapper());
        }

        #endregion

        #region  Nested type: SiteSettingRowMapper

        /// <summary>
        /// 绑定对象
        /// </summary>
        private class SiteSettingRowMapper : IDataTableRowMapper<SiteSettingDTO>
        {
            public SiteSettingDTO MapRow(DataRow dataReader)
            {
                var result = new SiteSettingDTO();
                object obj;
                obj = dataReader["Id"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Id = int.Parse(obj.ToString());
                }
                result.Contact = dataReader["Contact"].ToString();
                result.Tel = dataReader["Tel"].ToString();
                result.Fax = dataReader["Fax"].ToString();
                result.Email = dataReader["Email"].ToString();
                result.Address = dataReader["Address"].ToString();
                result.Logo = dataReader["Logo"].ToString();
                result.IcpNo = dataReader["IcpNo"].ToString();

                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// 构造查询条件
        /// </summary>
        public static string BindQueryCriteria(SiteSettingQueryDTO siteSettingQueryDTO)
        {
            var stringBuilder = new StringBuilder(" where 1=1 ");
            if (siteSettingQueryDTO == null)
            {
                return stringBuilder.ToString();
            }

            //TODO:在此加入查询条件构建代码

            return stringBuilder.ToString();
        }

        #endregion

        public SiteSettingDTO GetSetting()
        {
            const string GETBYID_SQL = @"
select  top 1 Id,Contact,Tel,Fax,Email,Address,Logo,IcpNo
from  SiteSetting (nolock)";

            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, new SiteSettingRowMapper());
        }
    }
}