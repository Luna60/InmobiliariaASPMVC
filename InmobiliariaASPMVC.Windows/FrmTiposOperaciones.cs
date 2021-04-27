using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
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
    public partial class FrmTiposOperaciones : Form
    {
        public FrmTiposOperaciones(IServiciosTiposOperaciones servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private IMapper _mapper;

        private IServiciosTiposOperaciones _servicio;
        private List<TipoOperacionListDto> _lista;


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmTiposOperaciones_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosTiposDocumentos();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
                throw;
            }


        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tipoOperacion in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoOperacion);
                AgregarFila(r);

            }
        }


        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoOperacionListDto tipoOperacion)
        {
            r.Cells[cmnTipoOperacion.Index].Value = tipoOperacion.DescripcionTO;

            r.Tag = tipoOperacion;
        }

        private void QuitarFilaDeGrilla(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoOperacionAE frm = DI.Create<FrmTipoOperacionAE>();
            frm.Text = "Agregar un Nuevo Tipo de Operacion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoOperacionEditDto tipoOperacionEditDto = frm.GetTipoOperacion();
                    if (_servicio.Existe(tipoOperacionEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoOperacionEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoOperacionListDto = _mapper.Map<TipoOperacionListDto>(tipoOperacionEditDto);
                    SetearFila(r, tipoOperacionListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado :) ", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var tipoOperacionDto = r.Tag as TipoOperacionListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el Tipo de Operacion {tipoOperacionDto.DescripcionTO}?",
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
                _servicio.Borrar(tipoOperacionDto.TipoOperacionId);
                dgvDatos.Rows.Remove(r);
                MessageBox.Show("Registro borrado :) ", "Mensaje",
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
            var tipoOperacionDto = r.Tag as TipoOperacionListDto;
            var tipoOperacionDtoCopia = (TipoOperacionListDto)tipoOperacionDto.Clone();
            FrmTipoOperacionAE frm = DI.Create<FrmTipoOperacionAE>();
            frm.Text = "Editar Tipo de Operacion";
            TipoOperacionEditDto tipoOperacionEditDto = _mapper.Map<TipoOperacionEditDto>(tipoOperacionDto);
            frm.SetTipoOperacion(tipoOperacionEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoOperacionEditDto = frm.GetTipoOperacion();
            if (_servicio.Existe(tipoOperacionEditDto))
            {
                MessageBox.Show("Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoOperacionDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(tipoOperacionEditDto);
                var tipoOperacionListDto = _mapper.Map<TipoOperacionListDto>(tipoOperacionEditDto);
                SetearFila(r, tipoOperacionListDto);
                MessageBox.Show("Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoOperacionDtoCopia);


            }

        }
    }
}
