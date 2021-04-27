using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
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
    public partial class FrmTipoOperacionAE : Form
    {
        public FrmTipoOperacionAE()
        {
            InitializeComponent();
        }

        public TipoOperacionEditDto tipoOperacionDto;
        public TipoOperacionEditDto GetTipoOperacion()
        {
            return tipoOperacionDto;
        }

        internal void SetTipoOperacion(TipoOperacionEditDto tipoOperacionEditDto)
        {
            tipoOperacionDto = tipoOperacionEditDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoOperacionDto == null)
                {
                    tipoOperacionDto = new TipoOperacionEditDto();

                }

                tipoOperacionDto.DescripcionTO = txtTipoOpe.Text;
                DialogResult = DialogResult.OK;
            }


        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoOpe.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoOpe, "Debe ingresar un Tipo de Operacion");

            }

            return valido;
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoOperacionDto != null)
            {
                txtTipoOpe.Text = tipoOperacionDto.DescripcionTO;
            }
        }

    }
}
