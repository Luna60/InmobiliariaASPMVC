using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Mapeador
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadProvinciasMapping();
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
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();
        }
    }
}
