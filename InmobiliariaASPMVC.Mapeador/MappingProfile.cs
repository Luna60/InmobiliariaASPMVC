using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento;

namespace InmobiliariaASPMVC.Mapeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadProvinciasMapping();
            LoadLocalidadesMapping();
            //LoadPropiedadesMapping();
            LoadClientesMapping();
            LoadTipoPropiedadMapping();
            LoadTipoOperacionMapping();
            LoadTipoDocumentoMapping();

        }

        private void LoadTipoPropiedadMapping()
        {
            CreateMap<TipoPropiedad, TipoPropiedadListDto>();
            CreateMap<TipoPropiedad, TipoPropiedadEditDto>().ReverseMap();
        }

        private void LoadTipoOperacionMapping()
        {
            CreateMap<TipoOperacion, TipoOperacionListDto>();
            CreateMap<TipoOperacion, TipoOperacionEditDto>().ReverseMap();
        }

        private void LoadTipoDocumentoMapping()
        {
            CreateMap<TipoDocumento, TipoDocumentoListDto>();
            CreateMap<TipoDocumento, TipoDocumentoEditDto>().ReverseMap();

            CreateMap<TipoDocumentoListDto, TipoDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDocumentoEditDto, TipoDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDocumentoEditDto, TipoDocumentoListDto>().ReverseMap();

        }


        //Que significa que cree un mapa?? Va a venir y va a leer cuando acceda a los datos.
        //Cuando el repositorio acceda a la lista de Provincias, en RepositorioProvincia=>GetLista, le esta llegando a ella
        // una lista de Provincia y esta va a pasarla a lista de ProvinciaListDto, esta debe convertir de Provincia a 
        //ProvinciaListDto, ocurre de forma automatica, ya que se basa en la IGUALDAD de nombres.
        //Lo mismo hara para pasar de lista Provincia a lista ProvinciaEditDto.
        //Tambien con ProvinciaListDto, ProvinciaListViewModel, por la capa WEB va a pasar ProvinciaListDto, y debo 
        //mandar una lista de ProvinciaListViewModel.
        private void LoadProvinciasMapping()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();//
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
        }

        private void LoadLocalidadesMapping()
        {
            CreateMap<LocalidadListDto, LocalidadListViewModel>();
            CreateMap<LocalidadEditViewModel, LocalidadEditDto>().ReverseMap();
            CreateMap<LocalidadEditDto, Localidad>().ReverseMap();
            CreateMap<LocalidadEditDto, LocalidadListDto>();
        }
        //private void LoadPropiedadesMapping()
        //{
        //    CreateMap<PropiedadListDto, PropiedadListViewModel>();

        //}
        private void LoadClientesMapping()
        {
            //CreateMap<Cliente, ClienteListDto>();
            //CreateMap<Cliente, ClienteEditDto>().ReverseMap();

            CreateMap<ClienteListDto, ClienteListViewModel>();
            CreateMap<ClienteEditViewModel, ClienteEditDto>().ReverseMap();
            CreateMap<ClienteEditDto, Cliente>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteListDto>();

        }

    }
}
