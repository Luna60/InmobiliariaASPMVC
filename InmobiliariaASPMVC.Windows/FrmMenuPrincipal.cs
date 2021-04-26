using InmobiliariaASPMVC.Windows.Ninject;
using System;
using System.Windows.Forms;

namespace InmobiliariaASPMVC.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincias frm = DI.Create<FrmProvincias>();
            frm.ShowDialog(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = DI.Create<FrmLocalidades>();
            frm.ShowDialog(this);

        }

        private void btnTipoDoc_Click(object sender, EventArgs e)
        {
            FrmTiposDocumentos frm = DI.Create<FrmTiposDocumentos>();
            frm.ShowDialog(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmClientes frm = DI.Create<FrmClientes>();
            frm.ShowDialog(this);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmPropiedades frm = DI.Create<FrmPropiedades>();
            frm.ShowDialog(this);

        }
    }
}
