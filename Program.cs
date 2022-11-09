// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

bool programma = true;

while (programma)
{
    //Chiedo i dati per il costruttore Evento
    Console.Write("Inserisci il nome dell'evento: ");
    string utenteTitolo = Console.ReadLine();
    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
    DateTime utenteData = DateTime.Parse(Console.ReadLine());
    Console.Write("Inserisci il numero di posti totali: ");
    int utenteCapacitàMassima = Int32.Parse(Console.ReadLine());

    //Creo il nuovo Evento
    Evento nuovoEvento = new Evento(utenteTitolo, utenteData, utenteCapacitàMassima);

    //Chiedo quanti posti l'utente vuole prenotare
    Console.Write("Quanti posti desideri prenotare: ");
    int postiDaPrenotare = Int32.Parse(Console.ReadLine());
    nuovoEvento.PrenotaPosti(postiDaPrenotare);
    Console.WriteLine();

    //Stampo il numero di posti
    Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
    Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
    Console.WriteLine();

    //Chiedo all'utente se vuole disdire dei posti
    Console.Write("Vuoi disdire dei posti (sì/no)? ");
    string rispostaUtenteDisdetta = Console.ReadLine();
    Console.WriteLine();

    bool richiestaDisdetta = true;
    while (richiestaDisdetta)
    {
        if (rispostaUtenteDisdetta == "sì")
        {
            Console.Write("Indica il numero di posti da disdire: ");
            int postiDaCancellare = Int32.Parse(Console.ReadLine());
            nuovoEvento.DisdiciPosti(postiDaCancellare);
            Console.WriteLine();
            //Stampo il numero di posti
            Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
            Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
            Console.WriteLine();


            //Chiedo NUOVAMENTE all'utente se vuole disdire dei posti
            Console.Write("Vuoi disdire dei posti (sì/no)? ");
            string nuovaRispostaUtenteDisdetta = Console.ReadLine();
            if(nuovaRispostaUtenteDisdetta == "no")
            {
                Console.WriteLine("Ok, va bene!");
                Console.WriteLine();
                //Stampo il numero di posti
                Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
                Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
                Console.WriteLine();
                richiestaDisdetta =false;
            }

        }
        else if(rispostaUtenteDisdetta == "no")
        {
            Console.WriteLine("Ok, va bene!");
            Console.WriteLine();
            //Stampo il numero di posti
            Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
            Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
            Console.WriteLine();
            richiestaDisdetta = false; 
        }
    }
    
}