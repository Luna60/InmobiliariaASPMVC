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
    public partial class FrmBuscarPropiedad : Form
    {
        public FrmBuscarPropiedad()
        {
            InitializeComponent();
        }

        public ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        public ProvinciaListDto provinciaDto;

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

        private void FrmBuscarPropiedad_Load(object sender, EventArgs e)
        {
            Herper.Herper.CargarComboProvincias(ref cbProvincia);

        }
    }
}
