using MemeticosHorario.Modelo;
using MemeticosHorario.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.DAL
{
    public static class ModelLoader
    {
        private static File_Manager _fileManager;

        public static List<Aula> Get_Aulas()
        {
            var aulas = new List<Aula>();
            using (_fileManager)
            {
                _fileManager.OpenFile("Aulas.txt", false, false);
                while (_fileManager.Readable)
                {
                    var datos = _fileManager.ReadLine().Split(',');
                    aulas.Add(new Aula(datos[0],
                        Convert.ToInt32(datos[1])));
                }
            }
            return aulas;
        }

        public static List<Asignatura> Get_Asignaturas()
        {
            var asignaturas = new List<Asignatura>();
            using (_fileManager)
            {
                _fileManager.OpenFile("Asignaturas.txt", false, false);
                while (_fileManager.Readable)
                {
                    string[] datos = _fileManager.ReadLine().Split(',');
                    asignaturas.Add(
                        new Asignatura(datos[1], datos[0],
                        Convert.ToInt32(datos[2])));
                }
            }
            return asignaturas;
        }

        public static List<Profesor> Get_Profesores()
        {
            var profesores = new List<Profesor>();
            using (_fileManager)
            {
                _fileManager.OpenFile("Profesores.txt", false, false);
                while (_fileManager.Readable)
                {
                    string[] datos = _fileManager.ReadLine().Split(',');
                    var asignaturas = Get_Asignaturas()
                        .Where(a => a.Codigo_Profesor.Equals(datos[1]))
                        .ToList();
                    profesores.Add(new Profesor(datos[1], datos[0],
                        asignaturas));
                }
            }
            return profesores;
        }
    }
}
