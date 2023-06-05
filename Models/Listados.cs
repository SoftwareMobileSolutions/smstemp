namespace smstemp.Models
{
    public class Listados
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public int CantidadSensorT { get; set; }
    }
    public class Arbol
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public bool HasChildren { get; set; }
        public string Icon { get; set; }
        public bool Expanded { get; set; }
    }
}
