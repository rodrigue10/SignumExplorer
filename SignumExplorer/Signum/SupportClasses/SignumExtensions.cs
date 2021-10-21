using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using System.IO.Compression;
using System.Numerics;

namespace SignumExplorer.Signum
{
    public static class SignumExtensions
    {
        public static long GetBlockReward(this int blockHeight)
        {


            if (blockHeight == 0)
            {
                return 0;
            }
            if (blockHeight >= 972000)
            {
                // Minimum incentive, lower than 0.6 % per year
                return 10000000000;
            }
            int month = blockHeight / 10800;

            var bigInt = BigInteger.Multiply(BigInteger.Parse("100000000"),BigInteger.Divide(BigInteger.Multiply(BigInteger.Parse("10000"), BigInteger.Pow(BigInteger.Parse("95"), month)), BigInteger.Pow(BigInteger.Parse("100"), month)));

            return (long)bigInt;

        }


        /// <summary>
        /// GZip Compression 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(this byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }

        /// <summary>
        /// GZip Decompression
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(this byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        /// <summary>
        /// Truncate a string to a specifice length and add Elipsis on the end
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="addEllipsis"></param>
        /// <returns></returns>
        public static string Truncate(this string value,
            int maxLength,
            bool addEllipsis = false)
        {
            // Check for valid string before attempting to truncate
            if (string.IsNullOrEmpty(value)) return value;

            // Proceed with truncating
            var result = string.Empty;
            if (value.Length > maxLength)
            {
                result = value.Substring(0, maxLength);
                if (addEllipsis) result += "...";
            }
            else
            {
                result = value;
            }

            return result;
        }

        /// <summary>
        /// Truncate a string to a specifice length and add Elipsis on the end
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="addEllipsis"></param>
        /// <returns></returns>
        public static string RSTrim(this string value)
        {
            // Check for valid string before attempting to truncate
            if (string.IsNullOrEmpty(value)) return value;
            if (value.Length != 22) return value;

            // Proceed with truncating
            var result = value.Substring(0, 6);
            result += "...";
            result += value.Substring(17, 5);


            return result;
        }


        public static string EncodeRS(this ulong value)
        {
            return ReedSolomon.encode(value);
        }

        public static ulong DecodeRS(this string value)
        {
            return ReedSolomon.decode(value);
        }


    public static IEnumerable<T> OrderDynamic<T>(IEnumerable<T> Data, string propToOrder)
    {
        var param = Expression.Parameter(typeof(T));
        var memberAccess = Expression.Property(param, propToOrder);
        var convertedMemberAccess = Expression.Convert(memberAccess, typeof(object));
        var orderPredicate = Expression.Lambda<Func<T, object>>(convertedMemberAccess, param);

        return Data.AsQueryable().OrderBy(orderPredicate).ToArray();
    }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool descending)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp =
                Expression.Call(typeof(Queryable), (descending ? "OrderByDescending" : "OrderBy"),
                    new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
        }

    }




}
