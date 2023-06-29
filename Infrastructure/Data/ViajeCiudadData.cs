using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class ViajeCiudadData : IEntityTypeConfiguration<ViajeCiudad>
    {
        public void Configure(EntityTypeBuilder<ViajeCiudad> entityBuilder)
        {
            entityBuilder.HasData
            (
                new ViajeCiudad
                {
                    ViajeCiudadId = 1,
                    ViajeId = 1,
                    CiudadId = 1,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 2,
                    ViajeId = 1,
                    CiudadId = 2,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 3,
                    ViajeId = 1,
                    CiudadId = 3,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 4,
                    ViajeId = 1,
                    CiudadId = 4,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 5,
                    ViajeId = 1,
                    CiudadId = 5,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 6,
                    ViajeId = 2,
                    CiudadId = 6,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 7,
                    ViajeId = 2,
                    CiudadId = 7,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 8,
                    ViajeId = 2,
                    CiudadId = 8,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 9,
                    ViajeId = 2,
                    CiudadId = 9,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 10,
                    ViajeId = 2,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 11,
                    ViajeId = 3,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 12,
                    ViajeId = 3,
                    CiudadId = 12,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 13,
                    ViajeId = 3,
                    CiudadId = 13,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 14,
                    ViajeId = 3,
                    CiudadId = 14,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 15,
                    ViajeId = 3,
                    CiudadId = 15,
                    Tipo = "Destino"
                }
            );
        }
    }
}
