using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
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
    public partial class FrmLocalidades : Form
    {
        private IServiciosProvincias _servicioProvincia;
        private IServicioLocalidades _servicio;
        private List<LocalidadListDto> lista;
        private IMapper _mapper;

        public FrmLocalidades(IServicioLocalidades servicio, IServiciosProvincias servicioProvincia)
        {
            InitializeComponent();
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLocalidades_Load(object sender, EventArgs e)
        {
            _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();

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
            foreach (var localidad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, localidad);
                AgregarFila(r);

            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto localidad)
        {
            r.Cells[cmnLocalidad.Index].Value = localidad.NombreLocalidad;
            r.Cells[cmnProvincia.Index].Value = localidad.Provincia;

            r.Tag = localidad;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmLocalidadAE frm = DI.Create<FrmLocalidadAE>();
            frm.Text = "Agregar Localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto localidadEditDto = frm.GetProvincia();
                    if (_servicio.Existe(localidadEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(localidadEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var localidadListDto = _mapper.Map<LocalidadListDto>(localidadEditDto);
                    localidadListDto.Provincia = (_servicioProvincia
                            .GetProvinciaPorId(localidadEditDto.ProvinciaId))
                        .NombreProvincia;
                    SetearFila(r, localidadListDto);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var localidadListDto = r.Tag as LocalidadListDto;
            var localidadListDtoCopia = (LocalidadListDto)localidadListDto.Clone();
            FrmLocalidadAE frm = DI.Create<FrmLocalidadAE>();
            frm.Text = "Editar Localidad";
            LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(localidadListDto.LocalidadId);
            frm.SetLocalidad(localidadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            localidadEditDto = frm.GetProvincia();
            if (_servicio.Existe(localidadEditDto))
            {
                MessageBox.Show(" Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, localidadListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(localidadEditDto);
                localidadListDto = _mapper.Map<LocalidadListDto>(localidadEditDto);
                localidadListDto.Provincia = (_servicioProvincia
                    .GetProvinciaPorId(localidadEditDto.ProvinciaId)).NombreProvincia;
                SetearFila(r, localidadListDto);
                MessageBox.Show(" Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, localidadListDtoCopia);


            }


        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var localidadDto = r.Tag as LocalidadListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la Localidad de {localidadDto.NombreLocalidad}?",
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
                _servicio.Borrar(localidadDto.LocalidadId);
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

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarLocalidad frm = DI.Create<FrmBuscarLocalidad>();
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
