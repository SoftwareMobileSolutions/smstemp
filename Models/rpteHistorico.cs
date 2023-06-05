using System;

namespace smstemp.Models
{
    public class rpteHistorico
    {
        //public int mobileid { get; set; }
        //public string vehiculo { get; set; }
        //public string alias { get; set; }
        //public DateTime dategps2 { get; set; }
        //public float s1 { get; set; }
        //public float s2 { get; set; }
        //public float s3 { get; set; }
        //public float s4 { get; set; }
        //public float s5 { get; set; }
        //public float s6 { get; set; }
        //public float promedio { get; set; }

        public string subflota { get; set; }
        public int mobileid { get; set; }
        public string vehiculo { get; set; }
        public string alias { get; set; }
        public DateTime dategps2 { get; set; }
        public float s1Min { get; set; }
        public float s2Min { get; set; }
        public float s3Min { get; set; }
        public float s4Min { get; set; }
        public float s5Min { get; set; }
        public float s6Min { get; set; }
        public float promedioMin { get; set; }
        public float s1Max { get; set; }
        public float s2Max { get; set; }
        public float s3Max { get; set; }
        public float s4Max { get; set; }
        public float s5Max { get; set; }
        public float s6Max { get; set; }
        public float promedioMax { get; set; }
        public int cantidadSensorT { get; set; }


    }
}
