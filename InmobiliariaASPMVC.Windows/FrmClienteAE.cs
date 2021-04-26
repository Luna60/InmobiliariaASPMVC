using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
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
    public partial class FrmClienteAE : Form
    {
        public FrmClienteAE()
        {
            InitializeComponent();
        }

        public ClienteEditDto clienteDto;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        public ClienteEditDto GetProvincia()
        {
            return clienteDto;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (clienteDto == null)
                {
                    clienteDto = new ClienteEditDto();
                }

                clienteDto.Nombre = txtNombre.Text;
                clienteDto.Apellido = txtApellido.Text;
                clienteDto.NroDocumento = txtNroDocumento.Text;
                clienteDto.Direccion = txtDireccion.Text;

                clienteDto.TelefonoMovil = txtTelMovil.Text;
                clienteDto.TelefonoFijo = txtTelFijo.Text;
                clienteDto.CorreoElectronico = txtCorreo.Text;

                clienteDto.TipoDocumentoId = ((TipoDocumentoListDto)cbTipoDocumento.SelectedItem).TipoDocumentoId;
                clienteDto.LocalidadId = ((LocalidadListDto)cbLocalidad.SelectedItem).LocalidadId;
                clienteDto.ProvinciaId = ((ProvinciaListDto)cbProvincia.SelectedItem).ProvinciaId;

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
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Debe ingresar un Nombre");

            }

            if (string.IsNullOrEmpty(txtApellido.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Debe ingresar un Apellido");

            }

            if (string.IsNullOrEmpty(txtNroDocumento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtNroDocumento, "Debe ingresar un NroDocumento");

            }

            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Debe ingresar una Direccion");

            }
            if (cbTipoDocumento.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoDocumento, "Debe seleccionar un Tipo de Documento");

            }

            if (cbLocalidad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbLocalidad, "Debe seleccionar una Localidad");

            }
            if (cbProvincia.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbProvincia, "Debe seleccionar una Provincia");

            }

            if (string.IsNullOrEmpty(txtTelFijo.Text) && string.IsNullOrEmpty(txtTelMovil.Text) && string.IsNullOrEmpty(txtCorreo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelFijo, "Debe ingresar al menos una via de comunicacion");

            }


            return valido;
        }

        internal ClienteEditDto GetCliente()
        {
            return clienteDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Herper.Herper.CargarComboProvincias(ref cbProvincia);
            Herper.Herper.CargarComboLocalidades(ref cbLocalidad);
            Herper.Herper.CargarComboTiposDocumetos(ref cbTipoDocumento);

            if (clienteDto != null)
            {
                txtNombre.Text = clienteDto.Nombre;
                txtApellido.Text = clienteDto.Apellido;
                txtNroDocumento.Text = clienteDto.NroDocumento;
                txtDireccion.Text = clienteDto.Direccion;

                txtTelMovil.Text = clienteDto.TelefonoMovil;
                txtTelFijo.Text = clienteDto.TelefonoFijo;
                txtCorreo.Text = clienteDto.CorreoElectronico;

                cbTipoDocumento.SelectedValue = clienteDto.TipoDocumentoId;
                cbLocalidad.SelectedValue = clienteDto.LocalidadId;
                cbProvincia.SelectedValue = clienteDto.ProvinciaId;
            }

        }

        internal void SetCliente(ClienteEditDto clienteEditDto)
        {
            clienteDto = clienteEditDto;
        }




        public ClienteEditDto GetLocalidad()
        {
            return clienteDto;
        }

        //public ClienteEditDto GetTipoDocumento()
        //{
        //    return clienteDto;
        //}

    }
}
