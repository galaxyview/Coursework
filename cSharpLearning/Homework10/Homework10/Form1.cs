using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace Homework10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Task<int> Baidu(string text)
        {
            //创建并设置一个webclient对象，以获得网页信息
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

            //用关键字拼接出url
            string keywords = "";
            foreach (byte b in Encoding.UTF8.GetBytes(text))
            {
                keywords += '%' + b.ToString("X");
            }
            string url = "https://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&tn=baidu&wd=" + keywords;

            //从url上获取数据并转换为文本
            byte[] pageData = MyWebClient.DownloadData(url);
            string pageHtml = Encoding.Default.GetString(pageData); 

            string result = "";
            MatchCollection matches = Regex.Matches(pageHtml, @"[\u4e00-\u9fa5]+", RegexOptions.IgnoreCase);//匹配中文字符
            foreach (Match match in matches)
            {
                result += match.ToString();
            }
            result = result.Substring(0, 199);
            textBox2.Text = result;

            return Task.Run(() => { return 0; });
        }

        private Task<int> Bing(string text)
        {
            //创建并设置一个webclient对象，以获得网页信息
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            MyWebClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.93 Safari/537.36");

            //用关键字拼接出url
            string keywords = "";
            foreach (byte b in Encoding.UTF8.GetBytes(text))
            {
                keywords += '%' + b.ToString("X");
            }
            string url = "https://cn.bing.com/search?q=" + keywords;

            //从url上获取数据并转换为文本
            byte[] pageData = MyWebClient.DownloadData(url);
            string pageHtml = Encoding.Default.GetString(pageData);

            string result = "";
            MatchCollection matches = Regex.Matches(pageHtml, @"[\u4e00-\u9fa5]+", RegexOptions.IgnoreCase);//匹配中文字符
            foreach (Match match in matches)
            {
                result += match.ToString();
            }
            result = result.Substring(0, 199);
            textBox3.Text = result;

            return Task.Run(() => { return 0; });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            RunBaidu(textBox1.Text);
            RunBing(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        async private void RunBaidu(string text)
        {
            label4.Text = "Running...";
            await Baidu(text);
            label4.Text = "";
        }

        async private void RunBing(string text)
        {
            label5.Text = "Running...";
            await Bing(text);
            label5.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
