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
    public partial class Form3 : Form
    {

        Form2 form2;
        public Form3(ActivityInfo Info,Form2 fm2)
        {
            InitializeComponent();
            DatetextBox.Text = Info.Date;
            messagetextBox.Text = Info.Message;
            NametextBox.Text = Info.Name;
            LocationtextBox.Text = Info.Location;
            PeopleLimitedtextBox.Text = Info.PeopleLimited.ToString();
            ActivityID.Text = Info.ID.ToString();
            LeveltextBox.Text = Info.Level;
            form2 = fm2;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivityInfo info = new ActivityInfo();
            info.Date = DatetextBox.Text;
            info.PeopleLimited = int.Parse(PeopleLimitedtextBox.Text);
            info.Message = messagetextBox.Text;
            info.Name = NametextBox.Text;
            info.Level = LeveltextBox.Text;
            info.Location = LocationtextBox.Text;
            info.ID = int.Parse(ActivityID.Text);
            RestClient client = new RestClient();
            client.EndPoint = @"http://127.0.0.1:7788/";
            client.Method = EnumHttpVerb.PUT;
            client.PostData = JsonConvert.SerializeObject(info);
            string resultGet = client.HttpRequest("PersonInfoQuery/Info");
            form2.Visible = true;
            form2.refreshList();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
