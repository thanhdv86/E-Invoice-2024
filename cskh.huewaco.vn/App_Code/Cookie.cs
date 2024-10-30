using System.Security.Cryptography;
using System.IO;

namespace cskh.huewaco.vn
{
    public class Encode
    {
        private static readonly byte[] Key192 = { 47, 13, 97, 156, 79, 4, 216, 32, 15, 166, 44, 80, 26, 251, 155, 112, 2, 94, 11, 207, 119, 35, 184, 199 };
        private static readonly byte[] Iv192 = { 51, 108, 242, 77, 36, 99, 167, 34, 42, 8, 62, 83, 188, 7, 219, 13, 135, 23, 201, 59, 173, 11, 121, 223 };
        public static string EncryptTripleDES(string value)
        {
            if (value == "") return "";
            var cryptoProvider = new TripleDESCryptoServiceProvider();
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(Key192, Iv192), CryptoStreamMode.Write);
            var sw = new StreamWriter(cs);
            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return System.Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string DecryptTripleDES(string value)
        {
            if (value == "") return "";
            var cryptoProvider = new TripleDESCryptoServiceProvider();
            var buffer = System.Convert.FromBase64String(value);
            var ms = new MemoryStream(buffer);
            var cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(Key192, Iv192), CryptoStreamMode.Read);
            var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
    public class Cookie
    {
        public static System.Web.HttpCookie GetCookie(string key)
        {
            key = Encode.EncryptTripleDES(key);
            key = System.Web.HttpContext.Current.Server.UrlEncode(key);
            return System.Web.HttpContext.Current.Request.Cookies.Get(key);
        }
        public static string GetCookieValue(System.Web.HttpCookie cookie)
        {
            if (cookie == null) return "";
            var value = cookie.Value;
            value = System.Web.HttpContext.Current.Server.UrlDecode(value);
            //value = Encode.DecryptTripleDES(value);
            return value;
        }

        public static void DeleteCookie(System.Web.HttpCookie cookie, System.DateTime expires)
        {
            if (cookie == null) return;
            cookie.Expires = expires;
            System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
        }
    }
    public class Cryp
    {
        private static readonly byte[] Key192 = { 49, 13, 97, 152, 79, 4, 216, 33, 15, 166, 44, 81, 26, 251, 155, 112, 2, 94, 11, 207, 119, 35, 184, 200 };
        private static readonly byte[] Iv192 = { 51, 108, 242, 74, 36, 99, 167, 37, 48, 8, 62, 83, 188, 7, 209, 13, 135, 23, 201, 59, 173, 15, 121, 223 };
        public static string Encrypt(string value)
        {
            if (value == "") return "";
            var cryptoProvider = new TripleDESCryptoServiceProvider();
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, cryptoProvider.CreateEncryptor(Key192, Iv192), CryptoStreamMode.Write);
            var sw = new StreamWriter(cs);
            sw.Write(value);
            sw.Flush();
            cs.FlushFinalBlock();
            ms.Flush();
            return System.Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        public static string Decrypt(string value)
        {
            if (value == "") return "";
            var cryptoProvider = new TripleDESCryptoServiceProvider();
            var buffer = System.Convert.FromBase64String(value);
            var ms = new MemoryStream(buffer);
            var cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(Key192, Iv192), CryptoStreamMode.Read);
            var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}