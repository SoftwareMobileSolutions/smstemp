using System;

namespace smstemp.Models
{
    public class AdminAlarmas_Obtener
    {
        /* ----------------- COLUMNAS DEL SP       
        AlarmaTempid mobileid    name s1Min   s1Max s2Min   s2Max s3Min   s3Max s4Min   s4Max s5Min   
            s5Max s6Min   s6Max HoraInicio  HoraFinal alarma  lun mar mie jue vie sab dom dias    tiempoAlarma
        */
        public int AlarmaTempid { get; set; }
        public int mobileid { get; set; }
        public string placa { get; set; }
        public string alias { get; set; }
        public string subflota { get; set; }
        public float s1Min { get; set; }
        public float s1Max { get; set; }
        public float s2Min { get; set; }
        public float s2Max { get; set; }
        public float s3Min { get; set; }
        public float s3Max { get; set; }
        public float s4Min { get; set; }
        public float s4Max { get; set; }
        public float s5Min { get; set; }
        public float s5Max { get; set; }
        public float s6Min { get; set; }
        public float s6Max { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public string alarma { get; set; }
        public int lun { get; set; }
        public int alarmaEstado { get; set; }
        public int mar { get; set; }
        public int mie { get; set; }
        public int jue { get; set; }
        public int vie { get; set; }
        public int sab { get; set; }
        public int dom { get; set; }
        public string dias { get; set; }

        public int tiempoAlarma { get; set; }
        public int cantSensores { get; set; }

        public int resultado { get; set; }

    }
}
