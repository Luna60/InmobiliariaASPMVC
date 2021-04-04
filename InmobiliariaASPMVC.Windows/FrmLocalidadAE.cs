using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
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
    public partial class FrmLocalidadAE : Form
    {
        private ProvinciaListDto provinciaDto;
        private LocalidadEditDto localidadDto;

        public FrmLocalidadAE()
        {
            InitializeComponent();
        }

        //public ProvinciaListDto GetProvincia()
        //{
        //    return provinciaDto;
        //}
        public LocalidadEditDto GetProvincia()
        {
            return localidadDto;
        }

        internal void SetLocalidad(LocalidadEditDto localidadEditDto)
        {
            localidadDto = localidadEditDto;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (localidadDto == null)
                {
                    localidadDto = new LocalidadEditDto();
                }

                localidadDto.NombreLocalidad = txtLocalidad.Text;
                localidadDto.ProvinciaId = ((ProvinciaListDto)cbProvincia.SelectedItem).ProvinciaId;
                //productoDto.Precio = decimal.Parse(PrecioTextBox.Text);
                //productoDto.Activo = ActivoCheckBox.Checked;
                //productoDto.Imagen = _rutaDelArchivo;
                DialogResult = DialogResult.OK;

            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtLocalidad.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "Debe ingresar una Localidad");

            }
            if (cbProvincia.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(cbProvincia, "Debe seleccionar una Provincia");

            }

            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Herper.Herper.CargarComboProvincias(ref cbProvincia);
            if (localidadDto != null)
            {
                txtLocalidad.Text = localidadDto.NombreLocalidad;
                cbProvincia.SelectedValue = localidadDto.ProvinciaId;
            }

        }

    }
}
