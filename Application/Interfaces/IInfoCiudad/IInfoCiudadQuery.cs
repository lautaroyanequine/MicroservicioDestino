using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IInfoCiudad
{
    public interface IInfoCiudadQuery
    {
        InfoCiudad getById(int InfoCiudadId);

        InfoCiudad getByCiudad(int CiudadId);
    }
}
