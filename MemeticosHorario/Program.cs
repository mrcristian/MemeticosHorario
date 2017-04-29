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
            cargarAulasDisponibles();
            cargarAsignaturas();
            cargarProfesores();

            AulaHelper.Inicializar(misAulas);
            var ind = Individuo.aleatorio(misAsignaturas);
        }
        public static void cargarAulasDisponibles()
        {
            misAulas = new List<Aula>();
            using (fm) {
                fm.OpenFile("Aulas.txt", false, false);
                while (fm.Readable)
                {
                    var datos = fm.ReadLine().Split(',');
                    misAulas.Add(new Aula(datos[0],
                        Convert.ToInt32(datos[1])));
                }
            }
        }
        public static void cargarAsignaturas() {
            misAsignaturas = new List<Asignatura>();
            using (fm)
            {
                fm.OpenFile("Asignaturas.txt", false, false);
                while (fm.Readable)
                {                    
                    string[] datos = fm.ReadLine().Split(',');
                    misAsignaturas.Add(
                        new Asignatura(datos[1],datos[0],
                        Convert.ToInt32(datos[2])));                    
                }
            }
        }
        public static void cargarProfesores() {
            misProfesores = new List<Profesor>();
            using (fm)
            {
                fm.OpenFile("Profesores.txt", false, false);
                while (fm.Readable)
                {
                    string[] datos = fm.ReadLine().Split(',');
                    var asignaturas = misAsignaturas
                        .Where(a => a.codigo_Profesor.Equals(datos[1]))
                        .ToList();
                    misProfesores.Add(new Profesor(datos[1], datos[0],
                        asignaturas));
                }
            }
        }
    }


}



//double evaluacion() {
//}
