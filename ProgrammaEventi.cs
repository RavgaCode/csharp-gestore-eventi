// See https://aka.ms/new-console-template for more information


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
}