using System;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Controllers
{
    public class BitacoraEvento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEvento { get; set; }
        public string Descripcion { get; set; }
    }
}