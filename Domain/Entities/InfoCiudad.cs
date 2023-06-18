using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InfoCiudad
    {
        public int InfoCiudadId { get; set; }

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }

        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }

    }
}
