using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace WX.Applications
{
    public class RSAApplication
    {
        /// <summary>
        /// Md5加密 第一种方法
        /// </summary>
        public static void OneMd5()
        {
            byte[] result = Encoding.Default.GetBytes("123");
            MD5 mD5 = new MD5CryptoServiceProvider();
            byte[] output = mD5.ComputeHash(result);
            var a = BitConverter.ToString(output);
            var Md5str = BitConverter.ToString(output).Replace("-", ""); //202CB962AC59075B964B07152D234B70
        }

        /// <summary>
        /// Md5加密 第二种方法
        /// </summary>
        /// <returns></returns>
        public static void TwoMd5()
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            //UTF-16
            byte[] vs = Encoding.Unicode.GetBytes("123");
            byte[] vs1 = mD5.ComputeHash(vs);
            string md5str = null; //5fa285e1bebea6 623e33afc4a1fbd5
            for (var i = 0; i < vs1.Length; i++)
            {
                var d = vs1[i];
                var a = vs1[i].ToString("X");
                var b = vs1[i].ToString("X2");
                var c = vs1[i].ToString("x2");
                md5str += vs1[i].ToString("x");
            }
        }

        /// <summary>
        /// MD5 16位加密 加密后密码为大写
        /// </summary>
        /// <param name="ConvertString"></param>
        /// <returns></returns>
        public static string GetMd5Str()
        {
            string ConvertString = "12dsaddddddasdasdasxnnassdsdsadsdas3sdsajdasdxmask";
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            var aa = md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString));
            var dd = Encoding.Default.GetString(new byte[2]);

            var cc = Convert.ToBase64String(Encoding.UTF8.GetBytes(ConvertString));
            var ee = Convert.FromBase64String("34343ww433");

            var bb= BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString))); //20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70 AC-59-07-5B-96
            string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8); //AC-59-07-5B-96-4B-07-15
            t2 = t2.Replace("-", "");
            return t2;
        }

        /// <summary>
        /// Md5加密 第三种方法
        /// </summary>
        public static void ThreeMd5()
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(System.Text.Encoding.Default.GetBytes("123"));
            var md5str = System.Text.Encoding.Default.GetString(result);
        }

        /// <summary>
        /// md5加密第四种方法
        /// </summary>
        public static void FourMd5()
        {
            string cl = "123";
            string pwd = "";  //202CB962AC5975B964B7152D234B70
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl)); //202CB962AC5975B964B7152D234B70
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符

                pwd = pwd + s[i].ToString("X");

            }
        }



        /// <summary>
        /// Md5加密 第四种方法
        /// </summary>
        public static void FiveMd5() 
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        }

        /// <summary>
        /// SHA1 算法加密
        /// </summary>
        public static void OneSHA1() 
        {
            var buffer = Encoding.UTF8.GetBytes("123");
            var sha1 = SHA1.Create(); 
            var data = sha1.ComputeHash(buffer);
            StringBuilder str = new StringBuilder();  
            foreach (var i in data) 
            {
                str.Append(i.ToString("x2"));
            }
            var c = str.ToString();  //40bd001563085fc35165329ea1ff5c5ecbdbbeef
        }
    }
}
