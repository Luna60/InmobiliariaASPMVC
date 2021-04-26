using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using InmobiliariaASPMVC.Windows.Ninject;
using System.Windows.Forms;
using System;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;

namespace InmobiliariaASPMVC.Windows.Herper
{
    public class Herper
    {
        public static void CargarComboProvincias(ref ComboBox combo)
        {
            IServiciosProvincias servicioProvincia = DI.Create<IServiciosProvincias>();
            var lista = servicioProvincia.GetLista();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = " <Seleccione una Provincia> "
            };
            lista.Insert(0, defaultProvincia);
            combo.DataSource = lista;
            combo.ValueMember = "ProvinciaId";
            combo.DisplayMember = "NombreProvincia";
            combo.SelectedIndex = 0;

        }


        public static void CargarComboTiposDocumetos(ref ComboBox combo)
        {
            IServiciosTiposDocumentos servicioTipoDocumento = DI.Create<IServiciosTiposDocumentos>();
            var lista = servicioTipoDocumento.GetLista();
            var defaultTipoDocumento = new TipoDocumentoListDto
            {
                TipoDocumentoId = 0,
                DescripcionTD = " <Seleccione un Tipo de Documento> "
            };
            lista.Insert(0, defaultTipoDocumento);
            combo.DataSource = lista;
            combo.ValueMember = "TipoDocumentoId";
            combo.DisplayMember = "DescripcionTD";
            combo.SelectedIndex = 0;

        }


        public static void CargarComboLocalidades(ref ComboBox combo)
        {
            IServicioLocalidades servicioLocalidad = DI.Create<IServicioLocalidades>();
            var lista = servicioLocalidad.GetLista(null);
            var defaultLocalidad = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = " <Seleccione una Localidad> "
            };
            lista.Insert(0, defaultLocalidad);
            combo.DataSource = lista;
            combo.ValueMember = "LocalidadId";
            combo.DisplayMember = "NombreLocalidad";
            combo.SelectedIndex = 0;

        }


        public static void CargarComboTiposOperaciones(ref ComboBox combo)
        {
            IServiciosTiposOperaciones servicioTipoOperacion = DI.Create<IServiciosTiposOperaciones>();
            var lista = servicioTipoOperacion.GetLista();
            var defaultTipoOperacion = new TipoOperacionListDto
            {
                TipoOperacionId = 0,
                DescripcionTO = " <Seleccione un Tipo de Operacion> "
            };
            lista.Insert(0, defaultTipoOperacion);
            combo.DataSource = lista;
            combo.ValueMember = "TipoOperacionId";
            combo.DisplayMember = "DescripcionTO";
            combo.SelectedIndex = 0;

        }


        public static void CargarComboTiposPropiedades(ref ComboBox combo)
        {
            IServiciosTiposPropiedades servicioTipoPropiedad = DI.Create<IServiciosTiposPropiedades>();
            var lista = servicioTipoPropiedad.GetLista();
            var defaultTipoPropiedad = new TipoPropiedadListDto
            {
                TipoPropiedadId = 0,
                DescripcionTP = " <Seleccione un Tipo de Propiedad> "
            };
            lista.Insert(0, defaultTipoPropiedad);
            combo.DataSource = lista;
            combo.ValueMember = "TipoPropiedadId";
            combo.DisplayMember = "DescripcionTP";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboClientes(ref ComboBox combo)
        {
            IServiciosClientes servicioCliente = DI.Create<IServiciosClientes>();
            var lista = servicioCliente.GetLista(null);
            var defaultCliente = new ClienteListDto
            {
                ClienteId = 0,
                Apellido = " <Seleccione un Cliente> "
            };
            lista.Insert(0, defaultCliente);
            combo.DataSource = lista;
            combo.ValueMember = "ClienteId";
            combo.DisplayMember = "Apellido";
            combo.SelectedIndex = 0;

        }

    }
}
