namespace CRUD.WebApp.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public DateOnly Fechacontrato { get; set; }
        public bool Activo { get; set; }

    }
}
