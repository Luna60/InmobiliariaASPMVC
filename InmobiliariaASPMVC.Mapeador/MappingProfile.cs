using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.ViewModels.Carrito;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Carrito;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.ItemVenta;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.ViewModels.Venta;

namespace InmobiliariaASPMVC.Mapeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadProvinciasMapping();
            LoadLocalidadesMapping();
            LoadPropiedadesMapping();
            LoadClientesMapping();
            LoadTipoPropiedadMapping();
            LoadTipoOperacionMapping();
            LoadTipoDocumentoMapping();

            LoadCarritoMapping();
            LoadItemVentasMapping();
            LoadVentasMapping();


        }

        private void LoadTipoPropiedadMapping()
        {
            CreateMap<TipoPropiedad, TipoPropiedadListDto>();
            CreateMap<TipoPropiedad, TipoPropiedadEditDto>().ReverseMap();

            CreateMap<TipoPropiedadListDto, TipoPropiedadListViewModel>().ReverseMap();
            CreateMap<TipoPropiedadEditDto, TipoPropiedadEditViewModel>().ReverseMap();
            CreateMap<TipoPropiedadEditDto, TipoPropiedadListDto>().ReverseMap();

            //CreateMap<TipoPropiedadCantidadListDto, TipoPropiedadCantidadListViewModel>();

            CreateMap<TipoPropiedadDetailsDto, TipoPropiedadDetailsViewModel>()
                .ForMember(dest => dest.TipoPropiedadListViewModel,
                    act => act
                        .MapFrom(src => src.Tipo))
                .ForMember(dest => dest.PropiedadesVm,

                    act => act
                        .MapFrom(src => src.PropiedadListDto));


        }

        private void LoadTipoOperacionMapping()
        {
            CreateMap<TipoOperacion, TipoOperacionListDto>();
            CreateMap<TipoOperacion, TipoOperacionEditDto>().ReverseMap();


            CreateMap<TipoOperacionListDto, TipoOperacionListViewModel>().ReverseMap();
            CreateMap<TipoOperacionEditDto, TipoOperacionEditViewModel>().ReverseMap();
            CreateMap<TipoOperacionEditDto, TipoOperacionListDto>().ReverseMap();

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
        private void LoadPropiedadesMapping()
        {

            CreateMap<Propiedad, PropiedadListDto>()
           .ForMember(dest => dest.TipoPropiedad, act => act.MapFrom(src => src.TipoPropiedad.DescripcionTP));

            CreateMap<PropiedadListDto, Propiedad>();


            CreateMap<PropiedadListDto, PropiedadListViewModel>();
            CreateMap<PropiedadEditViewModel, PropiedadEditDto>().ReverseMap();
            CreateMap<PropiedadEditDto, Propiedad>().ReverseMap();
            CreateMap<PropiedadEditDto, PropiedadListDto>();

            CreateMap<PropiedadEditDto, PropiedadDetailsViewModel>();
            CreateMap<Propiedad, PropiedadListViewModel>()
                .ForMember(dest => dest.TipoPropiedad, act => act.MapFrom(src => src.TipoPropiedad.DescripcionTP));


        }
        private void LoadClientesMapping()
        {
            //CreateMap<Cliente, ClienteListDto>();
            //CreateMap<Cliente, ClienteEditDto>().ReverseMap();

            CreateMap<ClienteListDto, ClienteListViewModel>();
            CreateMap<ClienteEditViewModel, ClienteEditDto>().ReverseMap();
            CreateMap<ClienteEditDto, Cliente>().ReverseMap();
            CreateMap<ClienteEditDto, ClienteListDto>();

        }


        private void LoadItemVentasMapping()
        {
            CreateMap<ItemVenta, ItemVentaListDto>()
                .ForMember(dest => dest.Propiedad, act => act.MapFrom(src => src.Propiedad.DescripcionP));


            CreateMap<ItemVenta, ItemVentaEditDto>()
                .ForMember(dest => dest.Propiedad, act => act.MapFrom(src => src.Propiedad.DescripcionP)).ReverseMap();
            CreateMap<ItemVentaListDto, ItemVentaListViewModel>();
            CreateMap<ItemVentaEditDto, ItemVentaListDto>().ForMember(dest => dest.Propiedad,
                act => act.MapFrom(src => src.Propiedad.DescripcionP));
        }

        private void LoadVentasMapping()
        {
            CreateMap<Venta, VentaListDto>();

            CreateMap<Venta, VentaEditDto>()
                .ReverseMap();
            CreateMap<VentaListDto, VentaDetailsViewModel>();

            CreateMap<VentaListDto, VentaDetailsViewModel>()
                .ForMember(dest => dest.Detalles, act => act.MapFrom(src => src.ItemVentas));
            CreateMap<VentaListDto, VentaListViewModel>();
            CreateMap<VentaEditDto, VentaListDto>();
        }

        private void LoadCarritoMapping()
        {
            CreateMap<ItemCarrito, ItemCarritoListViewModel>()
                .ForMember(dest => dest.PropiedadListViewModel, act => act.MapFrom(src => src.Propiedad.DescripcionP));


            CreateMap<Propiedad, PropiedadListViewModel>()
            .ForMember(dest => dest.TipoPropiedad, act => act.MapFrom(src => src.TipoPropiedad.DescripcionTP));

            CreateMap<Carrito, CarritoListViewModel>()
                .ForMember(dest => dest.Items, act => act.MapFrom(src => src.listaItems));

        }

    }
}
