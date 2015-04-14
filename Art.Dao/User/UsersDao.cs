#region 引用

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.Extension;
using AC.Page;
using AC.SpringUtils;
using AC.Util;
using Art.Service.User;
using Art.Service.User.DTO;
using AC.Helper;

#endregion

namespace Art.Dao.User
{
    /// <summary>
    /// 数据访问类UsersDao。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-04 20:55:52
    /// </summary>
    [Spring]
    public class UsersDao : Daobase
    {
        #region IUsersRepos  Members

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public int Insert(UsersDTO usersDTO)
        {
            const string INSERT_SQL = @"
insert into Users(LoginName,Password,UserType,TrueName,Location,ArtType,PicUrl,Status,
    Summary,HotCount,Birthday)
values(@LoginName,@Password,@UserType,@TrueName,@Location,@ArtType,@PicUrl,@Status,
    @Summary,@HotCount,@Birthday)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("LoginName", usersDTO.LoginName);
            dbParameters.AddWithValue("Password", usersDTO.Password);
            dbParameters.AddWithValue("UserType", usersDTO.UserType.GetHashCode());
            dbParameters.AddWithValue("TrueName", usersDTO.TrueName);
            dbParameters.AddWithValue("Location", usersDTO.Location);
            dbParameters.AddWithValue("ArtType", usersDTO.ArtType.GetHashCode());
            dbParameters.AddWithValue("PicUrl", usersDTO.PicUrl);
            dbParameters.AddWithValue("Status", usersDTO.Status);
            dbParameters.AddWithValue("Summary", usersDTO.Summary);
            dbParameters.AddWithValue("HotCount", usersDTO.HotCount);
            dbParameters.AddWithValue("Birthday", usersDTO.Birthday);

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
        public void Update(UsersDTO usersDTO)
        {
            const string UPDATE_SQL = @"
update  Users
set  LoginName=@LoginName,Password=@Password,UserType=@UserType,TrueName=@TrueName,Location=@Location,ArtType=@ArtType,PicUrl=@PicUrl,Status=@Status,IsDeleted=@IsDeleted,Summary=@Summary,HotCount=@HotCount,Birthday=@Birthday,CreateTime=@CreateTime
where  UserId=@UserId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("UserId", usersDTO.UserId);
            dbParameters.AddWithValue("LoginName", usersDTO.LoginName);
            dbParameters.AddWithValue("Password", usersDTO.Password);
            dbParameters.AddWithValue("UserType", usersDTO.UserType);
            dbParameters.AddWithValue("TrueName", usersDTO.TrueName);
            dbParameters.AddWithValue("Location", usersDTO.Location);
            dbParameters.AddWithValue("ArtType", usersDTO.ArtType);
            dbParameters.AddWithValue("PicUrl", usersDTO.PicUrl);
            dbParameters.AddWithValue("Status", usersDTO.Status);
            dbParameters.AddWithValue("IsDeleted", usersDTO.IsDeleted);
            dbParameters.AddWithValue("Summary", usersDTO.Summary);
            dbParameters.AddWithValue("HotCount", usersDTO.HotCount);
            dbParameters.AddWithValue("Birthday", usersDTO.Birthday);
            dbParameters.AddWithValue("CreateTime", usersDTO.CreateTime);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete(int userId)
        {
            const string DELETE_SQL = @"delete from Users where UserId=@UserId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("UserId", userId);

            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        public UsersDTO GetById(int userId)
        {
            const string GETBYID_SQL = @"
select  UserId,LoginName,Password,UserType,TrueName,Location,ArtType,PicUrl,Status,IsDeleted,Summary,HotCount,Birthday,CreateTime
from  Users (nolock)
where  UserId=@UserId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("UserId", userId);


            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new UsersRowMapper());
        }

        public UsersDTO GetByLoginName(string loginName)
        {
            const string getSql = @"
select  UserId,LoginName,Password,UserType,TrueName,Location,ArtType,PicUrl,Status,IsDeleted,Summary,HotCount,Birthday,CreateTime
from  Users (nolock)
where  LoginName=@LoginName";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("LoginName", loginName);

            return DbHelper.QueryForObject(ConnStringOfSizom, getSql, dbParameters, new UsersRowMapper());
        }

        #endregion

        #region Query and QueryPaged.
        /// <summary>
        /// 查询对象
        /// </summary>
        public IList<UsersDTO> Query(UsersQueryDTO usersQueryDTO)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(usersQueryDTO, dbParameters);

            string querySql = @"
select  u.UserId, u.LoginName, u.Password, u.UserType, u.TrueName, u.Location,
        u.ArtType, u.PicUrl, u.Status, u.IsDeleted, u.Summary, u.HotCount,
        u.Birthday, u.CreateTime
from    dbo.Users u ( nolock ) {0}".format(searchCondition);

            var lstUsers = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new UsersRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new UsersRowMapper());
            return lstUsers;
        }

        public IPagedList<UsersDTO> QueryPaged(UsersQueryDTO queryInfo, Paginator pager)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string rowCountSql = @"select count(1) from Users u(nolock) {0}".format(searchCondition);
            object objCount = dbParameters.Count > 0
                                  ? DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql, dbParameters)
                                  : DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql);
            if (objCount == null)
            {
                return new PagedList<UsersDTO>(new List<UsersDTO>(), 0, 0);
            }

            int recordCount = ParseHelper.ToInt(objCount.ToString()); //总记录数
            int currentPageIndex = pager.PageIndex; //当前页码
            int pageSize = pager.PageSize; //每页数量
            //总页数
            int pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;

            int rowStart = (currentPageIndex - 1) * pageSize + 1;

            string querySql = @"
with u as (
select  row_number() over ( order by {3} ) as rowNo,
		u.UserId, u.LoginName, u.Password, u.UserType, u.TrueName, u.Location,
        u.ArtType, u.PicUrl, u.Status, u.IsDeleted, u.Summary, u.HotCount,
        u.Birthday, u.CreateTime,at.TypeName ArtTypeName,l.LocationName
from    dbo.Users u ( nolock )
        join dbo.Location l ( nolock ) on u.Location = l.Id
        join dbo.ArtType at ( nolock ) on u.ArtType = at.TypeId
{0})
select * from u where u.rowNo between {1} and {1} + {2} -1 order by {3}"
                .format(searchCondition, rowStart, pageSize, queryInfo.OrderBy);

            var lstUsers = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new UsersRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new UsersRowMapper());
            return new PagedList<UsersDTO>(lstUsers, recordCount, pageCount);
        }
        #endregion

        #region  Nested type: UsersRowMapper

        /// <summary>
        /// 绑定对象
        /// </summary>
        private class UsersRowMapper : IDataTableRowMapper<UsersDTO>
        {
            public UsersDTO MapRow(DataRow dataReader)
            {
                var result = new UsersDTO();
                var location = new LocationDTO();

                object obj = dataReader["UserId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UserId = int.Parse(obj.ToString());
                }
                result.LoginName = dataReader["LoginName"].ToString();
                result.Password = dataReader["Password"].ToString();
                obj = dataReader["UserType"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UserType = (UserType) Enum.Parse(typeof (UserType), obj.ToString());
                    int.Parse(obj.ToString());
                }
                result.TrueName = dataReader["TrueName"].ToString();
                obj = dataReader["Location"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Location = int.Parse(obj.ToString());
                    location.Id = result.Location.Value;
                }
                obj = dataReader["ArtType"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.ArtType = (ArtType) Enum.Parse(typeof (ArtType), obj.ToString());
                }
                result.PicUrl = dataReader["PicUrl"].ToString();
                obj = dataReader["Status"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Status = int.Parse(obj.ToString());
                }
                obj = dataReader["IsDeleted"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.IsDeleted = int.Parse(obj.ToString());
                }
                result.Summary = dataReader["Summary"].ToString();
                obj = dataReader["HotCount"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.HotCount = long.Parse(obj.ToString());
                }
                obj = dataReader["Birthday"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Birthday = DateTime.Parse(obj.ToString());
                }
                obj = dataReader["CreateTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.CreateTime = DateTime.Parse(obj.ToString());
                }


                if (dataReader.HasColumn("ArtTypeName"))
                {
                    result.ArtTypeName = dataReader["ArtTypeName"].ToString();
                }
                if (dataReader.HasColumn("LocationName"))
                {
                    location.LocationName = dataReader["LocationName"].ToString();
                }
                result.LocationInfo = location;
                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// 构造查询条件
        /// </summary>
        public static string BindQueryCriteria(UsersQueryDTO usersQueryDTO, IDbParameters dbParameters)
        {
            if (usersQueryDTO == null)
            {
                return string.Empty;
            }
            var result = new StringBuilder("where u.IsDeleted=@IsDeleted");
            dbParameters.Add("IsDeleted", DbType.Int16, 2).Value = usersQueryDTO.IsDeleted ? 1 : 0;

            if (usersQueryDTO.ArtType != null)
            {
                result.Append(" and u.ArtType=@ArtType");
                dbParameters.Add("ArtType", DbType.Int32, 4).Value = usersQueryDTO.ArtType.Value.GetHashCode();
            }
            if (usersQueryDTO.Status != null)
            {
                result.Append(" and u.Status=@Status");
                dbParameters.Add("Status", DbType.Int16, 2).Value = usersQueryDTO.Status.Value;
            }
            if (usersQueryDTO.UserType != null)
            {
                result.Append(" and u.UserType=@UserType");
                dbParameters.Add("UserType", DbType.Int16, 2).Value = usersQueryDTO.UserType.Value.GetHashCode();
            }

            return result.ToString();
        }

        #endregion
    }
}