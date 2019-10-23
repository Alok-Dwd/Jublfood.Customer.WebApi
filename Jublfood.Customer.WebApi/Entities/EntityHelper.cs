using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Jublfood.POSCustomer.WebApi.Entities
{
    public static class EntityHelper
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                        {
                            if (pro.PropertyType.Name == "DateTime")
                            {
                                dr[column.ColumnName] = Convert.ToDateTime("01/01/1900");
                            }
                            else if (pro.PropertyType.Name == "String")
                            {
                                dr[column.ColumnName] = string.Empty;
                            }
                            else if (pro.PropertyType.Name == "Int32")
                            {
                                dr[column.ColumnName] = 0;
                            }
                            else if (pro.PropertyType.Name == "Decimal")
                            {
                                dr[column.ColumnName] = 0.0m;
                            }
                            else if (pro.PropertyType.Name == "Double")
                            {
                                dr[column.ColumnName] = 0.0d;
                            }
                        }
                        //if (string.IsNullOrEmpty(dr[column.ColumnName].ToString()))
                        //{
                        //    dr[column.ColumnName] = string.Empty;
                        //}                        

                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            return obj;
        }
    }
}
