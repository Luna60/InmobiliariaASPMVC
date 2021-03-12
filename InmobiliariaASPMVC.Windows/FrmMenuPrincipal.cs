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
    }
}
