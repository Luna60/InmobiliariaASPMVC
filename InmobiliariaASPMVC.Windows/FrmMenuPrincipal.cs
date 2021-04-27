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

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frm = DI.Create<FrmClientes>();
            frm.ShowDialog(this);


        }


        private void btnTipoOpe_Click(object sender, EventArgs e)
        {
            FrmTiposOperaciones frm = DI.Create<FrmTiposOperaciones>();
            frm.ShowDialog(this);

        }

        private void btnTipoPro_Click_1(object sender, EventArgs e)
        {
            FrmTiposPropiedades frm = DI.Create<FrmTiposPropiedades>();
            frm.ShowDialog(this);

        }
    }
}
