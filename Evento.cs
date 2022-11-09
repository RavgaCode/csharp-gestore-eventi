// See https://aka.ms/new-console-template for more information
public class Evento
{
    //Imposto le Properties
    private string _titolo;
    public string Titolo
    {
        get { return _titolo; }
        set {
            if (Titolo != "")
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
            if (Data >= DateTime.Now)
            {
                _data = value;
            }
        }
    }
    public int CapienzaMassima { get; private set; }
    public int PostiPrenotati { get; private set; }


    //Imposto il constructor con i vari controlli
    public  Evento (string titolo, DateTime data, int capienzaMassima)
        {
        this._titolo = titolo;
        this._data = data;
        if(capienzaMassima > 0)
            {
                this.CapienzaMassima = capienzaMassima;
            }
        this.PostiPrenotati = 0;
        }
    //METHODS
    public void PrenotaPosti(int postiDaPrenotare)
    {
        if(PostiPrenotati + postiDaPrenotare <= CapienzaMassima)
        {
            this.PostiPrenotati += postiDaPrenotare;
        }
    }
    public void DisdiciPosti(int postiDaCancellare)
    {
        if(PostiPrenotati - postiDaCancellare >= 0)
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