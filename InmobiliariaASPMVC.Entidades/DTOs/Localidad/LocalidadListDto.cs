﻿using System;

namespace InmobiliariaASPMVC.Entidades.DTOs.Localidad
{
    public class LocalidadListDto : ICloneable
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public string Provincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object GetTipoOperacion()
        {
            throw new NotImplementedException();
        }
    }
}
