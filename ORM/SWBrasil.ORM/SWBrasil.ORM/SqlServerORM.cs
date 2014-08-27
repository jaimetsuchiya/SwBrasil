using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWBrasil.ORM
{
    public class SqlServerORM: BaseORM
    {
        protected string QUERY_COLUMNS = "SELECT C.COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, case when tblPK.IndexName is null then 0 else 1 end as PK, tblFK.ReferenceTableName FROM  INFORMATION_SCHEMA.COLUMNS C LEFT JOIN (SELECT  i.name AS IndexName, OBJECT_NAME(ic.OBJECT_ID) AS TableName, COL_NAME(ic.OBJECT_ID,ic.column_id) AS ColumnName FROM    sys.indexes AS i INNER JOIN sys.index_columns AS ic ON  i.OBJECT_ID = ic.OBJECT_ID AND i.index_id = ic.index_id WHERE   i.is_primary_key = 1 ) as tblPK on tblPK.ColumnName = C.COLUMN_NAME and tblPK.TableName = C.TABLE_NAME LEFT JOIN (SELECT f.name AS ForeignKey, OBJECT_NAME(f.parent_object_id) AS TableName, COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName, OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName, COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName FROM sys.foreign_keys AS f INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id) as tblFK ON tblFK.TableName = C.TABLE_NAME AND tblFK.ColumnName = C.COLUMN_NAME WHERE C.TABLE_NAME = N'{0}'";
        protected string QUERY_TABLES = "SELECT * FROM information_schema.tables ORDER BY TABLE_NAME";

        public override bool Connect(string connectionString)
        {
            bool ret = false;
            this.Tables.Clear();

            try
            {
                using(SqlConnection cnx = new SqlConnection(connectionString))
                {
                    cnx.Open();

                    SqlCommand cmd = new SqlCommand(QUERY_TABLES, cnx);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<string> _tables = new List<string>();

                    while (rdr.Read())
                        _tables.Add(rdr.GetString(2));
                    rdr.Close();

                    foreach( string table in _tables)
                        this.Tables.Add(createTableModel(table, cnx));
                    
                    cnx.Close();
                }
            }
            catch (Exception err)
            {
                //TODO: Log Error
            }

            return ret;

        }

        protected virtual TableModel createTableModel(string tableName, SqlConnection connection)
        {
            TableModel ret = new TableModel();

            SqlCommand cmd = new SqlCommand(string.Format(QUERY_COLUMNS, tableName), connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ColumnModel column = new ColumnModel();
                column.Name = rdr.GetString(0);
                column.DbType = rdr.GetString(2);
                if( rdr.IsDBNull(3) == false  || rdr.IsDBNull(4) == false )
                    column.Size = rdr.IsDBNull(3) == false ? rdr.GetInt32(3) : rdr.GetInt32(4);
                else
                    column.Size = null;
                if( rdr.IsDBNull(5) == false )
                    column.Precision = rdr.GetInt32(5);
                else
                    column.Precision = null;

                column.DataType = ConvertDataType(column.DbType);
                column.IsPK = (rdr.GetInt16(6) == 1);
                column.Required = !rdr.GetBoolean(1);
                if (rdr.IsDBNull(7) == false)
                    column.RelatedTable = rdr.GetString(7);

                ret.Columns.Add(column);
            }
            rdr.Close();

            return ret;
        }

        public override string ConvertDataType(string dataBaseType)
        {
            string ret = "String";

            switch (dataBaseType.Trim().ToUpper())
            {
                case "BIGINT":
                    ret = ("Int64");
                    break;

                case "INT":
                    ret = ("Int32");
                    break;

                case "SMALLINT":
                    ret = ("Int16");
                    break;

                case "MONEY":
                case "DECIMAL":
                    ret = ("System.Decimal");
                    break;

                case "DATE":
                case "DATETIME":
                case "SMALLDATETIME":
                case "TIME":
                    ret = ("System.DateTime");
                    break;
            }

            return ret;
        }

    }
}
