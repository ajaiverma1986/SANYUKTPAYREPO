using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Commonlib.Data
{
    ////public class DataReaderHelper
    ////{
    ////    private static readonly DataReaderHelper instance = new DataReaderHelper();

    ////    static DataReaderHelper()
    ////    {
    ////    }

    ////    private DataReaderHelper()
    ////    {
    ////    }

    ////    public static DataReaderHelper Instance
    ////    {
    ////        get
    ////        {
    ////            return instance;
    ////        }
    ////    }

    ////    public string GetDBReaderValueAsString(object inVal)
    ////    {
    ////        if (inVal == null || inVal == DBNull.Value)
    ////            return "";
    ////        else
    ////            return inVal.ToString();
    ////    }

    ////    public string SQLParameterReplace(string ParameterValue)
    ////    {
    ////        return ParameterValue.Replace("'", "''");
    ////    }

    ////    public bool IsValueNull(object Value)
    ////    {
    ////        if (Value == null || Value == DBNull.Value)
    ////            return true;
    ////        else
    ////            return false;
    ////    }

    ////    public bool ValidateDouble(string Val)
    ////    {
    ////        try
    ////        {
    ////            double i = double.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool Validatedecimal(string Val)
    ////    {
    ////        try
    ////        {
    ////            decimal i = decimal.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool Validatefloat(string Val)
    ////    {
    ////        try
    ////        {
    ////            float i = float.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateGuid(string Val)
    ////    {
    ////        try
    ////        {
    ////            Guid i = new Guid(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateInt(string Val)
    ////    {
    ////        try
    ////        {
    ////            int i = int.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateShort(string Val)
    ////    {
    ////        try
    ////        {
    ////            int i = short.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateTime(string Val)
    ////    {
    ////        try
    ////        {
    ////            TimeSpan i = TimeSpan.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateLong(string Val)
    ////    {
    ////        try
    ////        {
    ////            long i = long.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateBool(string Val)
    ////    {
    ////        try
    ////        {
    ////            bool i = bool.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateDate(string Val)
    ////    {
    ////        try
    ////        {
    ////            DateTime i = DateTime.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ValidateDateTimeOffset(string Val)
    ////    {
    ////        try
    ////        {
    ////            DateTimeOffset i = DateTimeOffset.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    /// <summary>
    ////    /// This function checks that the given data type is integer. 
    ////    /// </summary>
    ////    /// <param name="Val">Data to validate</param>
    ////    /// <returns>True, if data is valid else, false</returns>
    ////    public bool ValidateByte(string Val)
    ////    {
    ////        try
    ////        {
    ////            int i = byte.Parse(Val);
    ////            return true;
    ////        }
    ////        catch
    ////        {
    ////            return false;
    ////        }
    ////    }

    ////    public bool ColumnExists(System.Data.SqlClient.SqlDataReader reader, string columnName)
    ////    {
    ////        reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName= '" +

    ////        columnName + "'";

    ////        return (reader.GetSchemaTable().DefaultView.Count > 0);
    ////    }

    ////    public string GetDataReaderNullableValue_String(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            return reader[ColumnName].ToString();
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public int? GetDataReaderNullableValue_Int(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateInt(reader[ColumnName].ToString()))
    ////                return int.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public TimeSpan? GetDataReaderNullableValue_Time(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateTime(reader[ColumnName].ToString()))
    ////                return TimeSpan.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public int GetDataReaderValue_Int(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateInt(reader[ColumnName].ToString()))
    ////                return int.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return -1;
    ////        }
    ////        else
    ////        {
    ////            return -1;
    ////        }
    ////    }

    ////    public short GetDataReaderValue_Short(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateShort(reader[ColumnName].ToString()))
    ////                return short.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return -1;
    ////        }
    ////        else
    ////        {
    ////            return -1;
    ////        }
    ////    }

    ////    public short? GetNullDataReaderValue_Short(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateShort(reader[ColumnName].ToString()))
    ////                return short.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public long GetDataReaderValue_Long(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateLong(reader[ColumnName].ToString()))
    ////                return long.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return -1;
    ////        }
    ////        else
    ////        {
    ////            return -1;
    ////        }
    ////    }

    ////    public long? GetNullDataReaderValue_Long(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateLong(reader[ColumnName].ToString()))
    ////                return long.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public object GetDataReaderValue_Object(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////            return (object)(reader[ColumnName]);
    ////        else
    ////            return null;
    ////    }

    ////    public string GetDataReaderValue_String(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] == null || reader[ColumnName] == DBNull.Value)
    ////            return "";
    ////        else
    ////            return reader[ColumnName].ToString();
    ////    }

    ////    public Byte GetDataReaderValue_Byte(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateByte(reader[ColumnName].ToString()))
    ////                return byte.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return 0;
    ////        }
    ////        else
    ////        {
    ////            return 0;
    ////        }
    ////    }

    ////    public byte? GetNullDataReaderValue_Byte(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateByte(reader[ColumnName].ToString()))
    ////                return byte.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public DateTime GetDataReaderValue_DateTime(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateDate(reader[ColumnName].ToString()))
    ////                return DateTime.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return DateTime.MinValue;
    ////        }
    ////        else
    ////            return DateTime.MinValue;
    ////    }

    ////    public DateTimeOffset GetDataReaderValue_DateTimeOffset(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateDateTimeOffset(reader[ColumnName].ToString()))
    ////                return DateTimeOffset.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return DateTimeOffset.MinValue;
    ////        }
    ////        else
    ////            return DateTimeOffset.MinValue;
    ////    }

    ////    public DateTimeOffset? GetNullDataReaderValue_DateTimeOffset(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateDateTimeOffset(reader[ColumnName].ToString()))
    ////                return DateTimeOffset.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public DateTime? GetNullDataReaderValue_DateTime(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateDate(reader[ColumnName].ToString()))
    ////                return DateTime.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public decimal GetDataReaderValue_Decimal(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (Validatedecimal(reader[ColumnName].ToString()))
    ////                return decimal.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return 0;
    ////        }
    ////        else
    ////            return 0;
    ////    }

    ////    public decimal? GetDataReaderNullValue_Decimal(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (Validatedecimal(reader[ColumnName].ToString()))
    ////                return decimal.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////        {
    ////            return null;
    ////        }
    ////    }

    ////    public bool GetDataReaderValue_Bool(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateBool(reader[ColumnName].ToString()))
    ////            {
    ////                return bool.Parse(reader[ColumnName].ToString());
    ////            }
    ////            else
    ////                return false;
    ////        }
    ////        else
    ////            return false;
    ////    }

    ////    public bool? GetDataReaderNullValue_Bool(SqlDataReader reader, string ColumnName)
    ////    {
    ////        if (reader[ColumnName] != null || reader[ColumnName] != DBNull.Value)
    ////        {
    ////            if (ValidateBool(reader[ColumnName].ToString()))
    ////                return bool.Parse(reader[ColumnName].ToString());
    ////            else
    ////                return null;
    ////        }
    ////        else
    ////            return null;
    ////    }
    //}
}
