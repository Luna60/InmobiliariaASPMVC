using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using InmobiliariaASPMVC.Windows.Ninject;
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
    public partial class FrmPropiedades : Form
    {
        private IServiciosProvincias _servicioProvincia;
        private IServicioLocalidades _servicioLocalidad;
        private IServiciosTiposOperaciones _servicioTipoOperacion;
        private IServiciosTiposPropiedades _servicioTipoPropiedad;
        private IServiciosClientes _servicioCliente;
        private IServiciosPropiedades _servicio;

        private List<PropiedadListDto> lista;
        private IMapper _mapper;

        public FrmPropiedades(IServiciosPropiedades servicio,
            IServiciosClientes servicioCliente, IServiciosProvincias servicioProvincia,
            IServicioLocalidades servicioLocalidad, IServiciosTiposOperaciones servicioTipoOperacion,
            IServiciosTiposPropiedades servicioTipoPropiedad)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioCliente = servicioCliente;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;

            _servicioTipoOperacion = servicioTipoOperacion;
            _servicioTipoPropiedad = servicioTipoPropiedad;

        }


        //public FrmPropiedades()
        //{
        //    InitializeComponent();
        //}

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPropiedades_Load(object sender, EventArgs e)
        {
            _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
            //MostrarDatosEnGrilla();

        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var propiedad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, propiedad);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, PropiedadListDto propiedad)
        {
            r.Cells[cmnCliente.Index].Value = propiedad.Cliente;
            r.Cells[cmnTipoPropiedad.Index].Value = propiedad.TipoPropiedad;
            r.Cells[cmnDisponible.Index].Value = propiedad.Disponible;
            r.Cells[cmnTipoOperacion.Index].Value = propiedad.TipoOperacion;
            r.Cells[cmnLocalidad.Index].Value = propiedad.Localidad;
            r.Cells[cmnProvincia.Index].Value = propiedad.Provincia;

            r.Tag = propiedad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmPropiedadAE frm = DI.Create<FrmPropiedadAE>();
            frm.Text = "Agregar Propiedad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    PropiedadEditDto propiedadEditDto = frm.GetPropiedad();
                    if (_servicio.Existe(propiedadEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(propiedadEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var propiedadListDto = _mapper.Map<PropiedadListDto>(propiedadEditDto);

                    propiedadListDto.Provincia = (_servicioProvincia
                            .GetProvinciaPorId(propiedadEditDto.ProvinciaId))
                        .NombreProvincia;

                    propiedadListDto.Localidad = (_servicioLocalidad
                           .GetLocalidadPorId(propiedadEditDto.LocalidadId))
                        .NombreLocalidad;

                    propiedadListDto.TipoPropiedad = (_servicioTipoPropiedad
                             .GetTipoPropiedadPorId(propiedadEditDto.TipoPropiedadId))
                        .DescripcionTP;


                    propiedadListDto.TipoOperacion = (_servicioTipoOperacion
                          .GetTipoOperacionPorId(propiedadEditDto.TipoOperacionId))
                        .DescripcionTO;

                    propiedadListDto.Cliente = (_servicioCliente
                             .GetClientePorId(propiedadEditDto.ClienteId))
                        .Apellido;


                    SetearFila(r, propiedadListDto);
                    AgregarFila(r);
                    MessageBox.Show(" Registro agregado :) ", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarPropiedad frm = DI.Create<FrmBuscarPropiedad>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var tipoPropiedadDto = frm.GetTipoPropiedad();
            try
            {
                lista = _servicio.GetLista(tipoPropiedadDto.DescripcionTP);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var propiedadDto = r.Tag as PropiedadListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la Propiedad del Cliente {propiedadDto.Cliente}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(propiedadDto.PropiedadId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show(" Registro borrado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var propiedadListDto = r.Tag as PropiedadListDto;
            var propiedadListDtoCopia = (PropiedadListDto)propiedadListDto.Clone();
            FrmPropiedadAE frm = DI.Create<FrmPropiedadAE>();
            frm.Text = "Editar Propiedad";
            PropiedadEditDto propiedadEditDto = _servicio.GetPropiedadPorId(propiedadListDto.PropiedadId);
            frm.SetPropiedad(propiedadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            propiedadEditDto = frm.GetPropiedad();
            if (_servicio.Existe(propiedadEditDto))
            {
                MessageBox.Show(" Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, propiedadListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(propiedadEditDto);
                propiedadListDto = _mapper.Map<PropiedadListDto>(propiedadEditDto);

                propiedadListDto.Provincia = (_servicioProvincia
                    .GetProvinciaPorId(propiedadEditDto.ProvinciaId)).NombreProvincia;

                propiedadListDto.Localidad = (_servicioLocalidad
                    .GetLocalidadPorId(propiedadEditDto.LocalidadId)).NombreLocalidad;

                propiedadListDto.TipoOperacion = (_servicioTipoOperacion
                      .GetTipoOperacionPorId(propiedadEditDto.TipoOperacionId)).DescripcionTO;

                propiedadListDto.TipoPropiedad = (_servicioTipoPropiedad
                    .GetTipoPropiedadPorId(propiedadEditDto.TipoPropiedadId)).DescripcionTP;

                propiedadListDto.Cliente = (_servicioCliente
                        .GetClientePorId(propiedadEditDto.ClienteId)).Apellido;
  


                SetearFila(r, propiedadListDto);
                MessageBox.Show(" Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, propiedadListDtoCopia);


            }


        }
    }
}
