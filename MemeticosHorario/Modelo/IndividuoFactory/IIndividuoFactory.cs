using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo.IndividuoFactory
{
    public interface IIndividuoFactory
    {
        Individuo Aleatoreo();
        List<Individuo> Neighborhood(Individuo ind);
    }
}
