using MemeticosHorario.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo.IndividuoFactory
{
    public class IIndividuoFactory_Universidad : IIndividuoFactory
    {
        private List<Asignatura> _asignaturas;

        public IIndividuoFactory_Universidad()
        {
            _asignaturas = ModelLoader.Get_Asignaturas();
        }
        public Individuo Aleatoreo()
        {
            var genes = _asignaturas
                .Select(asg => {
                    var horario = HorarioHelper.HorarioAleatoreo();
                    return new Gen()
                    {
                        Asignatura = asg,
                        Coste = 0,
                        Horario = horario,
                        Aula = AulaHelper.Aleatorea(asg.TipoAula, horario)
                    };
                }).ToList();
            return new IndividuoUniversidad(genes);
        }
    }
}
