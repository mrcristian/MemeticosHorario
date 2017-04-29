using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Cost_Asig_Prof
    {
        int Codigo_Asignatura { get; set; }
        List<Costo_Hora_Prof> Horarios_Coste { get; set; }
    }
}
