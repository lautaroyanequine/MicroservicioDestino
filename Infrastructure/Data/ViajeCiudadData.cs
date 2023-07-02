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
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 3,
                    ViajeId = 2,
                    CiudadId = 19,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 4,
                    ViajeId = 2,
                    CiudadId = 2,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 5,
                    ViajeId = 3,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 6,
                    ViajeId = 3,
                    CiudadId = 118,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 7,
                    ViajeId = 3,
                    CiudadId = 144,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 8,
                    ViajeId = 3,
                    CiudadId = 120,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 9,
                    ViajeId = 4,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 10,
                    ViajeId = 4,
                    CiudadId = 120,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 11,
                    ViajeId = 4,
                    CiudadId = 132,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 12,
                    ViajeId = 4,
                    CiudadId = 129,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 13,
                    ViajeId = 5,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 14,
                    ViajeId = 5,
                    CiudadId = 84,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 15,
                    ViajeId = 6,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 16,
                    ViajeId = 6,
                    CiudadId = 35,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 17,
                    ViajeId = 7,
                    CiudadId = 11,
                    Tipo = "Origen"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 18,
                    ViajeId = 7,
                    CiudadId = 20,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 19,
                    ViajeId = 8,
                    CiudadId = 11,
                    Tipo = "Origen"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 20,
                    ViajeId = 8,
                    CiudadId = 30,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 21,
                    ViajeId = 9,
                    CiudadId = 11,
                    Tipo = "Origen"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 22,
                    ViajeId = 9,
                    CiudadId = 95,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 23,
                    ViajeId = 10,
                    CiudadId = 11,
                    Tipo = "Origen"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 24,
                    ViajeId = 10,
                    CiudadId = 96,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 25,
                    ViajeId = 11,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 26,
                    ViajeId = 11,
                    CiudadId = 92,
                    Tipo = "Destino"
                },
                //----------------------------------------------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 27,
                    ViajeId = 12,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 28,
                    ViajeId = 12,
                    CiudadId = 92,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 29,
                    ViajeId = 12,
                    CiudadId = 119,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 30,
                    ViajeId = 12,
                    CiudadId = 118,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 31,
                    ViajeId = 13,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 32,
                    ViajeId = 13,
                    CiudadId = 104,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 33,
                    ViajeId = 13,
                    CiudadId = 117,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 34,
                    ViajeId = 14,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 35,
                    ViajeId = 14,
                    CiudadId = 94,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 36,
                    ViajeId = 14,
                    CiudadId = 115,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 37,
                    ViajeId = 14,
                    CiudadId = 150,
                    Tipo = "Destino"
                },
                //----------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 38,
                    ViajeId = 15,
                    CiudadId = 94,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 39,
                    ViajeId = 15,
                    CiudadId = 11,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 40,
                    ViajeId = 16,
                    CiudadId = 104,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 41,
                    ViajeId = 16,
                    CiudadId = 11,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 42,
                    ViajeId = 17,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 43,
                    ViajeId = 17,
                    CiudadId = 42,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 44,
                    ViajeId = 18,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 45,
                    ViajeId = 18,
                    CiudadId = 85,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 46,
                    ViajeId = 19,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 47,
                    ViajeId = 19,
                    CiudadId = 92,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 48,
                    ViajeId = 19,
                    CiudadId = 123,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 49,
                    ViajeId = 20,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 50,
                    ViajeId = 20,
                    CiudadId = 112,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 51,
                    ViajeId = 20,
                    CiudadId = 109,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 52,
                    ViajeId = 21,
                    CiudadId = 113,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 53,
                    ViajeId = 21,
                    CiudadId = 11,
                    Tipo = "Destino"
                },


                new ViajeCiudad
                {
                    ViajeCiudadId = 54,
                    ViajeId = 23,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 55,
                    ViajeId = 23,
                    CiudadId = 106,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 56,
                    ViajeId = 23,
                    CiudadId = 120,
                    Tipo = "Escala"
                },
                //----------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 57,
                    ViajeId = 23,
                    CiudadId = 126,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 58,
                    ViajeId = 25,
                    CiudadId = 121,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 59,
                    ViajeId = 25,
                    CiudadId = 147,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 60,
                    ViajeId = 26,
                    CiudadId = 132,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 61,
                    ViajeId = 26,
                    CiudadId = 144,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 62,
                    ViajeId = 26,
                    CiudadId = 115,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 63,
                    ViajeId = 26,
                    CiudadId = 106,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 64,
                    ViajeId = 26,
                    CiudadId = 11,
                    Tipo = "Destino"
                },
                //---------------------------------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 65,
                    ViajeId = 27,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 66,
                    ViajeId = 27,
                    CiudadId = 92,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 67,
                    ViajeId = 27,
                    CiudadId = 150,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 68,
                    ViajeId = 27,
                    CiudadId = 144,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 69,
                    ViajeId = 28,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 70,
                    ViajeId = 28,
                    CiudadId = 94,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 71,
                    ViajeId = 28,
                    CiudadId = 151,
                    Tipo = "Escala"
                },
                //----------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 72,
                    ViajeId = 28,
                    CiudadId = 145,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 73,
                    ViajeId = 29,
                    CiudadId = 19,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 74,
                    ViajeId = 29,
                    CiudadId = 23,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 75,
                    ViajeId = 29,
                    CiudadId = 35,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 76,
                    ViajeId = 30,
                    CiudadId = 10,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 77,
                    ViajeId = 30,
                    CiudadId = 23,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 78,
                    ViajeId = 31,
                    CiudadId = 10,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 79,
                    ViajeId = 31,
                    CiudadId = 27,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 80,
                    ViajeId = 32,
                    CiudadId = 29,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 81,
                    ViajeId = 32,
                    CiudadId = 50,
                    Tipo = "Escala"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 82,
                    ViajeId = 32,
                    CiudadId = 10,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 83,
                    ViajeId = 33,
                    CiudadId = 54,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 84,
                    ViajeId = 33,
                    CiudadId = 19,
                    Tipo = "Destino"
                },
                //---------------------------------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 85,
                    ViajeId = 34,
                    CiudadId = 19,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 86,
                    ViajeId = 34,
                    CiudadId = 55,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 87,
                    ViajeId = 35,
                    CiudadId = 8,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 88,
                    ViajeId = 35,
                    CiudadId = 2,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 89,
                    ViajeId = 36,
                    CiudadId = 8,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 90,
                    ViajeId = 36,
                    CiudadId = 3,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 91,
                    ViajeId = 37,
                    CiudadId = 8,
                    Tipo = "Origen"
                },
                //----------------------------------------------
                new ViajeCiudad
                {
                    ViajeCiudadId = 92,
                    ViajeId = 37,
                    CiudadId = 4,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 93,
                    ViajeId = 38,
                    CiudadId = 8,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 94,
                    ViajeId = 38,
                    CiudadId = 5,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 95,
                    ViajeId = 39,
                    CiudadId = 27,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 96,
                    ViajeId = 39,
                    CiudadId = 8,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 97,
                    ViajeId = 40,
                    CiudadId = 18,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 98,
                    ViajeId = 40,
                    CiudadId = 6,
                    Tipo = "Destino"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 99,
                    ViajeId = 41,
                    CiudadId = 84,
                    Tipo = "Origen"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 100,
                    ViajeId = 41,
                    CiudadId = 8,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 101,
                    ViajeId = 22,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 102,
                    ViajeId = 22,
                    CiudadId = 84,
                    Tipo = "Destino"
                },
                new ViajeCiudad
                {
                    ViajeCiudadId = 103,
                    ViajeId = 24,
                    CiudadId = 11,
                    Tipo = "Origen"
                },

                new ViajeCiudad
                {
                    ViajeCiudadId = 104,
                    ViajeId = 24,
                    CiudadId = 106,
                    Tipo = "Destino"
                }
            );
        }
    }
}
