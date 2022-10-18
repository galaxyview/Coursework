using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace RestFulClient
{
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*
            Console.Title = "Restful客户端Demo测试";

            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:7788/";

            client.Method = EnumHttpVerb.GET;
            string resultGet = client.HttpRequest("PersonInfoQuery/王二麻子");
            Console.WriteLine("GET方式获取结果：" + resultGet);

            

            var myRequest = (HttpWebRequest)HttpWebRequest.Create("http://127.0.0.1:7788/PersonInfoQuery/user");
            myRequest.Method = "PUT";
            string param = "Name=张三&ID=1&Age=20";        //参数
            byte[] bs = Encoding.ASCII.GetBytes(param);    //参数转化为ascii码
            myRequest.ContentLength = bs.Length;
            using (Stream reqStream = myRequest.GetRequestStream())

            {

                reqStream.Write(bs, 0, bs.Length);
                

            }
            WebResponse wr = myRequest.GetResponse();

            client.Method = EnumHttpVerb.POST;
            Info info = new Info();
            info.ID = 1;
            info.Name = "张三";
            client.PostData = JsonConvert.SerializeObject(info);//JSon序列化我们用到第三方Newtonsoft.Json.dll
            var resultPost = client.HttpRequest("PersonInfoQuery/Info");
            Console.WriteLine("POST方式获取结果：" + resultPost);
            //Console.Read();
            */

        }
    }

    [Serializable]
    public class Info
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class UserInfo
    {
        public long ID { get; set; }
        public string Password { get; set; }
    }

    [Serializable]
    public class Activity
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }

    public enum StateCodeEnum
    {
        SearchSuccess = 4,
        CreateSuccess = 1,
        ModifySuccess = 2,
        DeleteSuccess = 3,
        Failed = -1,
        NULL = 0
    }
    public class ActivityInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StateCodeEnum StateCode { get; set; }
        public string Message { get; set; }
        public int PeopleLimited { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Level { get; set; }
    }

}
