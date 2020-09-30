using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using Özata_Review.Model;
using System.Diagnostics;

namespace Özata_Review
{
    public partial class Anasayfa : Form
    { 
        public Anasayfa()
        {
            InitializeComponent();
        }
        private  void Anasayfa_Load(object sender, EventArgs e)
        {
            GetIP();
       
            for (int i=1;i<=5;i++)
            {
                if(i==5)
                {
                  
                }
            }
        }
     
        private void PersonelSingle_Click(object sender, EventArgs e)
        {
           
            openChild(new PersonelSingle());

        }

        private void PersonelList_Click(object sender, EventArgs e)
        {
            openChild(new PersonelList());
        }
        private Form activeForm = null;
        private void openChild(Form childForm)
        {
            if(activeForm!=null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
        }
        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            DateTime dateTime = DateTime.Now;
            List<ClientLog> clientLog = new List<ClientLog>();
            IPAddress IPv6 = addr[0];
            IPAddress IPv4 = addr[1];
            clientLog.Add(new ClientLog
            {
                UID = Guid.NewGuid(),
                HostName = strHostName,
                IPv6 = IPv6.ToString(),
                IPv4 = IPv4.ToString(),
                LogDatetime = dateTime


            });
            HttpService.Post(clientLog);


            return addr[addr.Length - 1].ToString();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://erp.ozatashipyard.com/beta/Pages/SistemeGiris.aspx");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            
            this.Close();
            
        }

     

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }

    }
