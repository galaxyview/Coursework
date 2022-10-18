using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RestFulClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.listView1.Columns.Add("活动ID", 60, HorizontalAlignment.Left);   //一步添加
            this.listView1.Columns.Add("活动名称", 180, HorizontalAlignment.Left);   //一步添加
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:7788/";
            client.Method = EnumHttpVerb.GET;
            string resultGet = client.HttpRequest("PersonInfoQuery/getInfo");
            string[] arr = resultGet.Split('\\');
            foreach(string item in arr)
            {
                if(item.Length > 2)
                {
                    string[] vi = item.Split(' ');
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = vi[1];
                    lvi.SubItems.Add(vi[0]);
                    this.listView1.Items.Add(lvi);
                }
                    
            }
            
        }

        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modify_Click(object sender, EventArgs e)
        {
            try
            {
                string sel = listView1.SelectedItems[0].ToString();
                int IndexofA = sel.IndexOf("{");
                int IndexofB = sel.IndexOf("}");
                string Ru = sel.Substring(IndexofA + 1, IndexofB - IndexofA - 1);
                RestClient client = new RestClient();
                client.EndPoint = @"http://127.0.0.1:7788/";
                client.Method = EnumHttpVerb.POST;
                ActivityInfo info = new ActivityInfo();
                info.ID = int.Parse(Ru);
                client.PostData = JsonConvert.SerializeObject(info);//JSon序列化我们用到第三方Newtonsoft.Json.dll
                var resultGet = client.HttpRequest("PersonInfoQuery/getSelectedInfo");
                List<ActivityInfo> ActivityInfoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActivityInfo>>("[" + resultGet + "]");
                foreach (ActivityInfo item in ActivityInfoList)
                {
                    info.Date = item.Date;
                    info.PeopleLimited = item.PeopleLimited;
                    info.Message = item.Message;
                    info.Name = item.Name;
                    info.Level = item.Level;
                    info.Location = item.Location;
                }
                Form3 fm3 = new Form3(info, this);
                fm3.Show();
                this.Visible = false;
            }
            catch
            {

            }
            
            
            
            //{"Date":null,"ID":2,"Level":null,"Location":null,"Message":null,"Name":"李四","PeopleLimited":0,"StateCode":4}
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string sel = listView1.SelectedItems[0].ToString();
                int IndexofA = sel.IndexOf("{");
                int IndexofB = sel.IndexOf("}");
                string Ru = sel.Substring(IndexofA + 1, IndexofB - IndexofA - 1);
                RestClient client = new RestClient();
                client.EndPoint = @"http://127.0.0.1:7788/";
                client.Method = EnumHttpVerb.DELETE;
                ActivityInfo info = new ActivityInfo();
                info.ID = int.Parse(Ru);
                client.PostData = JsonConvert.SerializeObject(info);//JSon序列化我们用到第三方Newtonsoft.Json.dll
                var resultGet = client.HttpRequest("PersonInfoQuery/Info");
                refreshList();
            }
            catch
            {

            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            ActivityInfo info = new ActivityInfo();
            Form3 fm3 = new Form3(info,this);
            fm3.Show();
            this.Visible = false;
            //refreshList();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            refreshList();
        }
        public void refreshList()
        {
            listView1.Items.Clear();
            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:7788/";
            client.Method = EnumHttpVerb.GET;
            string resultGet = client.HttpRequest("PersonInfoQuery/getInfo");
            string[] arr = resultGet.Split('\\');
            foreach (string item in arr)
            {
                if (item.Length > 2)
                {
                    string[] vi = item.Split(' ');
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = vi[1];
                    lvi.SubItems.Add(vi[0]);
                    this.listView1.Items.Add(lvi);
                }

            }
        }
    }
}
