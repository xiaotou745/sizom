using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AC.Data;

namespace Art.Dao
{
    public class Daobase : AbstractDaoBase
    {
        /// <summary>
        /// DZ数据库连接字符串
        /// </summary>
        protected string ConnStringOfSizom
        {
            get { return GetConnString("ConnStringOfSizom"); }
        }

        /// <summary>
        /// 将Table数据转化为对象列表
        /// </summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="tb">数据表</param>
        /// <returns></returns>
        protected List<T> MapRows<T>(DataTable tb)
        {
            List<T> lstT = new List<T>();

            if (tb != null)
            {
                Type type = typeof (T);
                PropertyInfo[] propertyInfo = type.GetProperties();
                foreach (DataRow row in tb.Rows)
                {
                    T t = (T) type.Assembly.CreateInstance(type.FullName);
                    lstT.Add(t);

                    foreach (DataColumn col in tb.Columns)
                    {
                        var r = propertyInfo.Where(p => p.Name.ToLower() == col.ColumnName.ToLower());
                        if (r.Count() > 0)
                        {
                            PropertyInfo pi = r.First();
                            object obj = (row[col.ColumnName] == DBNull.Value) ? "" : row[col.ColumnName];
                            if (!string.IsNullOrEmpty(obj.ToString()))
                            {
                                if (col.DataType == typeof (DateTime) && pi.PropertyType == typeof (String))
                                    obj = ((DateTime) row[col.ColumnName]).ToString();
                                if (col.DataType == typeof (String) && pi.PropertyType == typeof (DateTime))
                                {
                                    DateTime temp;
                                    obj = DateTime.TryParse(obj.ToString(), out temp);
                                }
                            }
                            //时间类型或者整形,则跳过赋值
                            if (string.IsNullOrEmpty(obj.ToString())
                                && (pi.PropertyType == typeof (DateTime)
                                    || pi.PropertyType == typeof (int)
                                    || pi.PropertyType == typeof (Int16)
                                    || pi.PropertyType == typeof (Int32)
                                    || pi.PropertyType == typeof (Int64)
                                   )
                                )
                                continue;
                            try
                            {
                                pi.SetValue(t, obj, null);
                            }
                            catch (Exception ex)
                            {
                                //throw ex;
                            }
                        }
                    }
                }
            }
            return lstT;
        }

        /// <summary>
        /// DataTable转为List类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTableList<T>(DataTable dt)
        {
            if (dt == null || dt.Rows.Count <= 0)
            {
                return null;
            }
            List<T> ts = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr == null)
                {
                    continue;
                }
                try
                {
                    T t = default(T);
                    Type tbType = typeof (T);
                    t = (T) tbType.Assembly.CreateInstance(tbType.FullName);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        var column = dt.Columns[j];
                        if (string.IsNullOrWhiteSpace(column.ColumnName))
                        {
                            continue;
                        }
                        try
                        {
                            PropertyInfo pi = tbType.GetProperty(column.ColumnName);
                            if (pi == null || dr[j] == null || DBNull.Value == dr[j])
                            {
                                continue;
                            }
                            pi.SetValue(t, dr[j], null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    ts.Add(t);
                }
                catch
                {
                    continue;
                }
            }
            return ts;
        }
    }
}