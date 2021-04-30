using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
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
    public partial class FrmBuscarPropiedad : Form
    {
        public FrmBuscarPropiedad()
        {
            InitializeComponent();
        }

        public TipoPropiedadListDto GetTipoPropiedad()
        {
            return tipoPropiedadDto;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();

        }

        public TipoPropiedadListDto tipoPropiedadDto;

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoPropiedadDto = cbTipoPropiedad.SelectedItem as TipoPropiedadListDto;
                DialogResult = DialogResult.OK;
            }


        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbTipoPropiedad.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cbTipoPropiedad, "Debe seleccionar un Tipo de Propiedad");
            }

            return valido;
        }

        private void FrmBuscarPropiedad_Load(object sender, EventArgs e)
        {
            Herper.Herper.CargarComboTiposPropiedades(ref cbTipoPropiedad);

        }

    }
}
