// See https://aka.ms/new-console-template for more information
public class Evento
{
    //Imposto il constructor con i vari controlli
    public Evento(string titolo, DateTime data, int capienzaMassima)
    {
        this._titolo = titolo;
        this._data = data;
        if (capienzaMassima > 0)
        {
            this.CapienzaMassima = capienzaMassima;
        }
        this.PostiPrenotati = 0;
    }
    //Imposto le Properties
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
    private DateTime _data;
    public DateTime Data
    {
        get { return _data; }
        set {
            if (Data < DateTime.Now)
            {
                throw new Exception("Data non corretta. Inserire una data nel formato corretta e non precedente alla data corrente");
            }
            else
            {
                _data = value;
            }
        }
    }
    private int _capienzaMassima;
    public int CapienzaMassima
    {
        get
        {
            return _capienzaMassima;
        }
        private set
        {
            if(value <= 0)
            {
                throw new Exception("Capienza massima insufficiente");
            }
            else
            {
                _capienzaMassima = value;
            }
        }
    }
    public int PostiPrenotati { get; private set; }


    
    //METHODS
    public void PrenotaPosti(int postiDaPrenotare)
    {
        if(PostiPrenotati + postiDaPrenotare > CapienzaMassima)
        {
            throw new Exception("Il numero di posti che si vogliono prenotare è superiore a quelli disponibili");
        }
        else
        {
            this.PostiPrenotati += postiDaPrenotare;
        }
    }
    public void DisdiciPosti(int postiDaCancellare)
    {
        if(PostiPrenotati - postiDaCancellare < 0)
        {
            throw new Exception("Il numero di posti che si vogliono disdire è superiore a quello dei posti prenotati");
        }
        else
        {
            this.PostiPrenotati -= postiDaCancellare;
        }
    }
    public string MostraDataEvento()
    {
        return this.Titolo + " - " + this.Data.ToString("dd/MM/yyyy");
    }
    public int PostiDisponibili()
    {
        return this.CapienzaMassima - this.PostiPrenotati;
    }
}