using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using System;
using System.Windows.Forms;

namespace InmobiliariaASPMVC.Windows
{
    public partial class FrmBuscarLocalidad : Form
    {
        private ProvinciaListDto provinciaDto;

        public FrmBuscarLocalidad()
        {
            InitializeComponent();
        }

        public ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmBuscarLocalidad_Load(object sender, EventArgs e)
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
