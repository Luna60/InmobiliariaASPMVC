using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
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
    public partial class FrmClientes : Form
    {

        private IServiciosProvincias _servicioProvincia;
        private IServicioLocalidades _servicioLocalidad;
        private IServiciosTiposDocumentos _servicioTipoDocumento;
        private IServiciosClientes _servicio;

        private List<ClienteListDto> lista;
        private IMapper _mapper;

        public FrmClientes(IServiciosClientes servicio, IServiciosProvincias servicioProvincia,
            IServicioLocalidades servicioLocalidad, IServiciosTiposDocumentos servicioTipoDocumento)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoDocumento = servicioTipoDocumento;

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
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
            foreach (var cliente in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, cliente);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ClienteListDto cliente)
        {
            r.Cells[cmnApellido.Index].Value = cliente.Apellido;
            r.Cells[cmnNroDocumento.Index].Value = cliente.NroDocumento;
            r.Cells[cmnTelefonoMovil.Index].Value = cliente.TelefonoMovil;
            r.Cells[cmnLocalidad.Index].Value = cliente.Localidad;
            r.Cells[cmnProvincia.Index].Value = cliente.Provincia;

            r.Tag = cliente;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmClienteAE frm = DI.Create<FrmClienteAE>();
            frm.Text = "Agregar Cliente";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ClienteEditDto clienteEditDto = frm.GetCliente();
                    if (_servicio.Existe(clienteEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(clienteEditDto);
                    DataGridViewRow r = ConstruirFila();

                    var clienteListDto = _mapper.Map<ClienteListDto>(clienteEditDto);

                    clienteListDto.Provincia = (_servicioProvincia
                            .GetProvinciaPorId(clienteEditDto.ProvinciaId))
                        .NombreProvincia;
                    clienteListDto.Localidad = (_servicioLocalidad
                           .GetLocalidadPorId(clienteEditDto.LocalidadId))
                        .NombreLocalidad;

                    SetearFila(r, clienteListDto);
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
            FrmBuscarCliente frm = DI.Create<FrmBuscarCliente>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            var provinciaDto = frm.GetProvincia();
            try
            {
                lista = _servicio.GetLista(provinciaDto.NombreProvincia);
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
            var clienteDto = r.Tag as ClienteListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja al Cliente de {clienteDto.Apellido}?",
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
                _servicio.Borrar(clienteDto.ClienteId);
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
            var clienteListDto = r.Tag as ClienteListDto;
            var clienteListDtoCopia = (ClienteListDto)clienteListDto.Clone();
            FrmClienteAE frm = DI.Create<FrmClienteAE>();
            frm.Text = "Editar Cliente";
            ClienteEditDto clienteEditDto = _servicio.GetClientePorId(clienteListDto.ClienteId);
            frm.SetCliente(clienteEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            clienteEditDto = frm.GetCliente(); 
            if (_servicio.Existe(clienteEditDto))
            {
                MessageBox.Show(" Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, clienteListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(clienteEditDto);
                clienteListDto = _mapper.Map<ClienteListDto>(clienteEditDto);
                clienteListDto.Provincia = (_servicioProvincia
                    .GetProvinciaPorId(clienteEditDto.ProvinciaId)).NombreProvincia;
                clienteListDto.Localidad = (_servicioLocalidad
                    .GetLocalidadPorId(clienteEditDto.LocalidadId)).NombreLocalidad;
 
                SetearFila(r, clienteListDto);
                MessageBox.Show(" Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, clienteListDtoCopia);


            }


        }
    }
}
