using proiect10.tabele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proiect10.Forme
{
    public partial class FormProprietate : Form
    {

        public Conexiune conexiune = new Conexiune();
        public FormProprietate()
        {
            InitializeComponent();
            AddProprietate();
            label5.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Proprietate proprietate = new Proprietate();
                proprietate.cnp = long.Parse(textBox1.Text);
                proprietate.nrVehicol = textBox2.Text;
                proprietate.dataCumparari = textBox3.Text;
                proprietate.pret = int.Parse(textBox4.Text);
               

                var response = conexiune.InsertProprietate(proprietate);

                label5.Text = response.ToString(); 
            }
            catch
            {
                label5.Text = "error";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Proprietate proprietate = new Proprietate();
                proprietate.cnp = long.Parse(textBox1.Text);
                proprietate.nrVehicol = textBox2.Text;
                proprietate.dataCumparari = textBox3.Text;
                proprietate.pret = int.Parse(textBox4.Text);

                var response = conexiune.UpdateProprietate(proprietate);

               
                label5.Text = response.ToString();

            }
            catch
            {

                label5.Text = "error";

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                long cnp = long.Parse(textBox1.Text);
                var response = conexiune.DeleteProprietate(cnp);

                label5.Text = response.ToString();
            }
            catch
            {
                label5.Text = "error";
            }
        }

        private void AddProprietate()
        {
            var proprietati = conexiune.GetProprietate();

            foreach (var proprietate in proprietati)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    proprietate.cnp,
                    proprietate.nrVehicol,
                    proprietate.dataCumparari,
                    proprietate.pret
                    
                });
            }
        }


    }
}
