using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
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
    public partial class FrmVentas : Form
    {
        private readonly IServicioVentas _servicio;
        private IMapper _mapper;
        private List<VentaListDto> _lista;

        public FrmVentas(IServicioVentas servicio)
        {
            InitializeComponent();
            _servicio = servicio;

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
            try
            {
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var ventaListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ventaListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, VentaListDto ventaListDto)
        {
            r.Cells[cmnNroVenta.Index].Value = ventaListDto.VentaId;
            r.Cells[cmnFechaVenta.Index].Value = ventaListDto.FechaVenta.ToShortDateString();

            r.Tag = ventaListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                var ventaDto = (VentaListDto)r.Tag;
                ventaDto = _servicio.GetVentaPorId(ventaDto.VentaId);
                FrmDetalleCompra frm = new FrmDetalleCompra();
                frm.Text = $"Detalles del Pedido {ventaDto.VentaId}";
                frm.SetDetalle(ventaDto.ItemVentas);
                frm.ShowDialog(this);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasAE frm = DI.Create<FrmVentasAE>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var ventaEditDto = frm.GetVenta();
                    _servicio.Guardar(ventaEditDto);
                    var ventaListDto = _mapper.Map<VentaListDto>(ventaEditDto);
                    var r = ConstruirFila();
                    SetearFila(r, ventaListDto);
                    AgregarFila(r);
                    MessageBox.Show("Venta agregada :) ", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }

        }
    }
}
