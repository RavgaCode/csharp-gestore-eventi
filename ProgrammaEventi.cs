// See https://aka.ms/new-console-template for more information


public class ProgrammaEventi
{
    public string Titolo { get; set; }
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
            if(evento.Data == dataUtente)
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
    public static string StampaListaEventi(List<Evento> eventi)
    {
        string lista = "";
        foreach (Evento evento in eventi)
        {
            if (lista == "")
                lista = evento.ToString() + "\n";
            lista = lista + evento.ToString() + "\n";
        }
        return lista;
    }
    public override string ToString()
    {
        string programma = Titolo;
        foreach (Evento evento in this.Eventi)
        {
            programma = programma + "\t" + evento.ToString() + "\n";
        }
        return programma;
    }
}