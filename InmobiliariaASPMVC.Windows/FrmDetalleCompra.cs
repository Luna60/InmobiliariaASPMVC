using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
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
    public partial class FrmDetalleCompra : Form
    {
        public FrmDetalleCompra()
        {
            InitializeComponent();
        }


        private List<ItemVentaListDto> _lista;
        public void SetDetalle(List<ItemVentaListDto> listaDetalle)
        {
            _lista = listaDetalle;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var item in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, item);
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

        private void SetearFila(DataGridViewRow r, ItemVentaListDto item)
        {
            r.Cells[cmnPropiedad.Index].Value = item.Propiedad;
            //r.Cells[cmnPrecioUnitario.Index].Value = item.PrecioUnitario;
            r.Cells[cmnTotal.Index].Value = item.Total;

        }

    }
}
