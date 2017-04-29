﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Individuo
    {
        public Individuo(List<Gen> genes)
        {
            this.genes = genes;
            this.fitness = 0;
        }
        public List<Gen> genes { get; set; }
        //public double adaptacion { get; set; }
        public double fitness { get; set; }


        public void Evaluar()
        {

        }

        public static Individuo aleatorio(List<Asignatura> asignaturas) {
            var genes = asignaturas
                .Select(asg => {
                    var horario = HorarioHelper.HorarioAleatoreo();
                    return new Gen()
                    {
                        codigo_Asig = asg,
                        coste = 0,
                        horario = horario,
                        Aula = AulaHelper.Aleatorea(asg.tipoAula, horario)
                    };
                }).ToList();
            return new Individuo(genes);

        }
    }

}
