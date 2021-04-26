using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InmobiliariaASPMVC.Windows
{
    public partial class FrmBuscarCliente : Form
    {
        public FrmBuscarCliente()
        {
            InitializeComponent();
        }

        public ProvinciaListDto provinciaDto;
        public ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            Herper.Herper.CargarComboProvincias(ref cbProvincia);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                provinciaDto = cbProvincia.SelectedItem as ProvinciaListDto;
                DialogResult = DialogResult.OK;
            }


        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbProvincia, "Debe seleccionar una Provincia");
            }

            return valido;
        }

    }
}
