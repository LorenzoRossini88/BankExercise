using BankExercise;
using System;
using System.Globalization;

namespace BankExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BancaCommerciale bancaCommerciale = new BancaCommerciale("Banca Commerciale");
            //string passwordBancaCommerciale = "1234"; // Password di accesso alla banca commerciale
            

            bool rimaniNelMenuPrincipale = true;

            try
            {
                while (rimaniNelMenuPrincipale)
                {
                    Console.WriteLine("Benvenuto a Simple Bank!");
                    Console.WriteLine("Scegli un'opzione:");
                    Console.WriteLine("B. Accedi alla Banca Commerciale");
                    Console.WriteLine("C. Accedi come Cliente");
                    Console.WriteLine("X. Esci");

                    string scelta = Console.ReadLine();

                    switch (scelta.ToUpper())
                    {
                        case "B":
                            Console.Write("Inserisci la password per la Banca Commerciale: ");
                            MenuBancaCommerciale(bancaCommerciale);

                            break;

                        case "C":
                            Console.WriteLine("Accesso come Cliente.");
                            MenuCliente(bancaCommerciale);
                            break;
                            
                            

                        case "X":
                            Environment.Exit(0);
                            break;

                        case "Y":
                            Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                            Console.ReadLine(); // Torna al menu principale
                            break;

                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }




        }

        private static void MenuBancaCommerciale(BancaCommerciale bancaCommerciale)
        {
            
            string inputPassword = Console.ReadLine();
            string passwordBancaCommerciale = "1234"; // Password di accesso alla banca commerciale

            if (inputPassword != passwordBancaCommerciale)
            {
                Console.WriteLine("Password errata!");
                Environment.Exit(0);


            }

            Console.WriteLine("Accesso alla Banca Commerciale riuscito.");
            try
            {
                Console.WriteLine("Benvenuto nella Banca Commerciale.");
                //Console.Write("Inserisci la password: ");
                //string inputPassword = Console.ReadLine();

                //if (inputPassword != password)
                //{
                //    Console.WriteLine("Password errata. Uscita.");
                //    Environment.Exit(1);
                //}

                while (true)
                {
                    Console.WriteLine("\nMenu Banca Commerciale:");
                    Console.WriteLine("1. Creare un conto corrente");
                    Console.WriteLine("2. Visualizzare tutti i conti correnti");
                    Console.WriteLine("3. Esci");
                    Console.WriteLine("4. Torna Indietro");


                    string sceltaBancaCommerciale = Console.ReadLine();

                    switch (sceltaBancaCommerciale)
                    {
                        case "1":
                            Console.WriteLine("Inserisci il nome del cliente:");
                            string nomeCliente = Console.ReadLine();
                            Console.WriteLine("Inserisci la data di nascita del cliente (yyyy-MM-dd):");
                            DateTime dataNascitaCliente = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                            Console.WriteLine("Seleziona la valuta del conto:");
                            Console.WriteLine("0. Euro");
                            Console.WriteLine("1. Dollaro");
                            Console.WriteLine("2. Yen");
                            Console.WriteLine("3. Rublo");
                            
                            Valuta valuta = (Valuta)Enum.Parse(typeof(Valuta), Console.ReadLine());

                            Cliente nuovoCliente = new Cliente(nomeCliente, dataNascitaCliente, "Banca Commerciale");
                            bancaCommerciale.AggiungiCliente(nuovoCliente);
                            bancaCommerciale.ApriConto(nuovoCliente, valuta);
                            Console.WriteLine("Conto corrente creato con successo.");
                            break;

                        case "2":
                            Console.WriteLine("\nElenco dei conti correnti:");
                            foreach (ContoCorrente conto in bancaCommerciale.ContiCorrenti)
                            {
                                Console.WriteLine($"ID: {conto.Id}, Cliente: {conto.Cliente.Nome}, Saldo: {conto.Saldo} {conto.Valuta}, IBAN: {conto.IBAN}");
                            }
                            break;

                        case "3":
                            Environment.Exit(0);
                            break;
                        case "4":
                            return;

                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }

                    Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                    Console.ReadLine(); // Torna al menu principale
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
        }



        private static void MenuCliente(BancaCommerciale bancaCommerciale)
        {

            try
            {



                while (true)
                {
                    Console.WriteLine("Seleziona un'operazione:");
                    Console.WriteLine("1. Versamento");
                    Console.WriteLine("2. Prelievo");
                    Console.WriteLine("3. Visualizza Saldo");
                    Console.WriteLine("4. Esci");
                    Console.WriteLine("5. Torna Indietro");

                    string scelta2 = Console.ReadLine();

                    switch (scelta2)
                    {
                        case "1":
                            Console.WriteLine("Inserisci l'IBAN del conto:");
                            string ibanVersamento = Console.ReadLine();
                            ContoCorrente contoVersamento = bancaCommerciale.ContiCorrenti.Find(c => c.IBAN == ibanVersamento);

                            if (contoVersamento == null)
                            {
                                Console.WriteLine("Conto corrente non trovato.");
                            }
                            else
                            {
                                Console.WriteLine($"Saldo attuale: {contoVersamento.Saldo} {contoVersamento.Valuta}");
                                Console.WriteLine("Inserisci l'importo da versare:");
                                double importoVersamento = Convert.ToDouble(Console.ReadLine());

                                if (importoVersamento <= 0)
                                {
                                    Console.WriteLine("L'importo deve essere maggiore di zero.");
                                }
                                else
                                {
                                    bancaCommerciale.GestisciTransazione(contoVersamento, importoVersamento, "+");
                                    Console.WriteLine("Versamento effettuato con successo.");
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine("Inserisci l'IBAN del conto:");
                            string ibanPrelievo = Console.ReadLine();
                            ContoCorrente contoPrelievo = bancaCommerciale.ContiCorrenti.Find(c => c.IBAN == ibanPrelievo);

                            if (contoPrelievo == null)
                            {
                                Console.WriteLine("Conto corrente non trovato.");
                            }
                            else
                            {
                                Console.WriteLine($"Saldo attuale: {contoPrelievo.Saldo} {contoPrelievo.Valuta}");
                                Console.WriteLine("Inserisci l'importo da prelevare:");
                                double importoPrelievo = Convert.ToDouble(Console.ReadLine());

                                if (importoPrelievo <= 0)
                                {
                                    Console.WriteLine("L'importo deve essere maggiore di zero.");
                                }
                                else if (importoPrelievo > contoPrelievo.Saldo)
                                {
                                    Console.WriteLine("Saldo insufficiente per il prelievo.");
                                }
                                else
                                {
                                    bancaCommerciale.GestisciTransazione(contoPrelievo, importoPrelievo, "-");
                                    Console.WriteLine("Prelievo effettuato con successo.");
                                }
                            }
                            break;

                        case "3":
                            Console.WriteLine("Inserisci l'IBAN del conto:");
                            string ibanSaldo = Console.ReadLine();
                            ContoCorrente contoSaldo = bancaCommerciale.ContiCorrenti.Find(c => c.IBAN == ibanSaldo);

                            if (contoSaldo == null)
                            {
                                Console.WriteLine("Conto corrente non trovato.");
                            }
                            else
                            {
                                Console.WriteLine($"Saldo: {contoSaldo.Saldo} {contoSaldo.Valuta}");
                            }
                            break;

                        case "4":
                            Environment.Exit(0);
                            break;
                        case "5":
                            return;


                        default:
                            Console.WriteLine("Scelta non valida. Riprova.");
                            break;
                    }

                    Console.WriteLine("\nPremi Invio per tornare al menu principale.");
                    Console.ReadLine(); // Torna al menu principale


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }

          

        }

    }
}



