#region 引用

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using AC.Data.Core;
using AC.Data.Generic;
using AC.SpringUtils;
using Art.Service.News.DTO;
using AC.Page;
using AC.Extension;
using AC.Util;
using AC.Helper;

#endregion

namespace Art.Dao.News
{
    /// <summary>
    /// 数据访问类NewsDao。
    /// Generate By: tools.etaoshi.com
    /// Generate Time: 2015-04-06 14:59:30
    /// </summary>
    [Spring]
    public class NewsDao : Daobase
    {
        #region INewsRepos  Members

        /// <summary>
        /// 增加一条记录
        /// </summary>
        public int Insert(NewsDTO newsDTO)
        {
            const string INSERT_SQL = @"
insert into News(NewsType,Status,CreateTime,UpdateTime,NewsTitle,NewsSummary,PicUrl,NewsContent,Author,Source,IsDeleted)
values(@NewsType,@Status,@CreateTime,@UpdateTime,@NewsTitle,@NewsSummary,@PicUrl,@NewsContent,@Author,@Source,@IsDeleted)

select @@IDENTITY";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("NewsType", newsDTO.NewsType);
            dbParameters.AddWithValue("Status", newsDTO.Status);
            dbParameters.AddWithValue("CreateTime", newsDTO.CreateTime);
            dbParameters.AddWithValue("UpdateTime", newsDTO.UpdateTime);
            dbParameters.AddWithValue("NewsTitle", newsDTO.NewsTitle);
            dbParameters.AddWithValue("NewsSummary", newsDTO.NewsSummary);
            dbParameters.AddWithValue("PicUrl", newsDTO.PicUrl);
            dbParameters.AddWithValue("NewsContent", newsDTO.NewsContent);
            dbParameters.AddWithValue("Author", newsDTO.Author);
            dbParameters.AddWithValue("Source", newsDTO.Source);
            dbParameters.AddWithValue("IsDeleted", newsDTO.IsDeleted);


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
        public void Update(NewsDTO newsDTO)
        {
            const string UPDATE_SQL = @"
update  News
set  NewsType=@NewsType,Status=@Status,CreateTime=@CreateTime,UpdateTime=@UpdateTime,NewsTitle=@NewsTitle,NewsSummary=@NewsSummary,PicUrl=@PicUrl,NewsContent=@NewsContent,Author=@Author,Source=@Source,IsDeleted=@IsDeleted
where  NewsId=@NewsId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("NewsId", newsDTO.NewsId);
            dbParameters.AddWithValue("NewsType", newsDTO.NewsType);
            dbParameters.AddWithValue("Status", newsDTO.Status);
            dbParameters.AddWithValue("CreateTime", newsDTO.CreateTime);
            dbParameters.AddWithValue("UpdateTime", newsDTO.UpdateTime);
            dbParameters.AddWithValue("NewsTitle", newsDTO.NewsTitle);
            dbParameters.AddWithValue("NewsSummary", newsDTO.NewsSummary);
            dbParameters.AddWithValue("PicUrl", newsDTO.PicUrl);
            dbParameters.AddWithValue("NewsContent", newsDTO.NewsContent);
            dbParameters.AddWithValue("Author", newsDTO.Author);
            dbParameters.AddWithValue("Source", newsDTO.Source);
            dbParameters.AddWithValue("IsDeleted", newsDTO.IsDeleted);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, UPDATE_SQL, dbParameters);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void Delete(int newsId)
        {
            const string DELETE_SQL = @"delete from News where NewsId=@NewsId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("NewsId", newsId);


            DbHelper.ExecuteNonQuery(ConnStringOfSizom, DELETE_SQL, dbParameters);
        }

    
        /// <summary>
        /// 根据ID获取对象
        /// </summary>
        public NewsDTO GetById(int newsId)
        {
            const string GETBYID_SQL = @"
select  NewsId,NewsType,Status,CreateTime,UpdateTime,NewsTitle,NewsSummary,PicUrl,NewsContent,Author,Source,IsDeleted
from  News (nolock)
where  NewsId=@NewsId ";

            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            dbParameters.AddWithValue("NewsId", newsId);


            return DbHelper.QueryForObject(ConnStringOfSizom, GETBYID_SQL, dbParameters, new NewsRowMapper());
        }

        #endregion

        #region Query and Query Paged.
        /// <summary>
        /// 查询对象
        /// </summary>
        public IList<NewsDTO> Query(NewsQueryDTO queryInfo)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string querySql = @"
select  n.NewsId, n.NewsType, n.Status, n.CreateTime, n.UpdateTime,
        n.NewsTitle, n.NewsSummary, n.PicUrl, n.NewsContent, n.Author,
        n.Source, n.IsDeleted
from    dbo.News n ( nolock )
{0}".format(searchCondition);
            var lstNews = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new NewsRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new NewsRowMapper());

            return lstNews;
        }

        public IPagedList<NewsDTO> QueryPaged(NewsQueryDTO queryInfo, Paginator pager)
        {
            IDbParameters dbParameters = DbHelper.CreateDbParameters();
            string searchCondition = BindQueryCriteria(queryInfo, dbParameters);

            string rowCountSql = @"select count(1) from dbo.News n(nolock) {0}".format(searchCondition);
            object objCount = dbParameters.Count > 0
                                  ? DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql, dbParameters)
                                  : DbHelper.ExecuteScalar(ConnStringOfSizom, rowCountSql);
            if (objCount == null)
            {
                return new PagedList<NewsDTO>(new List<NewsDTO>(), 0, 0);
            }

            int recordCount = ParseHelper.ToInt(objCount.ToString()); //总记录数
            int currentPageIndex = pager.PageIndex; //当前页码
            int pageSize = pager.PageSize; //每页数量
            //总页数
            int pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;

            int rowStart = (currentPageIndex - 1) * pageSize + 1;

            string querySql = @"
with    n as ( 
select  row_number() over ( order by {3} ) as rowNo,
        n.NewsId, n.NewsType, n.Status, n.CreateTime, n.UpdateTime,
        n.NewsTitle, n.NewsSummary, n.PicUrl, n.NewsContent, n.Author,
        n.Source, n.IsDeleted,nt.TypeName,nt.TypeClassName
from    dbo.News n ( nolock )
        join dbo.NewsType nt(nolock) on n.NewsType=nt.TypeId
{0})
select * from n where n.rowNo between {1} and {1} + {2} -1 order by {3}"
                .format(searchCondition, rowStart, pageSize, queryInfo.OrderBy);

            var lstNews = dbParameters.Count > 0
                               ? DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, dbParameters,
                                                             new NewsRowMapper())
                               : DbHelper.QueryWithRowMapper(ConnStringOfSizom, querySql, new NewsRowMapper());
            return new PagedList<NewsDTO>(lstNews, recordCount, pageCount);
        }
        #endregion

        #region  Nested type: NewsRowMapper

        /// <summary>
        /// 绑定对象
        /// </summary>
        private class NewsRowMapper : IDataTableRowMapper<NewsDTO>
        {
            public NewsDTO MapRow(DataRow dataReader)
            {
                var result = new NewsDTO();

                NewsType newsType = new NewsType();
                object obj = dataReader["NewsId"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.NewsId = int.Parse(obj.ToString());
                }
                obj = dataReader["NewsType"];
                if (obj != null && obj != DBNull.Value)
                {
                    newsType.TypeId = ParseHelper.ToInt(obj.ToString(), 0);
                }
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
                obj = dataReader["UpdateTime"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.UpdateTime = DateTime.Parse(obj.ToString());
                }
                result.NewsTitle = dataReader["NewsTitle"].ToString();
                result.NewsSummary = dataReader["NewsSummary"].ToString();
                result.PicUrl = dataReader["PicUrl"].ToString();
                result.NewsContent = dataReader["NewsContent"].ToString();
                result.Author = dataReader["Author"].ToString();
                result.Source = dataReader["Source"].ToString();
                obj = dataReader["IsDeleted"];
                if (obj != null && obj != DBNull.Value)
                {
                    result.IsDeleted = int.Parse(obj.ToString());
                }
                if (dataReader.HasColumn("TypeName"))
                {
                    newsType.TypeName = dataReader["TypeName"].ToString();
                }
                if (dataReader.HasColumn("TypeClassName"))
                {
                    newsType.TypeClassName = dataReader["TypeClassName"].ToString();
                }
                result.NewsType = newsType;
                return result;
            }
        }

        #endregion

        #region  Other Members

        /// <summary>
        /// 构造查询条件
        /// </summary>
        public static string BindQueryCriteria(NewsQueryDTO newsQueryDTO, IDbParameters dbParameters)
        {
            var stringBuilder = new StringBuilder(" where 1=1 ");
            if (newsQueryDTO == null)
            {
                return stringBuilder.ToString();
            }

            //TODO:在此加入查询条件构建代码
            stringBuilder.Append(" and n.IsDeleted=@IsDeleted");
            dbParameters.Add("IsDeleted", DbType.Int32, 4).Value = newsQueryDTO.IsDeleted ? 1 : 0;

            return stringBuilder.ToString();
        }

        #endregion
    }
}