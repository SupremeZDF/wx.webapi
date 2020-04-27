using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using WX.Model.Model;
using System.IO;
using System.Web;
using System.Xml;
using WX.Model;
using BT.Manage.Tools.Utils;
using System.Linq;

namespace WX.Applications.Applications
{
    public class Applictation
    {


        public static void GetXMLString<T>(T obj) where T : class
        {
            XmlDocument document = new XmlDocument();
            //创建xml声明
            //XmlNode xmldecl = document.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            document.AppendChild(document.CreateXmlDeclaration("1.0", "gb2312", null));
            //document.AppendChild(xmldecl);
            // 创建节点
            // 创建主节点 "元素的前缀","元素的名称"，"元素的命名空间"
            XmlElement Request = document.CreateElement("", "packet", "");
            XmlElement Head = document.CreateElement("head");
            XmlElement Body = document.CreateElement("body");
            //XmlElement BodyNode = null;
            document.AppendChild(Request);
            Request.AppendChild(Head);
            Request.AppendChild(Body);

            //机构ID节点
            if (obj == null)
            {
                //postProcess(document);
                return;
            }
            Type objType = obj.GetType();
            var propers = objType.GetProperties();
            if (propers != null && propers.Length > 0)
            {
                foreach (var propey in propers)
                {
                    var attbutes = propey.GetCustomAttributes(typeof(PFPaymentAttribute), true);
                    if (attbutes != null && attbutes.Length > 0)
                    {
                        var BodyOrHead = attbutes[0] as PFPaymentAttribute;
                        if (BodyOrHead.XmlPayMentBodyOrHead == "head")
                        {
                            var HeadValue = propey.GetValue(obj, null).ToSafeString();
                            //if (HeadValue != null && HeadValue != "")
                            //{
                            var HeadNode = document.CreateElement(propey.Name);
                            HeadNode.InnerText = HeadValue;
                            Head.AppendChild(HeadNode);
                            //}
                        }
                        if (BodyOrHead.XmlPayMentBodyOrHead == "body" && (BodyOrHead.XMLBoadName == null || BodyOrHead.XMLBoadName == ""))
                        {
                           
                            var BodyValue = propey.GetValue(obj, null).ToSafeString();
                            //if (BodyValue != null && BodyValue != "")
                            //{
                            var BodyNode = document.CreateElement(propey.Name);
                            BodyNode.InnerText = BodyValue;
                            Body.AppendChild(BodyNode);
                            //}
                        }
                        if (BodyOrHead.XmlPayMentBodyOrHead == "body" && BodyOrHead.XMLBoadName != null && BodyOrHead.XMLBoadName != "")
                        {
                            var NodeNamePara = BodyOrHead.XMLBoadName;
                            var NodeName = propey.Name;
                            //lists 集合根节点
                            var BodyNode = document.CreateElement(NodeName);
                            BodyNode.SetAttribute("name", NodeNamePara);
                            Body.AppendChild(BodyNode);
                            
                            if (propey.PropertyType.IsGenericType)
                            {
                                var className = propey.PropertyType.GetGenericArguments()[0].Name;
                                var ListObj = propey.GetValue(obj, null);
                                if (ListObj != null)
                                {
                                    //获取list长度
                                    var listCount = (int)ListObj.GetType().GetProperty("Count").GetValue(ListObj, null);
                                    for (var j = 0; j < listCount; j++) 
                                    {
                                        object item = ListObj.GetType().GetProperty("Item").GetValue(ListObj, new object[] { j});
                                        //GetXMLString(item);
                                        var itemPropery = item.GetType().GetProperties();
                                        if (itemPropery.Length > 0 && itemPropery != null) 
                                        {
                                            foreach (var k in itemPropery) 
                                            {
                                                var HeadValue = k.GetValue(item, null).ToSafeString();
                                                var list = document.CreateElement("list");
                                                BodyNode.AppendChild(list);
                                                var HeadNode = document.CreateElement(k.Name);
                                                HeadNode.InnerText = HeadValue;
                                                list.AppendChild(HeadNode);
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Get数据接口
        /// </summary>
        /// 21c7784885cef8b7e006525763f91ff1
        /// <param name="getUrl">接口地址</param>
        /// <returns></returns>
        public static string GetAccess_Token()
        {
            string responseContent = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx3b44e9df72794564&secret=da993f49d2e17d99fd2bc45b9ba0ffa4");
            request.ContentType = "application/json";
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //在这里对接收到的页面内容进行处理
            using (Stream resStream = response.GetResponseStream())
            {
                using (StreamReader stream = new StreamReader(resStream, Encoding.UTF8))
                {
                    responseContent = stream.ReadToEnd().ToString();
                }
            }
            return responseContent;
        }

        public static string GetShouQuanCode()
        {
            var urlcode = HttpUtility.UrlEncode("http://28079fs721.zicp.vip:36411/login/index");
            string responseContent = "";
            var data = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wx56cdb782fe6aaee9&redirect_uri={urlcode}&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(data);
            request.ContentType = "application/json";
            request.Method = "GET";
            var resPonse = (HttpWebResponse)request.GetResponse();
            //在这里对接收到的页面内容进行处理
            using (Stream resStream = resPonse.GetResponseStream())
            {
                using (StreamReader stream = new StreamReader(resStream, Encoding.UTF8))
                {
                    responseContent = stream.ReadToEnd().ToString();
                }
            }
            //foreach (var i in d)
            //{
            //    //if (i.IsGenericParameter)Object does not match target type
            //    //{
            //    var listPropery = i.GetProperties();
            //    if (listPropery.Length > 0 && listPropery != null)
            //    {
            //        foreach (var SingleList in listPropery)
            //        {
            //            var ListBodyValue = SingleList.GetValue(obj, null).ToSafeString("");
            //            //if (ListBodyValue != null && ListBodyValue != "")
            //            //{
            //            var ListBodyNode = document.CreateElement(SingleList.Name);
            //            ListBodyNode.InnerText = ListBodyValue;
            //            BodyNode.AppendChild(BodyNode);
            //            //}
            //        }
            //    }
            //    //}
            //}
            return responseContent;
        }

        public class c
        {
            public string access_token { get; set; }

            public string expires_in { get; set; }

        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        public static void GetMenu()
        {
            var a = GetAccess_Token();

            var d = Newtonsoft.Json.JsonConvert.DeserializeObject<c>(a);

            //HttpUtility.UrlEncode();
            ;
            HttpWebRequest httpWeb = (HttpWebRequest)WebRequest.Create($"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={d.access_token}");
            string resConten = "{\"button\": [{\"name\": \"扫码\",\"sub_button\": [{\"type\": \"scancode_waitmsg\",\name\": \"扫码带提示\",\"key\": \"rselfmenu_0_0\"}, {\"type\": \"scancode_push\", \"name\": \"扫码推事件\", \"key\": \"rselfmenu_0_1\"}]}";
            var responsesContent = "";
            Byte[] bytes = Encoding.UTF8.GetBytes(resConten);
            httpWeb.ContentType = "application/json";
            httpWeb.Method = "Post";
            var resData = "";
            using (Stream stream = httpWeb.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            //CookieContainer

            using (HttpWebResponse web = (HttpWebResponse)httpWeb.GetResponse())
            {
                StreamReader streamReader = new StreamReader(web.GetResponseStream(), Encoding.UTF8);
                responsesContent = streamReader.ReadToEnd();
            }

        }

        /// <summary>
        /// 获取递归
        /// </summary>
        public static void GetDG()
        {
            int i = 0;
            Fibonacci(15);
        }

        public static int Fibonacci(int n)
        {
            if (n < 0)
                return -1;
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
            {
                var i = 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

    }
}
