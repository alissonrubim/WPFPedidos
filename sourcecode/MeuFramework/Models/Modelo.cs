using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuFramework.Models
{
    public class Modelo
    {
        //public Guid Id { get; set; }

        public string Id { get => id;  set => id = (new Guid(value)).ToString(); }

        public static string NovoGuid() => Guid.NewGuid().ToString();

        private string id = NovoGuid();

        public object AssinaturaAlteracao { get; set; }
    }
}
