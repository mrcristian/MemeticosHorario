using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeticosHorario.Modelo
{
    class Cost_Asig_Prof
    {
        int codigo_Asig { get; set; }
        List<Costo_Hora_Prof> horarios_Coste { get; set; }
    }
}
