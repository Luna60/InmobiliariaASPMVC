using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
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
    public partial class FrmTiposDocumentos : Form
    {
        public FrmTiposDocumentos(IServiciosTiposDocumentos servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private IMapper _mapper;

        private IServiciosTiposDocumentos _servicio;
        private List<TipoDocumentoListDto> _lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void FrmTiposDocumentos_Load(object sender, EventArgs e)
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
            foreach (var tipoDocumento in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoDocumento);
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

        private void SetearFila(DataGridViewRow r, TipoDocumentoListDto tipoDocumento)
        {
            r.Cells[cmnTipoDocumento.Index].Value = tipoDocumento.DescripcionTD;

            r.Tag = tipoDocumento;
        }

        private void QuitarFilaDeGrilla(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTiposDocumentosAE frm = DI.Create<FrmTiposDocumentosAE>();
            frm.Text = "Agregar un Nuevo Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDocumentoEditDto tipoDocumentoEditDto = frm.GetTipoDocumento();
                    if (_servicio.Existe(tipoDocumentoEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoDocumentoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoDocumentoListDto = _mapper.Map<TipoDocumentoListDto>(tipoDocumentoEditDto);
                    SetearFila(r, tipoDocumentoListDto);
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
            var tipoDocumentoDto = r.Tag as TipoDocumentoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el Tipo de Documento {tipoDocumentoDto.DescripcionTD}?",
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
                _servicio.Borrar(tipoDocumentoDto.TipoDocumentoId);
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
            var tipoDocumentoDto = r.Tag as TipoDocumentoListDto;
            var tipoDocumentoDtoCopia = (TipoDocumentoListDto)tipoDocumentoDto.Clone();
            FrmTiposDocumentosAE frm = DI.Create<FrmTiposDocumentosAE>();
            frm.Text = "Editar Tipo de Documento";
            TipoDocumentoEditDto tipoDocumentoEditDto = _mapper.Map<TipoDocumentoEditDto>(tipoDocumentoDto);
            frm.SetTipoDocumento(tipoDocumentoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoDocumentoEditDto = frm.GetTipoDocumento();
            if (_servicio.Existe(tipoDocumentoEditDto))
            {
                MessageBox.Show("Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoDocumentoDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(tipoDocumentoEditDto);
                var tipoDocumentoListDto = _mapper.Map<TipoDocumentoListDto>(tipoDocumentoEditDto);
                SetearFila(r, tipoDocumentoListDto);
                MessageBox.Show("Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoDocumentoDtoCopia);


            }

        }
    }
}
