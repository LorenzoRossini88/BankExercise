using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public class Cliente
    {
        public string Nome { get; }
        public DateTime DataNascita { get; }
        public string Banca { get; }

        public Cliente(string nome, DateTime dataNascita, string banca)
        {
            Nome = nome;
            DataNascita = dataNascita;
            Banca = banca;
        }
    }
}
