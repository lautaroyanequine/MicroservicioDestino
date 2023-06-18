using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IInfoCiudad
{
    public interface IInfoCiudadCommand
    {
        InfoCiudad CreateInfoCiudad(InfoCiudad infoCiudad);

        InfoCiudad UpdateInfoCiudad(int infoCiudadId, InfoCiudad infoCiudad);

        InfoCiudad DeleteInfoCiudad(int infoCiudadId);
    }
}
