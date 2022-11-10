// See https://aka.ms/new-console-template for more information


using System;

public class ProgrammaEventi
{
    private string _titolo;
    public string Titolo
    {
        get { return _titolo; }
        set
        {
            if (value == "" || value == null)
            {
                throw new Exception("Formato titolo non valido");
            }
            else
            {
                _titolo = value;    
            }
        }
    }
    public List<Evento> Eventi { get; set; }

    public ProgrammaEventi(string titolo)
    {
            this.Titolo = titolo;
            this.Eventi = new List<Evento>();
    }
    public void AggiungiNuovoEventoAlProgramma(Evento nuovoEvento)
    {
        this.Eventi.Add(nuovoEvento);
    }
    public List<Evento> FiltraEventiPerData(DateTime dataUtente)
    {
        var listaFiltrata = new List<Evento>(); 
        foreach(Evento evento in this.Eventi)
        {
            if(evento.Data.CompareTo(dataUtente) == 0)
            {
                listaFiltrata.Add(evento);  
            }
        }
        return listaFiltrata;
    }
    public int NumeroEventiInProgramma()
    {
        return this.Eventi.Count;
    }
    public void CancellaEventi()
    {
        this.Eventi.Clear();
    }
    public  string StampaListaEventi()
    {
        string lista = "";
        foreach (Evento evento in this.Eventi)
        {
            lista += evento.ToString() + "\n";
        }
        return lista;
    }
    public override string ToString()
    {
        string programma = Titolo;
        foreach (Evento evento in this.Eventi)
        {
            programma = programma + "\n" + evento.ToString() + "\n";
        }
        return programma;
    }
    public void ExportProgramma()
    {
        string path = "C:\\Users\\rober\\source\\repos\\csharp-gestore-eventi\\Programma.txt";
        
        StreamWriter file = File.CreateText(path);

        file.WriteLine("titolo,data,capienza massima,posti prenotati");
        foreach(Evento evento in this.Eventi)
        {
            file.WriteLine((evento.ToString()).Replace(" - ",","));
        }
        file.Close();
    }
    public void ImportProgramma()
    {
        var nuovaLista = new List<Evento>();

        string path = "C:\\Users\\rober\\source\\repos\\csharp-gestore-eventi\\Programma.txt";
        StreamReader fileProgramma = File.OpenText(path);

        fileProgramma.ReadLine();
        while (!fileProgramma.EndOfStream)
        {
            string line = fileProgramma.ReadLine();
            string[] oggettoEvento = line.Split(",");
            if(oggettoEvento.Length == 4)
            {
                string nuovoTitolo = "";
                if (oggettoEvento[0] != "" && oggettoEvento[0] != null)
                {
                    nuovoTitolo = oggettoEvento[0];
                }
                DateTime nuovaData = new DateTime();
                if (Convert.ToDateTime(oggettoEvento[1]) >= DateTime.Now)
                {
                    nuovaData = Convert.ToDateTime(oggettoEvento[1]);
                }
                int nuovaCapienzaMassima = 1;
                if (Int32.Parse(oggettoEvento[2]) > 0)
                {
                    nuovaCapienzaMassima = Convert.ToInt32(oggettoEvento[2]);
                }
                int nuoviPostiPrenotati = 0;
                nuoviPostiPrenotati = Convert.ToInt32(oggettoEvento[3]);
                
                Evento nuovoEvento = new Evento(nuovoTitolo, nuovaData, nuovaCapienzaMassima);
                nuovoEvento.PrenotaPosti(nuoviPostiPrenotati);
                nuovaLista.Add(nuovoEvento);
            }    

        }
        this.Eventi = nuovaLista;
        fileProgramma.Close();
    }
}