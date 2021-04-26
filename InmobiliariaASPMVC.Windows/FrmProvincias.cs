using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios;
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
    public partial class FrmProvincias : Form
    {
        public FrmProvincias(IServiciosProvincias servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }
        private IMapper _mapper;

        private IServiciosProvincias _servicio;
        private List<ProvinciaListDto> _lista;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
                //_servicio = new ServiciosProvincias();
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
            foreach (var provincia in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
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

        private void SetearFila(DataGridViewRow r, ProvinciaListDto provincia)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;

            r.Tag = provincia;
        }

        private void QuitarFilaDeGrilla(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciaAE frm = DI.Create<FrmProvinciaAE>();
            frm.Text = "Agregar Nueva Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    if (_servicio.Existe(provinciaEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(provinciaEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var provinciaListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                    SetearFila(r, provinciaListDto);
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja la Provincia {provinciaDto.NombreProvincia}?",
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
                _servicio.Borrar(provinciaDto.ProvinciaId);
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            var provinciaDtoCopia = (ProvinciaListDto)provinciaDto.Clone();
            FrmProvinciaAE frm = DI.Create<FrmProvinciaAE>();
            frm.Text = "Editar Provincia";
            ProvinciaEditDto provinciaEditDto = _mapper.Map<ProvinciaEditDto>(provinciaDto);
            frm.SetProvincia(provinciaEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            provinciaEditDto = frm.GetProvincia();
            if (_servicio.Existe(provinciaEditDto))
            {
                MessageBox.Show("Registro repetido...", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, provinciaDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(provinciaEditDto);
                var provinciaListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                SetearFila(r, provinciaListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, provinciaDtoCopia);


            }

        }
    }
}
