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
using Özata_Review.Model;

namespace Özata_Review
{
    public partial class PersonelSingle : Form
    {
        public PersonelSingle()
        {
            InitializeComponent();
        }

        private void PersonelSingle_Load(object sender, EventArgs e)
        {
            var statuss = HttpService.Get("Department");
            dynamic jsonStatus = JsonConvert.DeserializeObject(statuss);
            comboBox1.ValueMember = "UID";
            comboBox1.DisplayMember = "Adi";
            comboBox1.DataSource = jsonStatus;
            comboBox2.Enabled = false;
            
            Style();


        }
        private void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


        }
        private void Style()
        {
            comboBox1.Font= new Font("MS Reference Sans Serif", 13);
            comboBox2.Font= new Font("MS Reference Sans Serif", 13);
            textBox1.Font = new Font("MS Reference Sans Serif", 13);
            textBox2.Font = new Font("MS Reference Sans Serif", 13);
            textBox3.Font = new Font("MS Reference Sans Serif", 13);
            textBox4.Font = new Font("MS Reference Sans Serif", 13);
            textBox5.Font = new Font("MS Reference Sans Serif", 13);
            Close.Font= new Font("MS Reference Sans Serif", 13);

        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue.ToString() != null)
            {
                var status = HttpService.Get("Employee/" + comboBox1.SelectedValue);
                dynamic jsonStatuss = JsonConvert.DeserializeObject(status);
                comboBox2.ValueMember = "UID";
                comboBox2.DataSource = jsonStatuss;
                comboBox2.DisplayMember = "AdSoyad";
                comboBox2.Enabled = true;
                Temizle();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var status = HttpService.Get("Employee/Single/" + comboBox2.SelectedValue);
            dynamic jsonStatus = JsonConvert.DeserializeObject(status);
            textBox1.Text = jsonStatus.Adi;
            textBox2.Text = jsonStatus.Soyadi;
            textBox3.Text = jsonStatus.TCKimlik;
            textBox4.Text = jsonStatus.Telefon;
            textBox5.Text = jsonStatus.EPosta;
        }
    }
}
