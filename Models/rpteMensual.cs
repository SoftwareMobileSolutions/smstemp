using System.Collections.Generic;
using System.Linq;

namespace smstemp.Models
{
    public class rpteMensual
    {
        public string subflota { get; set; }
        public string placa { get; set; }
        public string alias { get; set; }
        public string valorTemp { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }
        public string d4 { get; set; }
        public string d5 { get; set; }
        public string d6 { get; set; }
        public string d7 { get; set; }
        public string d8 { get; set; }
        public string d9 { get; set; }
        public string d10 { get; set; }
        public string d11 { get; set; }
        public string d12 { get; set; }
        public string d13 { get; set; }
        public string d14 { get; set; }
        public string d15 { get; set; }
        public string d16 { get; set; }
        public string d17 { get; set; }
        public string d18 { get; set; }
        public string d19 { get; set; }
        public string d20 { get; set; }
        public string d21 { get; set; }
        public string d22 { get; set; }
        public string d23 { get; set; }
        public string d24 { get; set; }
        public string d25 { get; set; }
        public string d26 { get; set; }
        public string d27 { get; set; }
        public string d28 { get; set; }
        public string d29 { get; set; }
        public string d30 { get; set; }
        public string d31 { get; set; }
        public string d32 { get; set; }
        public int cantidadSensorT { get; set; }
    }

    public class grafMensual
    {
        public int diabase { get; set; }
        public string placaGraf { get; set; }
        public string alias { get; set; }
        private string cadenaMinimosPlaca { get; set; }
        public int dia32 { get; set; }
        public object[] diasporplacas
        {
            get
            {
                string[] valores = this.cadenaMinimosPlaca.Split('&');
                List<string> list = new List<string>();
                for (int i = this.diabase, len = valores.Count() - this.dia32; i < len; i++)
                {
                    if (valores[i] == "")
                    {
                        valores[i] = null;
                    }
                    list.Add(valores[i]);

                }
                return list.ToArray();

                /*
                object[] values = this.cadenaMinimosPlaca.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                object[] values = this.cadenaMinimosPlaca.Split(new char[] { '&' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
                return values;*/
            }
        }
    }
    public class grafSeries
    {
        public string dia { get; set; }
    }
}
