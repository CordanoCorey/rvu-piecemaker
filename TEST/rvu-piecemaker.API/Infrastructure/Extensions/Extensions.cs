using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;

namespace RvuPiecemaker.Entities.Extensions
{
  public static class Extensions
  {
    public static IEnumerable<TEntity> GetHistory<TEntity>(this RvuPiecemakerContext context, int id) where TEntity : class
    {
      string tableName = typeof(TEntity).Name.ToString();
      var schema = context.Model.FindEntityType(typeof(TEntity)).SqlServer().Schema;
      var sql = $"SELECT * FROM [{schema}].[{tableName}History] WHERE Id = {id}";

      return context.Set<TEntity>().FromSql(sql);
    }

    public static string FirstCharToLower(this string input)
    {
      switch (input)
      {
        case null: throw new ArgumentNullException(nameof(input));
        case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
        default: return input.First().ToString().ToLower() + input.Substring(1);
      }
    }

    public static DataTable ConvertToDataTable<TSource>(this IEnumerable<TSource> source, string[] columnFilter = null, Dictionary<string, string> columnLabels = null)
    {

      var props = typeof(TSource).GetProperties();
      if (columnFilter != null && columnFilter.Any())
      {
        var removeColumns = props.Where(x => !columnFilter.Contains(FirstCharToLower(x.Name)));
        props = props.Except(removeColumns).ToArray();
      }

      IEnumerable<PropertyInfo> newProps = props.Where(x => columnFilter.Select(y => y.ToLower()).Contains(x.Name.ToLower()));

      var dt = new DataTable();
      Dictionary<string, string> columns = columnLabels == null ? newProps.Select(x => x.Name).Aggregate(new Dictionary<string, string>(), (acc, key) =>
      {
        acc.Add(key.ToLower(), key);
        return acc;
      }) : newProps.Select(x => x.Name).Aggregate(new Dictionary<string, string>(), (acc, key) =>
      {
        acc.Add(key.ToLower(), columnLabels.ContainsKey(key.ToLower()) ? columnLabels[key.ToLower()] : key);
        return acc;
      });
      dt.Columns.AddRange(newProps.Select(p => new DataColumn(columns.ContainsKey(p.Name.ToLower()) ? columns[p.Name.ToLower()] : p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType)).ToArray());

      source.ToList().ForEach(
        i => dt.Rows.Add(newProps.Select(p => p.GetValue(i, null)?.ToString().Replace("\"", "''")).ToArray())
      );

      return dt;
    }
  }
}
