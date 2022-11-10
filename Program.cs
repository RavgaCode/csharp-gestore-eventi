// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//******************* MILESTONE 2 ***********************************

//bool programma = true;

//while (programma)
//{
//    //Chiedo i dati per il costruttore Evento
//    Console.Write("Inserisci il nome dell'evento: ");
//    string utenteTitolo = Console.ReadLine();
//    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
//    DateTime utenteData = DateTime.Parse(Console.ReadLine());
//    Console.Write("Inserisci il numero di posti totali: ");
//    int utenteCapacitàMassima = Int32.Parse(Console.ReadLine());

//    //Creo il nuovo Evento
//    Evento nuovoEvento = new Evento(utenteTitolo, utenteData, utenteCapacitàMassima);

//    //Chiedo quanti posti l'utente vuole prenotare
//    Console.Write("Quanti posti desideri prenotare: ");
//    int postiDaPrenotare = Int32.Parse(Console.ReadLine());
//    nuovoEvento.PrenotaPosti(postiDaPrenotare);
//    Console.WriteLine();

//    //Stampo il numero di posti
//    Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
//    Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
//    Console.WriteLine();

//    //Chiedo all'utente se vuole disdire dei posti
//    Console.Write("Vuoi disdire dei posti (sì/no)? ");
//    string rispostaUtenteDisdetta = Console.ReadLine();
//    Console.WriteLine();

//    bool richiestaDisdetta = true;
//    while (richiestaDisdetta)
//    {
//        if (rispostaUtenteDisdetta == "sì")
//        {
//            Console.Write("Indica il numero di posti da disdire: ");
//            int postiDaCancellare = Int32.Parse(Console.ReadLine());
//            nuovoEvento.DisdiciPosti(postiDaCancellare);
//            Console.WriteLine();
//            //Stampo il numero di posti
//            Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
//            Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
//            Console.WriteLine();


//            //Chiedo NUOVAMENTE all'utente se vuole disdire dei posti
//            Console.Write("Vuoi disdire dei posti (sì/no)? ");
//            string nuovaRispostaUtenteDisdetta = Console.ReadLine();
//            if(nuovaRispostaUtenteDisdetta == "no")
//            {
//                Console.WriteLine("Ok, va bene!");
//                Console.WriteLine();
//                //Stampo il numero di posti
//                Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
//                Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
//                Console.WriteLine();
//                richiestaDisdetta =false;
//            }

//        }
//        else if(rispostaUtenteDisdetta == "no")
//        {
//            Console.WriteLine("Ok, va bene!");
//            Console.WriteLine();
//            //Stampo il numero di posti
//            Console.WriteLine("Numero di posti prenotati: " + nuovoEvento.PostiPrenotati);
//            Console.WriteLine("Numero di posti disponibili: " + nuovoEvento.PostiDisponibili());
//            Console.WriteLine();
//            richiestaDisdetta = false; 
//        }
//    }

//}



//******************* MILESTONE 4 ***********************************

bool programma = true;

while (programma)
{
    try
    {
        //Chiedo all'utente titolo del programma e numero di eventi
        Console.Write("Inserisci il nome del tuo programma Eventi: ");
        string utenteTitoloProgramma = Console.ReadLine();
        Console.Write("Indica il numero di eventi da inserire: ");
        int utenteNumeroEventi = Int32.Parse(Console.ReadLine());
        Console.WriteLine();

        //Creo il nuovo Programma Eventi
        ProgrammaEventi nuovoProgramma = new ProgrammaEventi(utenteTitoloProgramma);

        //Chiedo i dati per la creazione degli Eventi un numero di volte pari a quello precedentemente indicato

        for (int i = 0; i < utenteNumeroEventi; i++)
        {
            bool programmaFor = true;
            while (programmaFor)
            {
                try
                {
                    //Chiedo i dati per il costruttore Evento
                    Console.Write($"Inserisci il nome del {i + 1}° evento: ");
                    string utenteTitolo = Console.ReadLine();
                    Console.Write($"Inserisci la data delL'evento (gg/mm/yyyy): ");
                    DateTime utenteDataScelta = DateTime.Parse(Console.ReadLine());
                    Console.Write("Inserisci il numero di posti totali: ");
                    int utenteCapacitàMassima = Int32.Parse(Console.ReadLine());

                    //    //Creo il nuovo Evento
                    Evento nuovoEvento = new Evento(utenteTitolo, utenteDataScelta, utenteCapacitàMassima);

                    //Inserisco il nuovo evento alla lista del Programma
                    nuovoProgramma.AggiungiNuovoEventoAlProgramma(nuovoEvento);

                    Console.WriteLine();
                    programmaFor = false;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                } 
            }
            
        }

        //Stampo il numero di eventi nel programma
        Console.WriteLine("Il numero di eventi nel programma è: ", nuovoProgramma.NumeroEventiInProgramma());
        //Stampo l'intero programma con tutti gli eventi previsti
        Console.WriteLine("Ecco il tuo programma eventi: ");
        Console.WriteLine(nuovoProgramma.ToString());
        Console.WriteLine();

        //Chiedo una data da usare come filtro
        Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
        DateTime utenteData = DateTime.Parse(Console.ReadLine());

        //Stampo la lista degli eventi filtrata
        var eventiInGiornata = nuovoProgramma.FiltraEventiPerData(utenteData);
        nuovoProgramma.CancellaEventi();
        nuovoProgramma.Eventi = eventiInGiornata;
        Console.WriteLine(nuovoProgramma.StampaListaEventi());
        programma = false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}