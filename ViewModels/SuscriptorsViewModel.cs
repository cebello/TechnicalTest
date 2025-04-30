using System.Collections.Generic;
using TechnicalTest.Models;

namespace TechnicalTest.ViewModels
{
    public class SuscriptorsViewModel
    {
        public List<Suscriptor> Lista { get; set; } = new List<Suscriptor>();
        public Suscriptor Resultado { get; set; }
        public int? IdBuscado { get; set; }
        public string Error { get; set; }
    }
}
