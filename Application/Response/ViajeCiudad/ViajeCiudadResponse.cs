﻿using Application.Response.Ciudad;

namespace Application.Response.ViajeCiudad
{
    public class ViajeCiudadResponse
    {
        public int Id { get; set; }
        public int ViajeId { get; set; }
        public CiudadResponse Ciudad { get; set; }
        public string Tipo { get; set; }
    }
}
