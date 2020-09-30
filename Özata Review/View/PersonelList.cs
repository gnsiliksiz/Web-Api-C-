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
    public partial class PersonelList : Form
    {
        public PersonelList()
        {
            InitializeComponent();
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
            
                List<EmployeeList> nesne = new List<EmployeeList>();
                var i = 0;
                foreach(var item in jsonStatuss)
                {
                    i = i + 1;
                    nesne.Add(new EmployeeList
                    {
                        id = i,
                        AdSoyad=item.AdSoyad,
                        GSM=item.GSM,
                        TCKimlik=item.TCKimlik,
                        EPosta=item.EPosta
                    });
                }
               
                dataGridView1.DataSource = nesne;
            }

        }
      
        public void StyleDataGrid()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.FromArgb(135, 206, 250);
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(135, 206, 250);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        }
        private void PersonelList_Load(object sender, EventArgs e)
        {
            StyleDataGrid();
            var statuss = HttpService.Get("Department");
            dynamic jsonStatus = JsonConvert.DeserializeObject(statuss);
            comboBox1.ValueMember = "UID";
            comboBox1.DisplayMember = "Adi";
            comboBox1.DataSource = jsonStatus;
            comboBox1.Font= new Font("MS Reference Sans Serif", 15);
            textBox1.Font= new Font("MS Reference Sans Serif", 15); 
            button1.Font= new Font("MS Reference Sans Serif", 15);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue!=null  )
            { 
             if(textBox1.Text=="")
                {
                    textBox1.Text = "null";
                    var statuss = HttpService.Get("Employee/Search/" + comboBox1.SelectedValue + "/" + textBox1.Text);
                    textBox1.Text = "";
                    dynamic jsonStatusss = JsonConvert.DeserializeObject(statuss);
                    List<EmployeeList> nesne = new List<EmployeeList>();
                    var i1 = 0;

                    foreach (var item in jsonStatusss)
                    {
                        i1 = i1 + 1;
                        nesne.Add(new EmployeeList
                        {
                            id = i1,
                            AdSoyad = item.AdSoyad,
                            GSM = item.GSM,
                            TCKimlik = item.TCKimlik,
                            EPosta = item.EPosta
                        });
                    }

                    dataGridView1.DataSource = nesne;
                    
                }
                else
                {
                    var statuss = HttpService.Get("Employee/Search/" + comboBox1.SelectedValue + "/" + textBox1.Text);
                    dynamic jsonStatusss = JsonConvert.DeserializeObject(statuss);
                    List<EmployeeList> nesne = new List<EmployeeList>();
                    var i1 = 0;

                    foreach (var item in jsonStatusss)
                    {
                        i1 = i1 + 1;
                        nesne.Add(new EmployeeList
                        {
                            id = i1,
                            AdSoyad = item.AdSoyad,
                            GSM = item.GSM,
                            TCKimlik = item.TCKimlik,
                            EPosta = item.EPosta
                        });
                    }

                    dataGridView1.DataSource = nesne;
                }

            

          
                
            }
            else
            {
                MessageBox.Show("Lütfen departman seçiniz. ");
            }
            
        }
    }
}
