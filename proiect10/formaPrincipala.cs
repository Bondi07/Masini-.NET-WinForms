using proiect10.Forme;

namespace proiect10
{
    public partial class formaPrincipala : Form
    {
        private Form activeForm;

        public formaPrincipala()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormVehicule(), sender);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormProprietate(), sender);
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

           
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(childForm);
            this.panelPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPersoana(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTipMasina(), sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormExercitii(), sender);
        }
    }
}