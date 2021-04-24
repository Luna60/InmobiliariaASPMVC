using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.Entidades;
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
        void Guardar(TipoDocumento tipoDocumento);
        void Borrar(int? id);
        bool Existe(TipoDocumento tipoDocumento);

    }
}
