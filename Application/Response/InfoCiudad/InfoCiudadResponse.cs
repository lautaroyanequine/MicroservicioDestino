using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response.InfoCiudad
{
    public class InfoCiudadResponse
    {
        public int Id {  get; set; }

        public string Ciudad { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

    }
}
