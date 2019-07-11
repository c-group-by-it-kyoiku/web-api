using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using zipcode1;


namespace zipcode1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "郵便番号";
            label2.Text = "都道府県";
            label3.Text = "ﾄﾄﾞｳﾌｹﾝ";
            label4.Text = "市区町村";
            label5.Text = "ｼｸﾁｮｳｿﾝ";
            label6.Text = "番地";
            label7.Text = "ﾊﾞﾝﾁ";
            button1.Text = "住所を自動で入力する";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient();
            var request = new RestRequest();
            client.BaseUrl = new Uri("http://zipcloud.ibsnet.co.jp/api/search");

            request.Method = Method.GET;
            request.AddParameter("zipcode", textBox1.Text, ParameterType.GetOrPost);
            var response = client.Execute(request);

            var z = Newtonsoft.Json.JsonConvert.DeserializeObject<Zip>(response.Content);
            if (z.results == null)
            {

                textBox2.Text = "住所が存在しません";
                
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";

            }
            else
            {
                textBox2.Text = z.results[0].address1;
                textBox3.Text = z.results[0].kana1;
                textBox4.Text = z.results[0].address2;
                textBox5.Text = z.results[0].kana2;
                textBox6.Text = z.results[0].address3;
                textBox7.Text = z.results[0].kana3;


            }
        }

        
    }
}
