using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosTiposDocumentos
    {
        List<TipoDocumentoListDto> GetLista();
        TipoDocumentoEditDto GetTipoDocumentoPorId(int? id);

    }
}
