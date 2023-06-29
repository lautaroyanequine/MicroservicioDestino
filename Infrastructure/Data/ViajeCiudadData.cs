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
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 16,
                    ViajeId = 4,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 17,
                    ViajeId = 4,
                    CiudadId = 26,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 18,
                    ViajeId = 5,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 19,
                    ViajeId = 5,
                    CiudadId = 23,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 20,
                    ViajeId = 6,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 21,
                    ViajeId = 6,
                    CiudadId = 19,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 22,
                    ViajeId = 7,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 23,
                    ViajeId = 7,
                    CiudadId = 24,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 24,
                    ViajeId = 8,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 25,
                    ViajeId = 8,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 26,
                    ViajeId = 9,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 27,
                    ViajeId = 9,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 28,
                    ViajeId = 10,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 29,
                    ViajeId = 10,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 30,
                    ViajeId = 11,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 31,
                    ViajeId = 11,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 32,
                    ViajeId = 12,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 33,
                    ViajeId = 12,
                    CiudadId = 6,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 34,
                    ViajeId = 13,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 35,
                    ViajeId = 13,
                    CiudadId = 6,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 36,
                    ViajeId = 14,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 37,
                    ViajeId = 14,
                    CiudadId = 6,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 38,
                    ViajeId = 15,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 39,
                    ViajeId = 15,
                    CiudadId = 6,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 40,
                    ViajeId = 16,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 41,
                    ViajeId = 16,
                    CiudadId = 1,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 42,
                    ViajeId = 17,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 43,
                    ViajeId = 17,
                    CiudadId = 3,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 44,
                    ViajeId = 18,
                    CiudadId = 21,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 45,
                    ViajeId = 18,
                    CiudadId = 3,
                    Tipo = "Destino"
                }

            );
        }
    }
}
