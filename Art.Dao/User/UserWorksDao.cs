#region 引用

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.SpringUtils;
using Art.Service.User.DTO;
using AC.Page;
using AC.Extension;
using AC.Util;
using AC.Helper;

#endregion

namespace Art.Dao.User
{
    /// <summary>
    /// 数据访问类UserWorksDao。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:41:13
    /// </summary>
    [Spring]
    public class UserWorksDao : Daobase
    {
        #region IUserWorksRepos  Members

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public int Insert(UserWorksDTO userWorksDTO)
        {
            const string INSERT_SQL = @"
insert into UserWorks(FinishTime,WorksType,UserId,PicUrl,Price,WorksName,WorksDescription,CreateTime,UpdateTime,Status,WorkSizeLength,WorkSizeWidth,WorkSizeHeight,WorkSizeType,IsDeleted,HotCount)
values(@FinishTime,@WorksType,@UserId,@PicUrl,@Price,@WorksName,@WorksDescription,@CreateTime,@UpdateTime,@Status,@WorkSizeLength,@WorkSizeWidth,@WorkSizeHeight,@WorkSizeType,@IsDeleted,@HotCount)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("FinishTime", userWorksDTO.FinishTime);
            dbParameters.AddWithValue("WorksType", userWorksDTO.WorksType);
            dbParameters.AddWithValue("UserId", userWorksDTO.UserId);
            dbParameters.AddWithValue("PicUrl", userWorksDTO.PicUrl);
            dbParameters.AddWithValue("Price", userWorksDTO.Price);
            dbParameters.AddWithValue("WorksName", userWorksDTO.WorksName);
            dbParameters.AddWithValue("WorksDescription", userWorksDTO.WorksDescription);
            dbParameters.AddWithValue("CreateTime", userWorksDTO.CreateTime);
            dbParameters.AddWithValue("UpdateTime", userWorksDTO.UpdateTime);
            dbParameters.AddWithValue("Status", userWorksDTO.Status);
            dbParameters.AddWithValue("WorkSizeLength", userWorksDTO.WorkSizeLength);
            dbParameters.AddWithValue("WorkSizeWidth", userWorksDTO.WorkSizeWidth);
            dbParameters.AddWithValue("WorkSizeHeight", userWorksDTO.WorkSizeHeight);
            dbParameters.AddWithValue("WorkSizeType", userWorksDTO.WorkSizeType);
            dbParameters.AddWithValue("IsDeleted", userWorksDTO.IsDeleted);
            dbParameters.AddWithValue("HotCount", userWorksDTO.HotCount);


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
        public void Update(UserWorksDTO userWorksDTO)
        {
            const string UPDATE_SQL = @"
update  UserWorks
set  FinishTime=@FinishTime,WorksType=@WorksType,UserId=@UserId,PicUrl=@PicUrl,Price=@Price,WorksName=@WorksName,WorksDescription=@WorksDescription,CreateTime=@CreateTime,UpdateTime=@UpdateTime,Status=@Status,WorkSizeLength=@WorkSizeLength,WorkSizeWidth=@WorkSizeWidth,WorkSizeHeight=@WorkSizeHeight,WorkSizeType=@WorkSizeType,IsDeleted=@IsDeleted,HotCount=@HotCount
where  WorksId=@WorksId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("WorksId", userWorksDTO.WorksId);
            dbParameters.AddWithValue("FinishTime", userWorksDTO.FinishTime);
            dbParameters.AddWithValue("WorksType", userWorksDTO.WorksType);
            dbParameters.AddWithValue("UserId", userWorksDTO.UserId);
            dbParameters.AddWithValue("PicUrl", userWorksDTO.PicUrl);
            dbParameters.AddWithValue("Price", userWorksDTO.Price);
            dbParameters.AddWithValue("WorksName", userWorksDTO.WorksName);
            dbParameters.AddWithValue("WorksDescription", userWorksDTO.WorksDescription);
            dbParameters.AddWithValue("CreateTime", userWorksDTO.CreateTime);
            dbParameters.AddWithValue("UpdateTime", userWorksDTO.UpdateTime);
            dbParameters.AddWithValue("Status", userWorksDTO.Status);
            dbParameters.AddWithValue("WorkSizeLength", userWorksDTO.WorkSizeLength);
            dbParameters.AddWithValue("WorkSizeWidth", userWorksDTO.WorkSizeWidth);
            dbParameters.AddWithValue("WorkSizeHeight", userWorksDTO.WorkSizeHeight);
            dbParameters.AddWithValue("WorkSizeType", userWorksDTO.WorkSizeType);
            dbParameters.AddWithValue("IsDeleted", userWorksDTO.IsDeleted);
            dbParameters.AddWithValue("HotCount", userWorksDTO.HotCount);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete(int worksId)
        {
            const string DELETE_SQL = @"delete from UserWorks where WorksId=@WorksId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("WorksId", worksId);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }



        #endregion

        #region Get methods.

        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        public UserWorksDTO GetById(int worksId)
        {
            const string GETBYID_SQL = @"
select  WorksId,FinishTime,WorksType,UserId,PicUrl,Price,WorksName,WorksDescription,CreateTime,UpdateTime,Status,WorkSizeLength,WorkSizeWidth,WorkSizeHeight,WorkSizeType,IsDeleted,HotCount
from  UserWorks (nolock)
where  WorksId=@WorksId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("WorksId", worksId);

            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new UserWorksRowMapper());
        }

        public UserWorksDTO GetUserDefaultWork(int userId)
        {
            const string GETBYID_SQL = @"
select  WorksId,FinishTime,WorksType,UserId,PicUrl,Price,WorksName,WorksDescription,CreateTime,UpdateTime,Status,WorkSizeLength,WorkSizeWidth,WorkSizeHeight,WorkSizeType,IsDeleted,HotCount
from  UserWorks (nolock)
where  UserId=@UserId and IsDeleted=0 and Status=1";

            IDbParameters dbParameters = DbHelper.CreateDbParameters("UserId", DbType.Int32, 4, userId);

            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new UserWorksRowMapper());
        }
        /// <summary>
        /// 获取指定用户ID的作品
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UserWorksDTO> GetByUserId(int userId)
        {
            const string GETBYID_SQL = @"
select  WorksId,FinishTime,WorksType,UserId,PicUrl,Price,WorksName,WorksDescription,CreateTime,UpdateTime,Status,WorkSizeLength,WorkSizeWidth,WorkSizeHeight,WorkSizeType,IsDeleted,HotCount
from  UserWorks (nolock)
where  UserId=@UserId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters("UserId", DbType.Int32, 4, userId);

            return DbHelper.QueryWithRowMapper(ConnStringOfSizom, GETBYID_SQL, dbParameters, new UserWorksRowMapper());
        }
        #endregion

        #region Query and QueryPaged.
        /// <summary>
        /// 查询对象
        /// </summary>
        public IList<UserWorksDTO> Query(UserWorksQueryDTO queryInfo)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string querySql = @"
select  uw.WorksId, uw.FinishTime, uw.WorksType, uw.UserId, uw.PicUrl,
        uw.Price, uw.WorksName, uw.WorksDescription, uw.CreateTime,
        uw.UpdateTime, uw.Status, uw.WorkSizeLength, uw.WorkSizeWidth,
        uw.WorkSizeHeight, uw.WorkSizeType, uw.IsDeleted, uw.HotCount
from    dbo.UserWorks uw ( nolock )
{0}".format(searchCondition);

            var lstUserWorks = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new UserWorksRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new UserWorksRowMapper());
            return lstUserWorks;
        }

        public IPagedList<UserWorksDTO> QueryPaged(UserWorksQueryDTO queryInfo, Paginator pager)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string rowCountSql = @"select count(1) from UserWorks uw(nolock) {0}".format(searchCondition);
            object objCount = dbParameters.Count > 0
                                  ? DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql, dbParameters)
                                  : DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql);
            if (objCount == null)
            {
                return new PagedList<UserWorksDTO>(new List<UserWorksDTO>(), 0, 0);
            }

            int recordCount = ParseHelper.ToInt(objCount.ToString()); //总记录数
            int currentPageIndex = pager.PageIndex; //当前页码
            int pageSize = pager.PageSize; //每页数量
            //总页数
            int pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;

            int rowStart = (currentPageIndex - 1) * pageSize + 1;

            string querySql = @"
with uw as(
select  row_number() over ( order by {3} ) as rowNo,
		uw.WorksId, uw.FinishTime, uw.WorksType, uw.UserId, uw.PicUrl,
        uw.Price, uw.WorksName, uw.WorksDescription, uw.CreateTime,
        uw.UpdateTime, uw.Status, uw.WorkSizeLength, uw.WorkSizeWidth,
        uw.WorkSizeHeight, uw.WorkSizeType, uw.IsDeleted, uw.HotCount,u.TrueName,at.TypeName
from    dbo.UserWorks uw ( nolock )
        join dbo.Users u ( nolock ) on uw.UserId = u.UserId
        join dbo.ArtType at ( nolock ) on uw.WorksType = at.TypeId
{0})
select * from uw where uw.rowNo between {1} and {1} + {2} -1 order by {3}"
                .format(searchCondition, rowStart, pageSize, queryInfo.OrderBy);

            var lstUserWorks = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new UserWorksRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new UserWorksRowMapper());
            return new PagedList<UserWorksDTO>(lstUserWorks, recordCount, pageCount);
        }
        #endregion

        #region  Nested type: UserWorksRowMapper

        /// <summary>
        /// 绑定对象
        /// </summary>
        private class UserWorksRowMapper : IDataTableRowMapper<UserWorksDTO>
        {
            public UserWorksDTO MapRow(DataRow dataReader)
            {
                var result = new UserWorksDTO();
                object obj;
                obj = dataReader["WorksId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorksId = int.Parse(obj.ToString());
                }
                obj = dataReader["FinishTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.FinishTime = DateTime.Parse(obj.ToString());
                }
                obj = dataReader["WorksType"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorksType = int.Parse(obj.ToString());
                }
                obj = dataReader["UserId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UserId = int.Parse(obj.ToString());
                }
                result.PicUrl = dataReader["PicUrl"].ToString();
                obj = dataReader["Price"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Price = decimal.Parse(obj.ToString());
                }
                result.WorksName = dataReader["WorksName"].ToString();
                result.WorksDescription = dataReader["WorksDescription"].ToString();
                obj = dataReader["CreateTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.CreateTime = DateTime.Parse(obj.ToString());
                }
                obj = dataReader["UpdateTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UpdateTime = DateTime.Parse(obj.ToString());
                }
                obj = dataReader["Status"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Status = int.Parse(obj.ToString());
                }
                obj = dataReader["WorkSizeLength"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorkSizeLength = decimal.Parse(obj.ToString());
                }
                obj = dataReader["WorkSizeWidth"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorkSizeWidth = decimal.Parse(obj.ToString());
                }
                obj = dataReader["WorkSizeHeight"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorkSizeHeight = decimal.Parse(obj.ToString());
                }
                obj = dataReader["WorkSizeType"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.WorkSizeType = int.Parse(obj.ToString());
                }
                obj = dataReader["IsDeleted"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.IsDeleted = int.Parse(obj.ToString());
                }
                obj = dataReader["HotCount"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.HotCount = long.Parse(obj.ToString());
                }
                if (dataReader.HasColumn("TrueName"))
                    result.UserName = dataReader["TrueName"].ToString();
                if (dataReader.HasColumn("TypeName"))
                    result.WorksTypeName = dataReader["TypeName"].ToString();
                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// 构造查询条件
        /// </summary>
        public static string BindQueryCriteria(UserWorksQueryDTO userWorksQueryDTO, IDbParameters dbParameters)
        {
            if (userWorksQueryDTO == null)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder(" where uw.IsDeleted=@IsDeleted");
            dbParameters.Add("IsDeleted", DbType.Int32, 4).Value = userWorksQueryDTO.IsDeleted ? 1 : 0;

            if (userWorksQueryDTO.Status != null)
            {
                stringBuilder.Append(" and uw.Status=@Status");
                dbParameters.Add("Status", DbType.Int32, 4).Value = userWorksQueryDTO.Status.Value;
            }
            if (userWorksQueryDTO.UserId != null)
            {
                stringBuilder.Append(" and uw.UserId=@UserId");
                dbParameters.Add("UserId", DbType.Int32, 4).Value = userWorksQueryDTO.UserId.Value;
            }

            return stringBuilder.ToString();
        }

        #endregion


    }
}