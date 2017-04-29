using MemeticosHorario.Modelo;
using MemeticosHorario.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario
{
    class Program
    {
        static File_Manager fm = new File_Manager();
        static List<Aula> misAulas;
        static List<Asignatura> misAsignaturas;
        static List<Profesor> misProfesores;
        static void Main(string[] args)
        {
            
            cargarAsignaturas();
            cargarProfesores();

            AulaHelper.Inicializar(misAulas);
            var ind = Individuo.aleatorio(misAsignaturas);
        }
        
        
    }


}



//double evaluacion() {
//}
