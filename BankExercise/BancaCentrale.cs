using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public class BancaCentrale : Banca
    {
        public BancaCentrale(string nome) : base(nome)
        {
        }

        public void EmettiMoneta(double ammontare)
        {
            // Implementa la stampa di denaro della banca centrale
            Console.WriteLine($"La Banca Centrale '{Nome}' ha stampato {ammontare} euro.");
        }

        public void ErogaPrestito(ContoCorrente conto, double ammontare)
        {
            // Implementa la concessione di un prestito da parte della banca centrale
            conto.Versamento(ammontare);
            Console.WriteLine($"La Banca Centrale '{Nome}' ha erogato un prestito di {ammontare} euro al conto {conto.Id}.");
        }

        public override void GestisciTransazione(ContoCorrente conto, double ammontare, string tipoOperazione)
        {
            throw new InvalidOperationException("La Banca Centrale non gestisce le transazioni dirette.");
        }
    }
}
