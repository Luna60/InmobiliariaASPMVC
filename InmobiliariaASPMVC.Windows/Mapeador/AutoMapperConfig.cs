using AutoMapper;
using InmobiliariaASPMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Windows.Mapeador
{
    public class AutoMapperConfig
    {
        //Esto lo que hace es disparar el Mapeador
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = config.CreateMapper();
        }

    }
}
