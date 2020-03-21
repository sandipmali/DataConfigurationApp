using System;
using System.Collections.Generic;

namespace DataConfigurationApp.Model
{
    public class JsonRootModel
    {
        public Organization organization { get; set; }
        public Configuration configuration { get; set; }
    }

    public class Organization
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string configuredBy { get; set; }
        public DateTime configuredAt { get; set; }
    }

    public class Http
    {
        public int step { get; set; }
        public string method { get; set; }
        public string url { get; set; }
    }

    public class AzureSql
    {
        public int step { get; set; }
        public string type { get; set; }
        public string commandText { get; set; }
        public string connectionString { get; set; }
    }

    public class Action
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool visible { get; set; }
        public List<object> steps { get; set; }
        public List<Http> http { get; set; }
        public List<AzureSql> azureSql { get; set; }
    }

    public class Column
    {
        public string column { get; set; }
        public string displayName { get; set; }
        public string dataType { get; set; }
        public bool allowNulls { get; set; }
        public bool identity { get; set; }
        public string inputType { get; set; }
        public bool visible { get; set; }
        public bool enabled { get; set; }
    }

    public class PrimaryKey
    {
        public string column { get; set; }
    }

    public class Column2
    {
        public string column { get; set; }
    }

    public class UniqueKey
    {
        public List<Column2> columns { get; set; }
    }

    public class Table
    {
        public string table { get; set; }
        public string displayName { get; set; }
        public bool allowRowInsert { get; set; }
        public bool allowRowDelete { get; set; }
        public List<Column> columns { get; set; }
        public List<PrimaryKey> primaryKeys { get; set; }
        public List<object> foreignKeys { get; set; }
        public List<UniqueKey> uniqueKeys { get; set; }
    }

    public class Databas
    {
        public string displayName { get; set; }
        public string connectionString { get; set; }
        public bool enabled { get; set; }
        public List<Table> tables { get; set; }
    }

    public class Configuration
    {
        public List<Action> actions { get; set; }
        public List<Databas> databases { get; set; }
    }
}
