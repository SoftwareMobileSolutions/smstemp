using System;

namespace smstemp.Models
{
    public class rpteAlertasDiarias
    {
        public int mobileid { get; set; }
        public string plate { get; set; }
        public string alias { get; set; }
        public string subflota { get; set; }
        public DateTime dategps { get; set; }
        public float s1 { get; set; }
        public float s2 { get; set; }
        public float s3 { get; set; }
        public float s4 { get; set; }
        public float s5 { get; set; }
        public float s6 { get; set; }
        public string localizacion { get; set; }
        public double longitud { get; set; }
        public double latitud { get; set; }

        public double lon
        {
            get
            {
                longitud = Math.Round(longitud, 6);
                return longitud;
            }
            set { longitud = value; }
        }

        public double lat
        {
            get
            {
                latitud = Math.Round(latitud, 6);
                return latitud;
            }
            set { latitud = value; }
        }

        public int encendido { get; set; }

        public string thermoking
        {
            get
            {

                return encendido == 0 ? "No" : "Sí";
            }
        }

        public int cantidadSensorT { get; set; }
        public float promedio { get; set; }

        public int statusid { get; set; }
        public int speed { get; set; }
        public int heading { get; set; }
    }
}
