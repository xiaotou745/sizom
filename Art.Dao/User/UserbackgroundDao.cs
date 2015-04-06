#region ����

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.SpringUtils;
using Art.Service.User.DTO;

#endregion

namespace Art.Dao.User
{
    /// <summary>
    /// ���ݷ�����UserbackgroundDao��
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 22:19:55
    /// </summary>
    [Spring]
    public class UserbackgroundDao : Daobase
    {
        #region IUserbackgroundRepos  Members

        /// <summary>
        /// ����һ����¼
        /// </summary>
        public int Insert(UserbackgroundDTO userbackgroundDTO)
        {
            const string INSERT_SQL = @"
insert into userbackground(UserId,ImageUrl,BgOrder)
values(@UserId,@ImageUrl,@BgOrder)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("UserId", userbackgroundDTO.UserId);
            dbParameters.AddWithValue("ImageUrl", userbackgroundDTO.ImageUrl);
            dbParameters.AddWithValue("BgOrder", userbackgroundDTO.BgOrder);

            object result = DbHelper.ExecuteScalar(ConnStringOfSizom, INSERT_SQL, dbParameters);
            if (result == null)
            {
                return 0;
            }
            return int.Parse(result.ToString());
        }

        /// <summary>
        /// ����һ����¼
        /// </summary>
        public void Update(UserbackgroundDTO userbackgroundDTO)
        {
            const string UPDATE_SQL = @"
update  userbackground
set  UserId=@UserId,ImageUrl=@ImageUrl,IsDeleted=@IsDeleted,BgOrder=@BgOrder
where  BackgroundId=@BackgroundId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("BackgroundId", userbackgroundDTO.BackgroundId);
            dbParameters.AddWithValue("UserId", userbackgroundDTO.UserId);
            dbParameters.AddWithValue("ImageUrl", userbackgroundDTO.ImageUrl);
            dbParameters.AddWithValue("IsDeleted", userbackgroundDTO.IsDeleted);
            dbParameters.AddWithValue("BgOrder", userbackgroundDTO.BgOrder);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        public void Delete(int backgroundId)
        {
            const string DELETE_SQL = @"delete from userbackground where BackgroundId=@BackgroundId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("BackgroundId", backgroundId);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        public IList<UserbackgroundDTO> Query(UserbackgroundQueryDTO userbackgroundQueryDTO)
        {
            string condition = BindQueryCriteria(userbackgroundQueryDTO);
            string QUERY_SQL = @"
select  BackgroundId,UserId,ImageUrl,IsDeleted,BgOrder
from  userbackground (nolock)" + condition;
            return DbHelper.QueryWithRowMapper(ConnStringOfSizom, QUERY_SQL, new userbackgroundRowMapper());
        }


        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        public UserbackgroundDTO GetById(int backgroundId)
        {
            const string GETBYID_SQL = @"
select  BackgroundId,UserId,ImageUrl,IsDeleted,BgOrder
from  userbackground (nolock)
where  BackgroundId=@BackgroundId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("BackgroundId", backgroundId);


            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new userbackgroundRowMapper());
        }

        #endregion

        #region  Nested type: userbackgroundRowMapper

        /// <summary>
        /// �󶨶���
        /// </summary>
        private class userbackgroundRowMapper : IDataTableRowMapper<UserbackgroundDTO>
        {
            public UserbackgroundDTO MapRow(DataRow dataReader)
            {
                var result = new UserbackgroundDTO();
                object obj;
                obj = dataReader["BackgroundId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.BackgroundId = int.Parse(obj.ToString());
                }
                obj = dataReader["UserId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UserId = int.Parse(obj.ToString());
                }
                result.ImageUrl = dataReader["ImageUrl"].ToString();
                obj = dataReader["IsDeleted"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.IsDeleted = int.Parse(obj.ToString());
                }
                obj = dataReader["BgOrder"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.BgOrder = int.Parse(obj.ToString());
                }

                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// �����ѯ����
        /// </summary>
        public static string BindQueryCriteria(UserbackgroundQueryDTO userbackgroundQueryDTO)
        {
            var stringBuilder = new StringBuilder(" where 1=1 ");
            if (userbackgroundQueryDTO == null)
            {
                return stringBuilder.ToString();
            }

            //TODO:�ڴ˼����ѯ������������

            return stringBuilder.ToString();
        }

        #endregion
    }
}