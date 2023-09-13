using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankExercise
{
    public class ContoCorrente
    {
        public int Id { get; }
        public Cliente Cliente { get; }
        public double Saldo { get; private set; }
        public Valuta Valuta { get; }
        public string IBAN { get; }

        public ContoCorrente(int id, Cliente cliente, Valuta valuta, string iban)
        {
            Id = id;
            Cliente = cliente;
            Saldo = 0;
            Valuta = valuta;
            IBAN = iban;
        }

        public void Versamento(double ammontare)
        {
            if (ammontare <= 0)
                throw new ArgumentException("L'ammontare del versamento deve essere maggiore di zero.");

            Saldo += ammontare;
            LogOperazione("+", ammontare);
        }

        public void Prelievo(double ammontare)
        {
            if (ammontare <= 0)
                throw new ArgumentException("L'ammontare del prelievo deve essere maggiore di zero.");

            if (ammontare > 10000)
                throw new InvalidOperationException("Hai superato il limite giornaliero di prelievo.");

            if (ammontare + CalcolaPrelieviMese() > 30000)
            {
                BloccaConto(3);
                throw new InvalidOperationException("Hai superato il limite mensile di prelievo.");
            }

            Saldo -= ammontare;
            LogOperazione("-", ammontare);
        }

        public void Trasferimento(ContoCorrente destinazione, double ammontare)
        {
            if (ammontare <= 0)
                throw new ArgumentException("L'ammontare del trasferimento deve essere maggiore di zero.");

            Prelievo(ammontare);
            destinazione.Versamento(ammontare);
        }

        private void BloccaConto(int giorni)
        {
            Console.WriteLine($"Il conto di {Cliente.Nome} è stato bloccato per {giorni} giorni.");
        }

        private double CalcolaPrelieviMese()
        {
            // Implementazione per calcolare il totale dei prelievi effettuati durante il mese.
            return 0; // Da implementare.
        }

        private void LogOperazione(string operazione, double ammontare)
        {
            string logLine = $"{DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.CurrentCulture)}, {Cliente.Banca}, {Cliente.Nome}, {Id}, {operazione}, {ammontare}";
            File.AppendAllText("log.txt", logLine + Environment.NewLine);
        }
    }
}
