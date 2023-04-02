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
    public partial class FormExercitii : Form
    {
        public Conexiune conexiune = new Conexiune();

        public FormExercitii()
        {
            InitializeComponent();
            AddEx2();
            AddEx3();
            AddEx5();
            AddEx6();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string adaugaMarca = textBox1.Text;
                var response = conexiune.GetEx4(adaugaMarca);
                string marca = textBox1.Text;
                var ex4 = conexiune.GetEx4(marca);

                foreach (var ex in ex4)
                {
                    dataGridView3.Rows.Add(new object[]
                    {
                        ex.pret,
                        ex.nrMarca
                    
                    

                    });
                }


            }
            catch
            {
                
            }

        }

        private void AddEx2()
        {
            var ex2 = conexiune.GetEx2();

            foreach (var ex in ex2)
            {
                dataGridView1.Rows.Add(new object[]
                {
                    ex.marca,
                    ex.numarMasini,
                    ex.nrMarci

                });
            }
        }


        private void AddEx3()
        {
            var ex3 = conexiune.GetEx3();

            foreach (var ex in ex3)
            {
                dataGridView2.Rows.Add(new object[]
                {
                    ex.pret,
                    ex.marca
                    

                });
            }
        }


        private void AddEx5()
        {
            var ex5 = conexiune.GetEx5();

            foreach (var ex in ex5)
            {
                dataGridView4.Rows.Add(new object[]
                {
                    ex.nrVehicule,
                    ex.nume,
                    ex.prenume,
                    ex.pret,
                    ex.marca
                   

                });
            }
        }
        private void AddEx6()
        {
            var ex6 = conexiune.GetEx6();

            foreach (var ex in ex6)
            {
                dataGridView5.Rows.Add(new object[]
                {
                    ex.carteIdentitate,
                    ex.cnp,
                    ex.adresa,
                    ex.varsta,
                    ex.prenume,
                    ex.nume


                });
            }
        }

    }
}
