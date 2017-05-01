using MemeticosHorario.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo.IndividuoFactory
{
    public class IIndividuoFactory_Preescolar : IIndividuoFactory
    {
        private List<IndividuoPrescolar> _individuosBase;

        private List<Aula> _aulas;
        private List<Asignatura> _asignaturas;
        private Random r;


        public IIndividuoFactory_Preescolar()
        {
            r = new Random();
            _aulas = ModelLoader.Get_Aulas();
            _asignaturas = ModelLoader.Get_Asignaturas();
        }
        private void iniciarInidividuosBase()
        {
            _individuosBase = new List<IndividuoPrescolar>();
            for (int i = 0; i < 10; i++)
            {
                _individuosBase.Add(
                    (IndividuoPrescolar)Aleatoreo());
            }
        }

        public Individuo Aleatoreo()
        {            
            var genes = new List<Gen>();
            int horarios = HorarioHelper.NumHorarios();
            foreach (var item in _aulas)
            {
                for (int i = 0; i < horarios; i++)
                {
                    genes.Add(new Gen()
                    {
                        Aula = item,
                        Horario = (Horario)i,
                        Asignatura = _asignaturas[r.Next(_asignaturas.Count)],
                        Coste = 0
                    });
                }
            }
            return new IndividuoPrescolar(genes);
        }

        public List<Individuo> Neighborhood(Individuo ind)
        {
            for (int i = 0; i < _individuosBase.Count; i++)
            {
                //_individuosBase[i] = new IndividuoPrescolar()
                //{

                //}
            }
            throw new NotImplementedException();
        }
    }
}
