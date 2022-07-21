using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public static class RedisHaFactory
    {
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        /// <summary>
        /// Use EndPoint to connection.
        /// </summary>
        static RedisHaFactory()
        {
            ConfigurationOptions options = new ConfigurationOptions
            {
                //對應每個節點的redis server
                EndPoints = { { "127.0.0.1:6379" }, { "127.0.0.1:6380" }, { "127.0.0.1:6381" } },
                 //定義使用的資料庫
                DefaultDatabase =0
            };
            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }

        public static ConnectionMultiplexer GetConnection => Connection.Value;
        public static IDatabase RedisDB => GetConnection.GetDatabase();
    }
}
