using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using InmobiliariaASPMVC.Windows.Ninject;
using System.Windows.Forms;
using System;

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

    }
}
