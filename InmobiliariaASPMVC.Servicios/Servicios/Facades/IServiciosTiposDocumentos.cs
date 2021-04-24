using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosTiposDocumentos
    {
        List<TipoDocumentoListDto> GetLista();
        TipoDocumentoEditDto GetTipoDocumentoPorId(int? id);
        void Guardar(TipoDocumentoEditDto tipoDocumento);
        void Borrar(int? id);
        bool Existe(TipoDocumentoEditDto tipoDocumento);

    }
}
