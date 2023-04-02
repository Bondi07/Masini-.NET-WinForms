using proiect10.tabele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect10.Forme
{
    public partial  class FormVehicule : Form
    {

        public Conexiune conexiune = new Conexiune();


        public FormVehicule()
        {
            InitializeComponent();
            label9.Text = "";
            AddVehicule();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {

            try
            {
                
                Vehicul vehicul = new Vehicul();
                vehicul.nrVehicul = textBox1.Text;
                vehicul.marca = textBox2.Text;
                vehicul.tip = textBox3.Text;
                vehicul.serieMotor= int.Parse(textBox4.Text);
                vehicul.serieCaroserie = int.Parse(textBox5.Text);
                vehicul.carburant = textBox6.Text;
                vehicul.culoare = textBox7.Text;
                vehicul.capacitateCil = int.Parse(textBox8.Text);


                var response = conexiune.InsertVehicul(vehicul);
                label9.Text = response;

            }
            catch
            {
                label9.Text = "erroare";
            }

        }

        private void buttonActualizeaza_Click(object sender, EventArgs e)
        {

            try
            {

                Vehicul vehicul = new Vehicul();
                vehicul.nrVehicul = textBox1.Text;
                vehicul.marca = textBox2.Text;
                vehicul.tip = textBox3.Text;
                vehicul.serieMotor = int.Parse(textBox4.Text);
                vehicul.serieCaroserie = int.Parse(textBox5.Text);
                vehicul.carburant = textBox6.Text;
                vehicul.culoare = textBox7.Text;
                vehicul.capacitateCil = int.Parse(textBox8.Text);


                var response = conexiune.UpdateVehicul(vehicul);
                label9.Text = response;

            }
            catch
            {
                label9.Text = "error!";

            }

        }

        private void buttonSterge_Click(object sender, EventArgs e)
        {
            try
            {
;
                string nrVehicul = textBox1.Text;
                var response = conexiune.DeleteVehicul(nrVehicul);
                label9.Text = response;
            }
            catch
            {
                label9.Text = "error";
            }
        }


        private void AddVehicule()
        {
            ;
            var vehicule = conexiune.GetVehicul();

            foreach (var vehicul in vehicule)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    vehicul.nrVehicul,
                    vehicul.marca,
                    vehicul.tip,
                    vehicul.serieMotor,
                    vehicul.serieCaroserie,
                    vehicul.carburant,
                    vehicul.culoare,
                    vehicul.capacitateCil
                });
            }
        }

    }
}
