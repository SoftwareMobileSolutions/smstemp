using System;

namespace smstemp.Models
{
    public class EstadoActual
    {
        public int mobileid { get; set; }
        public string mobile { get; set; }
        public string subfleet { get; set; }
        public string plate { get; set; }
        public string location { get; set; }
        public DateTime dategps { get; set; }
        public DateTime dateserver { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public float s1 { get; set; }
        public float s2 { get; set; }
        public float s3 { get; set; }
        public float s4 { get; set; }
        public float s5 { get; set; }
        public float s6 { get; set; }
        public int cantidadSensorT { get; set; }
    }
}
