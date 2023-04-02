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
    public partial class FormTipMasina : Form
    {
        public Conexiune conexiune = new Conexiune();

        public FormTipMasina()
        {
            InitializeComponent();
            AddTipMasina();
            label3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                tipMasina tipMasina = new tipMasina();
                tipMasina.tip = textBox1.Text;
                tipMasina.comentarii = textBox2.Text;
                

                var response = conexiune.InsertTipMasina(tipMasina);

                label3.Text = response.ToString();
            }
            catch
            {
                label3.Text = "error";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                tipMasina tipMasina = new tipMasina();
                tipMasina.tip = textBox1.Text;
                tipMasina.comentarii = textBox2.Text;


                var response = conexiune.UpdateTipMasina(tipMasina);

                label3.Text = response.ToString();  
            }
            catch
            {
                label3.Text = "error";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string tip = textBox1.Text;
                var response = conexiune.DeleteTipMasina(tip);

                label3.Text = response.ToString();
            }
            catch
            {
                label3.Text = "error";
            }
        }

        private void AddTipMasina()
        {
            ;
            var tipuriMasina = conexiune.GetTipMasina();

            foreach (var tipMasina in tipuriMasina)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    tipMasina.tip,
                    tipMasina.comentarii
                });
            }
        }


    }
}
