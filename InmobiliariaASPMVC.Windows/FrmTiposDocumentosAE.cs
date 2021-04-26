using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
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
    public partial class FrmTiposDocumentosAE : Form
    {
        public FrmTiposDocumentosAE()
        {
            InitializeComponent();
        }
        private TipoDocumentoEditDto tipoDocumentoDto;


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDocumentoDto == null)
                {
                    tipoDocumentoDto = new TipoDocumentoEditDto();

                }

                tipoDocumentoDto.DescripcionTD = txtTipoDocumento.Text;
                DialogResult = DialogResult.OK;
            }


        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTipoDocumento.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTipoDocumento, "Debe ingresar un Tipo de Documento");

            }

            return valido;
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        public TipoDocumentoEditDto GetTipoDocumento()
        {
            return tipoDocumentoDto;
        }

        public void SetTipoDocumento(TipoDocumentoEditDto tipoDocumentoEditDto)
        {
            tipoDocumentoDto = tipoDocumentoEditDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDocumentoDto != null)
            {
                txtTipoDocumento.Text = tipoDocumentoDto.DescripcionTD;
            }
        }


    }
}
