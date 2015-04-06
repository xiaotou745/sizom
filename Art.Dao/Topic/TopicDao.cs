#region 引用

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.SpringUtils;
using Art.Service.Topic.DTO;
using AC.Page;
using AC.Util;
using AC.Extension;

#endregion

namespace Art.Dao.Topic
{
    /// <summary>
    /// 数据访问类TopicDao。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:51:52
    /// </summary>
    [Spring]
    public class TopicDao : Daobase
    {
        #region ITopicRepos  Members

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public int Insert(TopicDTO topicDTO)
        {
            const string INSERT_SQL = @"
insert into Topic(TopicType,TopicUrl,Title,Description,Status,CreateTime,PicUrl,IsDeleted,Author)
values(@TopicType,@TopicUrl,@Title,@Description,@Status,@CreateTime,@PicUrl,@IsDeleted,@Author)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("TopicType", topicDTO.TopicType);
            dbParameters.AddWithValue("TopicUrl", topicDTO.TopicUrl);
            dbParameters.AddWithValue("Title", topicDTO.Title);
            dbParameters.AddWithValue("Description", topicDTO.Description);
            dbParameters.AddWithValue("Status", topicDTO.Status);
            dbParameters.AddWithValue("CreateTime", topicDTO.CreateTime);
            dbParameters.AddWithValue("PicUrl", topicDTO.PicUrl);
            dbParameters.AddWithValue("IsDeleted", topicDTO.IsDeleted);
            dbParameters.AddWithValue("Author", topicDTO.Author);


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
        public void Update(TopicDTO topicDTO)
        {
            const string UPDATE_SQL = @"
update  Topic
set  TopicType=@TopicType,TopicUrl=@TopicUrl,Title=@Title,Description=@Description,Status=@Status,CreateTime=@CreateTime,PicUrl=@PicUrl,IsDeleted=@IsDeleted,Author=@Author
where  TopicId=@TopicId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("TopicId", topicDTO.TopicId);
            dbParameters.AddWithValue("TopicType", topicDTO.TopicType);
            dbParameters.AddWithValue("TopicUrl", topicDTO.TopicUrl);
            dbParameters.AddWithValue("Title", topicDTO.Title);
            dbParameters.AddWithValue("Description", topicDTO.Description);
            dbParameters.AddWithValue("Status", topicDTO.Status);
            dbParameters.AddWithValue("CreateTime", topicDTO.CreateTime);
            dbParameters.AddWithValue("PicUrl", topicDTO.PicUrl);
            dbParameters.AddWithValue("IsDeleted", topicDTO.IsDeleted);
            dbParameters.AddWithValue("Author", topicDTO.Author);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete(int topicId)
        {
            const string DELETE_SQL = @"delete from Topic where TopicId=@TopicId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("TopicId", topicId);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }



        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        public TopicDTO GetById(int topicId)
        {
            const string GETBYID_SQL = @"
select  TopicId,TopicType,TopicUrl,Title,Description,Status,CreateTime,PicUrl,IsDeleted,Author
from  Topic (nolock)
where  TopicId=@TopicId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("TopicId", topicId);


            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new TopicRowMapper());
        }

        #endregion

        #region Query and QueryPaged.
        /// <summary>
        /// 查询对象
        /// </summary>
        public IList<TopicDTO> Query(TopicQueryDTO queryInfo)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);
            string querySql = @"
select  t.TopicId, t.TopicType, t.TopicUrl, t.Title, t.Description, t.Status,
        t.CreateTime, t.PicUrl, t.IsDeleted, t.Author
from    dbo.Topic t ( nolock ) {0}".format(searchCondition);
            var lstTopic = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new TopicRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new TopicRowMapper());
            return lstTopic;
        }

        public IPagedList<TopicDTO> QueryPaged(TopicQueryDTO queryInfo, Paginator pager)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string rowCountSql = @"select count(1) from dbo.Topic t(nolock) {0}".format(searchCondition);
            object objCount = dbParameters.Count > 0
                                  ? DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql, dbParameters)
                                  : DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql);
            if (objCount == null)
            {
                return new PagedList<TopicDTO>(new List<TopicDTO>(), 0, 0);
            }

            int recordCount = ParseHelper.ToInt(objCount.ToString()); //总记录数
            int currentPageIndex = pager.PageIndex; //当前页码
            int pageSize = pager.PageSize; //每页数量
            //总页数
            int pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;

            int rowStart = (currentPageIndex - 1) * pageSize + 1;

            string querySql = @"
with    t as ( 
select  row_number() over ( order by {3} ) as rowNo,
        t.TopicId, t.TopicType, t.TopicUrl, t.Title, t.Description, t.Status,
        t.CreateTime, t.PicUrl, t.IsDeleted, t.Author
from    dbo.Topic t ( nolock )
{0})
select * from t where t.rowNo between {1} and {1} + {2} -1 order by {3}"
                .format(searchCondition, rowStart, pageSize, queryInfo.OrderBy);

            var lstTopic = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new TopicRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new TopicRowMapper());
            return new PagedList<TopicDTO>(lstTopic, recordCount, pageCount);
        }
        #endregion
        #region  Nested type: TopicRowMapper

        /// <summary>
        /// 绑定对象
        /// </summary>
        private class TopicRowMapper : IDataTableRowMapper<TopicDTO>
        {
            public TopicDTO MapRow(DataRow dataReader)
            {
                var result = new TopicDTO();
                object obj;
                obj = dataReader["TopicId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.TopicId = int.Parse(obj.ToString());
                }
                obj = dataReader["TopicType"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.TopicType = int.Parse(obj.ToString());
                }
                result.TopicUrl = dataReader["TopicUrl"].ToString();
                result.Title = dataReader["Title"].ToString();
                result.Description = dataReader["Description"].ToString();
                obj = dataReader["Status"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.Status = int.Parse(obj.ToString());
                }
                obj = dataReader["CreateTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.CreateTime = DateTime.Parse(obj.ToString());
                }
                result.PicUrl = dataReader["PicUrl"].ToString();
                obj = dataReader["IsDeleted"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.IsDeleted = int.Parse(obj.ToString());
                }
                result.Author = dataReader["Author"].ToString();

                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// 构造查询条件
        /// </summary>
        public static string BindQueryCriteria(TopicQueryDTO topicQueryDTO, IDbParameters dbParameters)
        {
            var stringBuilder = new StringBuilder(" where 1=1 ");
            if (topicQueryDTO == null)
            {
                return stringBuilder.ToString();
            }

            //TODO:在此加入查询条件构建代码

            return stringBuilder.ToString();
        }

        #endregion
    }
}