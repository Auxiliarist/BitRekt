using System;
using System.Security.Cryptography;
using System.Text;

namespace BitMexAPI.Utils
{
    public static class BitmexAuthentication
    {
        private const int LifetimeSeconds = 60;
        private static readonly DateTime EpochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CreateAuthNonce(long? time = null)
        {
            var timeSafe = time ?? BitmexTime.NowMs();
            return timeSafe * 1000;
        }

        public static string CreateAuthPayload(long nonce)
        {
            return "GET/realtime" + nonce;
        }

        public static string CreateSignature(string key, string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            string ByteToString(byte[] buff)
            {
                var builder = new StringBuilder();

                for (var i = 0; i < buff.Length; i++)
                {
                    builder.Append(buff[i].ToString("X2")); // hex format
                }
                return builder.ToString();
            }

            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return ByteToString(hashmessage).ToLower();
            }
        }

        public static string CreateRestPayload(string verb, string path, long expires, string data)
        {
            return verb + path + expires.ToString() + data;
        }

        public static long CreateRestExpires()
        {
            return (long)(DateTime.UtcNow - EpochTime).TotalSeconds + LifetimeSeconds;
        }

        public static string CreateRestSignature(string secret, string message)
        {
            byte[] signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(secret), Encoding.UTF8.GetBytes(message));
            return ByteArrayToString(signatureBytes);
        }

        private static byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

        private static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}