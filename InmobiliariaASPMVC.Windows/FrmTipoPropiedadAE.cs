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
    public partial class FrmTipoPropiedadAE : Form
    {
        public FrmTipoPropiedadAE()
        {
            InitializeComponent();
        }

        public TipoPropiedadEditDto tipoPropiedadDto;

        public TipoPropiedadEditDto GetTipoPropiedad()
        {
            return tipoPropiedadDto;
        }


        public void SetTipoPropiedad(TipoPropiedadEditDto tipoPropiedadEditDto)
        {
            tipoPropiedadDto = tipoPropiedadEditDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoPropiedadDto == null)
                {
                    tipoPropiedadDto = new TipoPropiedadEditDto();

                }

                tipoPropiedadDto.DescripcionTP = txtTipoPro.Text;
                DialogResult = DialogResult.OK;
            }

        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoPro.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoPro, "Debe ingresar un Tipo de Propiedad");

            }

            return valido;
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoPropiedadDto != null)
            {
                txtTipoPro.Text = tipoPropiedadDto.DescripcionTP;
            }
        }

    }
}
