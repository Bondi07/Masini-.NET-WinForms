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
    public partial class FormPersoana : Form
    {
        public Conexiune conexiune = new Conexiune();

        public FormPersoana()
        {
            InitializeComponent();
            AddPersoana();
            label7.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            try
            {

                Persoana persoana = new Persoana();
                persoana.nume = textBox1.Text;
                persoana.prenume = textBox2.Text;
                persoana.carteIdentitate = int.Parse(textBox3.Text);
                persoana.cnp= int.Parse(textBox4.Text);
                persoana.adresa= textBox5.Text;
                persoana.varsta= int.Parse(textBox6.Text);

                var response = conexiune.InsertPersoana(persoana);

                label7.Text= response.ToString();   
            }
            catch
            {
                label7.Text = "error";
            }

        }

        private void buttonActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {

                Persoana persoana = new Persoana();
                persoana.nume = textBox1.Text;
                persoana.prenume = textBox2.Text;
                persoana.carteIdentitate = int.Parse(textBox3.Text);
                persoana.cnp = int.Parse(textBox4.Text);
                persoana.adresa = textBox5.Text;
                persoana.varsta = int.Parse(textBox6.Text);

                var response = conexiune.UpdatePersoana(persoana);

                label7.Text = response.ToString();

            }
            catch
            {
                label7.Text = "error";

            }

        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            try
            {
                
                int cnp = int.Parse(textBox4.Text); ;
                var response = conexiune.DeletePersoana(cnp);

                label7.Text = response.ToString();

            }
            catch
            {
                label7.Text = "error";

            }
        }


        private void AddPersoana()
        {
            var persoane = conexiune.GetPersoana();

            foreach (var persoana in persoane)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    persoana.nume,
                    persoana.prenume,
                    persoana.carteIdentitate,
                    persoana.cnp,
                    persoana.adresa,
                    persoana.varsta
                });
            }
        }

    }
}
