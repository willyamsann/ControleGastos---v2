using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleGastos.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Observation { get; set; }
        public double Valor { get; set; }

        public int? CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

    }
}
