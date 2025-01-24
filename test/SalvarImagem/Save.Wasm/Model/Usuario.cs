using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Save.Wasm.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public string Telefone { get; set; } = null!;
    }
}