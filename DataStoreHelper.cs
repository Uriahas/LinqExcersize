using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

using DevExpress.Xpo.DB;

namespace LinqExcersize {
    public static class DataStoreHelper {
        public static IDataStore CreateDataStore() {
            IDataStore result = new InMemoryDataStore();
            ModificationStatement[] dmlStatements = ReadFromFile();
            result.ModifyData(dmlStatements);
            return result;
        }
        static ModificationStatement[] ReadFromFile() {
            IList<string[]> data = File.ReadLines("data.txt")
                .Select(l => l.Split(','))
                .ToList();
            ModificationStatement[] dmlStatements = new ModificationStatement[data.Count];
            DBTable table = CreateTable();
            for(int i = 0; i < dmlStatements.Length; i++) {
                string[] values = data[i];
                InsertStatement stmt = new InsertStatement(table, null);
                stmt.Operands.AddRange(new[] {
                    new QueryOperand("ContactName", null, DBColumnType.String),
                    new QueryOperand("ProductName", null, DBColumnType.String),
                    new QueryOperand("OrderDate", null, DBColumnType.DateTime),
                    new QueryOperand("UnitPrice", null, DBColumnType.Decimal),
                    new QueryOperand("Quantity", null, DBColumnType.Int16),
                    new QueryOperand("Discount", null, DBColumnType.Single)
                });
                stmt.Parameters.AddRange(new[] {
                    new ParameterValue(i * 6 + 0) { DBType = DBColumnType.String, Size = 23, Value = values[0] },
                    new ParameterValue(i * 6 + 1) { DBType = DBColumnType.String, Size = 32, Value = values[1] },
                    new ParameterValue(i * 6 + 2) { DBType = DBColumnType.DateTime, Value = DateTime.Parse(values[2]) },
                    new ParameterValue(i * 6 + 3) { DBType = DBColumnType.Decimal, Value = decimal.Parse(values[3]) },
                    new ParameterValue(i * 6 + 4) { DBType = DBColumnType.Int16, Value = short.Parse(values[4]) },
                    new ParameterValue(i * 6 + 5) { DBType = DBColumnType.Single, Value = float.Parse(values[5]) }
                });
                dmlStatements[i] = stmt;
            }
            return dmlStatements;
        }
        static DBTable CreateTable() {
            DBTable result = new DBTable("Model");
            result.AddColumn(new DBColumn("ID", true, null, 0, DBColumnType.Int32) { IsIdentity = true });
            result.AddColumn(new DBColumn("ContactName", false, null, 23, DBColumnType.String));
            result.AddColumn(new DBColumn("ProductName", false, null, 32, DBColumnType.String));
            result.AddColumn(new DBColumn("OrderDate", false, null, 0, DBColumnType.DateTime));
            result.AddColumn(new DBColumn("UnitPrice", false, null, 0, DBColumnType.Decimal));
            result.AddColumn(new DBColumn("Quantity", false, null, 0, DBColumnType.Int16));
            result.AddColumn(new DBColumn("Discount", false, null, 0, DBColumnType.Single));
            result.PrimaryKey = new DBPrimaryKey(new StringCollection() { "ID" });
            return result;
        }
    }
}
