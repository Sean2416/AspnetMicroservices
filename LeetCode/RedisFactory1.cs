using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class RedisFactory1
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        /// <summary>
        /// Use connectionString to connection.
        /// </summary>
        static RedisFactory1()
        {
            //var connectionString = "127.0.0.1:6379,127.0.0.1:6380,DefaultDatabase=10";
            var connectionString = "127.0.0.1:6381,defaultDatabase=0";
            var options = ConfigurationOptions.Parse(connectionString);
            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }

        public static ConnectionMultiplexer GetConnection => Connection.Value;
        public static IDatabase RedisDB => GetConnection.GetDatabase();
    }
}
