using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
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
    public partial class FrmTiposPropiedades : Form
    {
        public FrmTiposPropiedades(IServiciosTiposPropiedades servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private IMapper _mapper;

        private IServiciosTiposPropiedades _servicio;
        private List<TipoPropiedadListDto> _lista;

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTiposPropiedades_Load(object sender, EventArgs e)
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
            foreach (var tipoPropiedad in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoPropiedad);
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

        private void SetearFila(DataGridViewRow r, TipoPropiedadListDto tipoPropiedad)
        {
            r.Cells[cmnTipoPropiedad.Index].Value = tipoPropiedad.DescripcionTP;

            r.Tag = tipoPropiedad;
        }

        private void QuitarFilaDeGrilla(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoPropiedadAE frm = DI.Create<FrmTipoPropiedadAE>();
            frm.Text = "Agregar un Nuevo Tipo de Propiedad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoPropiedadEditDto tipoPropiedadEditDto = frm.GetTipoPropiedad();
                    if (_servicio.Existe(tipoPropiedadEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoPropiedadEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoPropiedadListDto = _mapper.Map<TipoPropiedadListDto>(tipoPropiedadEditDto);
                    SetearFila(r, tipoPropiedadListDto);
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
            var tipoPropiedadDto = r.Tag as TipoPropiedadListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el Tipo de Propiedad {tipoPropiedadDto.DescripcionTP}?",
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
                _servicio.Borrar(tipoPropiedadDto.TipoPropiedadId);
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
            var tipoPropiedadDto = r.Tag as TipoPropiedadListDto;
            var tipoPropiedadDtoCopia = (TipoPropiedadListDto)tipoPropiedadDto.Clone();
            FrmTipoPropiedadAE frm = DI.Create<FrmTipoPropiedadAE>();
            frm.Text = "Editar Tipo de Propiedad";
            TipoPropiedadEditDto tipoPropiedadEditDto = _mapper.Map<TipoPropiedadEditDto>(tipoPropiedadDto);
            frm.SetTipoPropiedad(tipoPropiedadEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoPropiedadEditDto = frm.GetTipoPropiedad();
            if (_servicio.Existe(tipoPropiedadEditDto))
            {
                MessageBox.Show("Registro repetido :/ ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoPropiedadDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(tipoPropiedadEditDto);
                var tipoPropiedadListDto = _mapper.Map<TipoPropiedadListDto>(tipoPropiedadEditDto);
                SetearFila(r, tipoPropiedadListDto);
                MessageBox.Show("Registro modificado :) ", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoPropiedadDtoCopia);


            }

        }
    }
}
