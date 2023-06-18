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
        InfoCiudad createInfoCiudad(InfoCiudad infoCiudad);

        InfoCiudad modifyInfoCiudad(int infoCiudadId, InfoCiudad infoCiudad);

        InfoCiudad deleteInfoCiudad(int infoCiudadId);
    }
}
