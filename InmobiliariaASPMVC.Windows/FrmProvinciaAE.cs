using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using System;
using System.Windows.Forms;

namespace InmobiliariaASPMVC.Windows
{
    public partial class FrmProvinciaAE : Form
    {
        public FrmProvinciaAE()
        {
            InitializeComponent();
        }
        private ProvinciaEditDto provinciaDto;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public ProvinciaEditDto GetProvincia()
        {
            return provinciaDto;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provinciaDto != null)
            {
                txtProvincia.Text = provinciaDto.NombreProvincia;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaDto == null)
                {
                    provinciaDto = new ProvinciaEditDto();

                }

                provinciaDto.NombreProvincia = txtProvincia.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProvincia.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "Debe ingresar una Provincia");

            }

            return valido;
        }

        public void SetProvincia(ProvinciaEditDto provinciaEditDto)
        {
            provinciaDto = provinciaEditDto;
        }


    }
}
