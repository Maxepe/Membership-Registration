using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial2_PROGIII_110925.Models
{
    public class Socio
    {
        public int pIdSocio { set; get; }
        [Required]
        public string pNombre { set; get; }
        [Required]
        public string pApellido { set; get; }
        [Required]
        public int pIdTipoDocumento{ set; get; }
        [Required]
        public string pNroDocumento { set; get; }
        [Required]
        public int pIdDeporte { set; get; }
    }
}