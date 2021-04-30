using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
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
    public partial class FrmVentasAE : Form
    {
        public FrmVentasAE(IServiciosPropiedades serviciosPropiedades, IServiciosTiposPropiedades servicioTiposPropiedades)
        {
            _serviciosPropiedades = serviciosPropiedades;
            InitializeComponent();
        }


        private Carrito carrito = new Carrito();
        private IMapper _mapper;
        private IServiciosPropiedades _serviciosPropiedades;
        private IServiciosTiposPropiedades _servicioTiposPropiedades;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private VentaEditDto ventaEditDto;

        public VentaEditDto GetVenta()
        {
            return ventaEditDto;
        }

        private void FrmVentasAE_Load(object sender, EventArgs e)
        {
            _mapper = InmobiliariaASPMVC.Mapeador.Mapeador.CrearMapper();
            Herper.Herper.CargarComboTiposPropiedades(ref cbTipoPropiedad);

            cbPropiedades.Enabled = false;

        }

        private void cbTipoPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbTipoPropiedad.SelectedIndex > 0)
            //{

            //    var tipoSeleccionado = (TipoPropiedadListDto)cbTipoPropiedad.SelectedItem;

            //    tipoSeleccionado.TipoPropiedadId =  _servicioTiposPropiedades.GetPropiedadPorId();
            //    //IServiciosPropiedades servicioPropiedad = DI.Create<IServiciosPropiedades>();
            //    var lista = _serviciosPropiedades.GetLista(tipoSeleccionado);////
            //    var defaultPropiedad = new PropiedadListDto
            //    {
            //        PropiedadId = 0,
            //        DescripcionP = " <Seleccione una Propiedad> "
            //    };
            //    lista.Insert(0, defaultPropiedad);
            //    combo.DataSource = lista;
            //    combo.ValueMember = "PropiedadId";
            //    combo.DisplayMember = "DescripcionP";
            //    combo.SelectedIndex = 0;

            //    cbPropiedades.Enabled = true;

            //}
            //else
            //{
            //    cbPropiedades.DataSource = null;
            //    cbPropiedades.Enabled = false;
            //}
            if (cbTipoPropiedad.SelectedIndex > 0)
            {

                var tipoSeleccionado = (TipoPropiedadListDto)cbTipoPropiedad.SelectedItem;
                Herper.Herper.CargarComboPropiedades(tipoSeleccionado.DescripcionTP, ref cbPropiedades);
                cbPropiedades.Enabled = true;

            }
            else
            {
                cbPropiedades.DataSource = null;
                cbPropiedades.Enabled = false;
            }

        }




        private PropiedadListDto propiedadSeleccionado;

        private void cbPropiedades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPropiedades.SelectedIndex > 0)
            {
                propiedadSeleccionado = (PropiedadListDto)cbPropiedades.SelectedItem;
                txtCostoOperacion.Text = propiedadSeleccionado.CostoOperacion.ToString();
                nudValor.Enabled = true;
                //txtTotal.Text = propiedadSeleccionado.ToString();
            }
            else
            {
                propiedadSeleccionado = null;
                txtCostoOperacion.Clear();
                nudValor.Enabled = false;

                //CantidadNumericUpDown.Enabled = false;
            }

        }

        private void btnCancelarPropidad_Click(object sender, EventArgs e)
        {
            InicializarControles();

        }

        private void InicializarControles()
        {
            cbPropiedades.DataSource = null;
            nudValor.Value = 0;
            propiedadSeleccionado = null;
            cbTipoPropiedad.SelectedIndex = 0;
            txtTotal.Clear();
            txtCostoOperacion.Clear();
            //CantidadNumericUpDown.Value = 0;
            cbTipoPropiedad.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarPropiedad())
            {
                Propiedad propiedad = new Propiedad
                {
                    PropiedadId = propiedadSeleccionado.PropiedadId,
                    DescripcionP = propiedadSeleccionado.DescripcionP,
                    CostoOperacion = propiedadSeleccionado.CostoOperacion
                };
                var itemCarrito = new ItemCarrito
                {
                    Propiedad = propiedad,
                    Valor = (int)nudValor.Value
                };
                carrito.AgregarAlCarrito(propiedad, (int)nudValor.Value);
                MostrarDatosEnGrilla();
                CalcularTotal();
                InicializarControles();

            }

        }


        private bool ValidarPropiedad()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbTipoPropiedad.SelectedIndex > 0)
            {
                if (cbPropiedades.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(cbPropiedades, "Debe seleccionar una Propiedad");
                }

                if (nudValor.Value == 0)
                {
                    valido = false;
                    errorProvider1.SetError(nudValor, "Debe colocar precio a la Propiedad");

                }

            }
            else
            {
                valido = false;
                errorProvider1.SetError(cbTipoPropiedad, "Debe seleccionar un Tipo de Propiedad");
            }
            return valido;
        }


        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var itemCarrito in carrito.listaItems)
            {
                var r = ConstruirFila();
                SetearFila(r, itemCarrito);
                AgregarFila(r);

            }
        }

        private void CalcularTotal()
        {
            txtTotal.Text = carrito.TotalCarrito().ToString();
        }


        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemCarrito itemCarrito)
        {
            r.Cells[cmnPropiedad.Index].Value = itemCarrito.Propiedad.DescripcionP;
            r.Cells[cmnValorPropiedad.Index].Value = itemCarrito.Valor;
            r.Cells[cmnCostoOperacion.Index].Value = itemCarrito.Propiedad.CostoOperacion;
            r.Cells[cmnTotal.Index].Value = itemCarrito.Valor + itemCarrito.Propiedad.CostoOperacion;
            r.Tag = itemCarrito;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (propiedadSeleccionado != null)
            {
                txtTotal.Text = (propiedadSeleccionado.CostoOperacion + nudValor.Value).ToString("C");

            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            if (e.ColumnIndex != 4)
            {
                return;
            }

            var r = dgvDatos.SelectedRows[0];
            var item = (ItemCarrito)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el item {item.Propiedad.ToString()}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            carrito.EliminarDelCarrito(item.Propiedad);
            MostrarDatosEnGrilla();
            InicializarControles();


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                List<ItemVentaEditDto> listaItems = new List<ItemVentaEditDto>();
                foreach (var item in carrito.listaItems)
                {
                    ItemVentaEditDto itemDto = new ItemVentaEditDto
                    {
                        Propiedad = _mapper.Map<PropiedadListDto>(item.Propiedad),
                        Valor = item.Valor,
                        PrecioUnitario = item.Propiedad.CostoOperacion

                    };
                    listaItems.Add(itemDto);
                }
                ventaEditDto = new VentaEditDto
                {
                    FechaVenta = DateTime.Now,
                    //ModalidadVenta = ModalidadVenta.TakeAway,
                    //EstadoVenta = EstadoVenta.Finalizada,
                    ItemVentas = listaItems

                };

                carrito.VaciarCarrito();
                DialogResult = DialogResult.OK;

            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return valido;

        }

    }
}
