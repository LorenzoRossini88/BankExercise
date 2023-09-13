using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankExercise
{
    public class BancaCommerciale : Banca
    {
        public List<ContoCorrente> ContiCorrenti { get; } = new List<ContoCorrente>();
        public List<Cliente> Clienti { get; } = new List<Cliente>();

        public BancaCommerciale(string nome) : base(nome)
        {
        }

        public override void GestisciTransazione(ContoCorrente conto, double ammontare, string tipoOperazione)
        {
            if (tipoOperazione == "+")
            {
                conto.Versamento(ammontare);
            }
            else if (tipoOperazione == "-")
            {
                conto.Prelievo(ammontare);
            }
            else
            {
                throw new InvalidOperationException("Tipo di operazione non valido.");
            }
        }

        public void AggiungiCliente(Cliente cliente)
        {
            Clienti.Add(cliente);
        }

        public void ApriConto(Cliente cliente, Valuta valuta)
        {
            if (cliente.DataNascita > DateTime.Now.AddYears(-18))
            {
                throw new InvalidOperationException("Devi avere almeno 18 anni per aprire un conto.");
            }

            Guid ibanGuid = Guid.NewGuid();
            string iban = ibanGuid.ToString("N").Substring(0, 22); // Esempio di generazione IBAN

            ContoCorrente nuovoConto = new ContoCorrente(ContiCorrenti.Count + 1, cliente, valuta, iban);
            ContiCorrenti.Add(nuovoConto);
        }
    }
}
