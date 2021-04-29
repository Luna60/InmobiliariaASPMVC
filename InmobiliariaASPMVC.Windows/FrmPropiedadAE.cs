using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
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
    public partial class FrmPropiedadAE : Form
    {
        public FrmPropiedadAE()
        {
            InitializeComponent();
        }
        private PropiedadEditDto propiedadDto;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (propiedadDto == null)
                {
                    propiedadDto = new PropiedadEditDto();
                }

                propiedadDto.DescripcionP = txtDescripcionP.Text;
                propiedadDto.Observaciones = txtObservacion.Text;

                //propiedadDto.CostoOperacion = txtCosto.Text;
                propiedadDto.CostoOperacion = decimal.Parse(nudCosto.Text);

                //propiedadDto.FechaIngreso = dtpFecha.Value;
                propiedadDto.FechaIngreso = dtpFecha.Value;

                propiedadDto.Disponible = chDisponible.Checked;
                propiedadDto.Garage = chGarage.Checked;
                propiedadDto.Jardin = chJardin.Checked;

                //propiedadDto.Disponible = chDisponible.Checked;
                //propiedadDto.Jardin = chJardin.Checked;
                //propiedadDto.Garage = chGarage.Checked;

                propiedadDto.Ambientes = int.Parse(nudAmbientes.Text);
                propiedadDto.SuperficieTerreno = int.Parse(nudSuperficieTerreno.Text);
                propiedadDto.SuperficieEdificada = int.Parse(nudSuperficieEdificada.Text);

                //propiedadDto.Ambientes = txtAmbientes.Text;
                //propiedadDto.SuperficieTerreno = txtSuperficieT.Text;
                //propiedadDto.SuperficieEdificada = txtSuperficieE.Text;
                propiedadDto.Direccion = txtDireccion.Text;
                propiedadDto.Departamento = txtDepartamento.Text;
                propiedadDto.Cochera = txtCochera.Text;
                propiedadDto.Imagen = txtImagen.Text;


                propiedadDto.ClienteId = ((ClienteListDto)cbCliente.SelectedItem).ClienteId;
                propiedadDto.TipoOperacionId = ((TipoOperacionListDto)cbTipoOperacion.SelectedItem).TipoOperacionId;
                propiedadDto.TipoPropiedadId = ((TipoPropiedadListDto)cbTPropiedad.SelectedItem).TipoPropiedadId;

                propiedadDto.ProvinciaId = ((ProvinciaListDto)cbProvincia.SelectedItem).ProvinciaId;
                propiedadDto.LocalidadId = ((LocalidadListDto)cbLocalidad.SelectedItem).LocalidadId;

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
            if (string.IsNullOrEmpty(txtDescripcionP.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcionP, "Debe ingresar la Descripcion de la Propiedad");

            }

            if (string.IsNullOrEmpty(dtpFecha.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(dtpFecha, "Debe ingresar la Fecha de Ingreso");

            }

            if (string.IsNullOrEmpty(nudCosto.Text))
            {
                valido = false;
                errorProvider1.SetError(nudCosto, "Debe ingresar un Costo");

            }

            if (string.IsNullOrEmpty(txtDireccion.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtDireccion, "Debe ingresar una Direccion");

            }
            if (cbCliente.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbCliente, "Debe seleccionar un Cliente");

            }
            if (cbTipoOperacion.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoOperacion, "Debe seleccionar un Tipo de Operacion");

            }
            if (cbTPropiedad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTPropiedad, "Debe seleccionar un Tipo de Propiedad");

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

            if (string.IsNullOrEmpty(nudAmbientes.Text))
            {
                valido = false;
                errorProvider1.SetError(nudAmbientes, "Debe ingresar cantidad de Ambientes");
            }


            return valido;
        }

        internal PropiedadEditDto GetPropiedad()
        {
            return propiedadDto;
        }

        public PropiedadEditDto GetProvincia()
        {
            return propiedadDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Herper.Herper.CargarComboProvincias(ref cbProvincia);
            Herper.Herper.CargarComboLocalidades(ref cbLocalidad);
            Herper.Herper.CargarComboTiposOperaciones(ref cbTipoOperacion);
            Herper.Herper.CargarComboTiposPropiedades(ref cbTPropiedad);
            Herper.Herper.CargarComboClientes(ref cbCliente);

            if (propiedadDto != null)
            {
                txtDescripcionP.Text = propiedadDto.DescripcionP;
                cbTPropiedad.SelectedValue = propiedadDto.TipoPropiedadId;
                cbTipoOperacion.SelectedValue = propiedadDto.TipoPropiedadId;

                //propiedadDto.FechaIngreso = dtpFecha.Value;
                dtpFecha.Value = propiedadDto.FechaIngreso;

                chJardin.Checked = propiedadDto.Jardin;
                chGarage.Checked = propiedadDto.Garage;


                chDisponible.Checked = propiedadDto.Disponible;
                nudAmbientes.Value = propiedadDto.Ambientes;

                //propiedadDto.Disponible = chDisponible.Checked;
                //propiedadDto.Ambientes = int.Parse(nudAmbientes.Text);

                nudSuperficieTerreno.Value = propiedadDto.SuperficieTerreno;
                nudSuperficieEdificada.Value = propiedadDto.SuperficieEdificada;
                //propiedadDto.SuperficieTerreno = int.Parse(nudSuperficieTerreno.Text);
                //propiedadDto.SuperficieEdificada = int.Parse(nudSuperficieEdificada.Text);

                txtDireccion.Text = propiedadDto.Direccion;
                txtDepartamento.Text = propiedadDto.Departamento;

                propiedadDto.Jardin = chJardin.Checked;
                propiedadDto.Garage = chGarage.Checked;

                txtCochera.Text = propiedadDto.Cochera;

                cbCliente.SelectedValue = propiedadDto.ClienteId;
                cbLocalidad.SelectedValue = propiedadDto.LocalidadId;
                cbProvincia.SelectedValue = propiedadDto.ProvinciaId;

                nudCosto.Value = propiedadDto.CostoOperacion;
                //propiedadDto.CostoOperacion = decimal.Parse(nudCosto.Text);
                txtObservacion.Text = propiedadDto.Observaciones;
                txtImagen.Text = propiedadDto.Imagen;

            }

        }

        internal void SetPropiedad(PropiedadEditDto propiedadEditDto)
        {
            propiedadDto = propiedadEditDto;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
