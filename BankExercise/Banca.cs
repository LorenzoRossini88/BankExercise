using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public abstract class Banca
    {
        public string Nome { get; }

        protected Banca(string nome)
        {
            Nome = nome;
        }

        public abstract void GestisciTransazione(ContoCorrente conto, double ammontare, string tipoOperazione);
    }
}
