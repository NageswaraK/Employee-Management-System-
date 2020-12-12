using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BAL
{
    public static class Extensions
    {
        public static string GetString(this System.Data.IDataRecord record, string fieldname)
        {
            return GetString(record, fieldname, string.Empty);
        }

        public static string GetString(this System.Data.IDataRecord record, string fieldname, string defaultIfNull)
        {
            object value = record[fieldname];

            if (value is string)
                return (string)value;
            else
                return value == DBNull.Value ? defaultIfNull : value.ToString();
        }

        public static string GetString(this System.Data.IDataRecord record, int index, string defaultIfNull)
        {
            object value = record[index];

            if (value is string)
                return (string)value;
            else
                return value == DBNull.Value ? defaultIfNull : value.ToString();
        }

        public static string GetShortDate(this System.Data.IDataRecord record, string fieldname)
        {
            object value = record[fieldname];

            DateTime? date;
            if (value is DateTime)
                date = (DateTime)value;
            else if (value == DBNull.Value)
                date = null;
            else
                date = Convert.ToDateTime(value);

            return string.Format("{0:M/d/yyyy}", date);
        }

        public static Int16 GetInt16(this System.Data.IDataRecord record, string fieldname)
        {
            return GetInt16(record, fieldname, 0);
        }

        public static Int16 GetInt16(this System.Data.IDataRecord record, string fieldname, Int16 defaultIfNull)
        {
            object value = record[fieldname];

            if (value is Int16)
                return (Int16)value;
            else
                return value == DBNull.Value ? defaultIfNull : Convert.ToInt16(value);
        }

        public static Int32 GetInt32(this System.Data.IDataRecord record, string fieldname)
        {
            return GetInt32(record, fieldname, 0);
        }

        public static Int32 GetInt32(this System.Data.IDataRecord record, string fieldname, Int32 defaultIfNull)
        {
            object value = record[fieldname];

            if (value is Int32)
                return (Int32)value;
            else
                return value == DBNull.Value ? defaultIfNull : Convert.ToInt32(value);
        }

        public static Int64 GetInt64(this System.Data.IDataRecord record, string fieldname)
        {
            return GetInt64(record, fieldname, 0);
        }

        public static Int64 GetInt64(this System.Data.IDataRecord record, string fieldname, Int64 defaultIfNull)
        {
            object value = record[fieldname];

            if (value is Int64)
                return (Int64)value;
            else
                return value == DBNull.Value ? defaultIfNull : Convert.ToInt64(value);
        }

        public static bool GetBoolean(this System.Data.IDataRecord record, string fieldname)
        {
            return GetBoolean(record, fieldname, false);
        }

        public static bool GetBoolean(this System.Data.IDataRecord record, string fieldname, bool defaultIfNull)
        {
            object value = record[fieldname];

            if (value is bool)
                return (bool)value;
            else
                return value == DBNull.Value ? defaultIfNull : Convert.ToBoolean(value);
        }

        public static DateTime GetDateTime(this System.Data.IDataRecord record, string fieldname)
        {
            object value = record[fieldname];

            if (value is DateTime)
                return (DateTime)value;
            else
                return ((value == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(value));
        }

        public static DateTime? GetNullDateTime(this System.Data.IDataRecord record, string fieldname)
        {
            object value = record[fieldname];

            if (value is DateTime)
                return (DateTime)value;
            else if (value == DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(value);
        }

        public static DateTime? GetNullLocalDateTime(this System.Data.IDataRecord record, string fieldname)
        {
            object value = record[fieldname];

            if (value is DateTime)
            {
                DateTime val = (DateTime)value;
                return TimeZone.CurrentTimeZone.ToLocalTime(val);
            }
            else if (value == DBNull.Value)
                return null;
            else
                return Convert.ToDateTime(value);
        }

        public static DateTime GetLocalDateTime(this System.Data.IDataRecord record, string fieldname)
        {
            object value = record[fieldname];
            if (value is DateTime)
            {
                DateTime val = (DateTime)value;
                return TimeZone.CurrentTimeZone.ToLocalTime(val);
            }
            else
                return ((value == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(value));
        }


        public class DbEnumerable : IEnumerable<System.Data.IDataRecord>
        {
            private System.Data.IDataReader reader;

            public DbEnumerable(System.Data.IDataReader reader)
            {
                this.reader = reader;
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return reader.GetEnumerator();
            }

            IEnumerator<System.Data.IDataRecord> IEnumerable<System.Data.IDataRecord>.GetEnumerator()
            {
                return this.OfType<System.Data.IDataRecord>().GetEnumerator();
            }
        }

        public static IEnumerable<System.Data.IDataRecord> GetEnumerable(this System.Data.IDataReader reader)
        {
            return new DbEnumerable(reader);
        }

        public static System.Data.Common.DbEnumerator GetEnumerator(this System.Data.IDataReader reader)
        {
            return new System.Data.Common.DbEnumerator(reader);
        }

        public static byte[] GetBytes(this System.Data.IDataRecord record, string fieldName)
        {
            int Index = record.GetOrdinal(fieldName);
            object Value = record[Index];

            if (Value == DBNull.Value)
            {
                return new byte[] { };
            }
            else
                return (byte[])Value;
        }

        public static string GetSHA1(this string password)
        {
            var UE = new UnicodeEncoding();
            byte[] message = UE.GetBytes(password);

            var hashString = new SHA1Managed();

            byte[] hashValue = hashString.ComputeHash(message);
            return hashValue.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        public static decimal? GetNullableDecimal(this IDataReader reader, int column)
        {
            return reader.IsDBNull(column) ? (decimal?)null :
                Convert.ToDecimal(reader.GetDecimal(column).ToString("f"));
        }

        public static decimal GetFormatDecimal(this IDataReader reader, int column)
        {
            return Convert.ToDecimal(reader.GetDecimal(column).ToString("f"));
        }

        //public static string GetShortDate(this object value)
        //{
        //    DateTime? date;
        //    if (value is DateTime)
        //        date = (DateTime)value;
        //    else if (value == DBNull.Value)
        //        date = null;
        //    else
        //        date = Convert.ToDateTime(value);

        //    return string.Format("{0:M/d/yyyy}", date);
        //}

        #region Preferences Extensions

        public static string ToPreferenceDateTime(this DateTime dateTime, string dateFormat)
        {
            //DateTime parsedDate;
            //if (DateTime.TryParseExact(dateTime.ToString(), dateFormat, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            //{
            //    return parsedDate.ToString();
            //}
            if (!string.IsNullOrEmpty(dateFormat))
            {
                return dateTime.ToString(dateFormat);
            }
            return dateTime.ToString("MM/dd/yyyy");
        }

        public static string ToPreferenceDateTime(this DateTime? dateTime, string dateFormat)
        {
            if (dateTime.HasValue)
            {
                if (!string.IsNullOrEmpty(dateFormat))
                    return dateTime.Value.ToString(dateFormat);
                return dateTime.Value.ToString("MM/dd/yyyy");
            }
            return string.Empty;

            //if (dateTime.HasValue)
            //{
            //    if (!string.IsNullOrEmpty(dateFormat))
            //    {
            //        return  dateTime.ToString();
            //    }
            //    return dateTime.ToString("MM/dd/yyyy");
            //}
        }

        public static string ToPrefernceNumber(this string numberFormat, string formatType)
        {
            return string.Empty;
        }

        public static string ToPrefernceCurrentcy(this int currency, string formatType)
        {
            CultureInfo culture = new CultureInfo(formatType);
            return currency.ToString("c", culture);
        }

        public static string ToPrefernceCurrentcy(this decimal currency, string formatType)
        {
            CultureInfo culture = new CultureInfo("en-US");
            return currency.ToString("c", culture);
        }

        public static string RemoveCurrencySymbol(string Amount)
        {
            if (Amount != "")
            {
                Amount = Amount.Replace("$", "").Replace(",", "").Replace(" ", "");
            }

            return Amount;
        }
        #endregion


    }
}
