
public class Conferenza : Evento
{
    public Conferenza(string titolo, DateTime data, int capienzaMassima, string relatore, double prezzo) : base(titolo, data, capienzaMassima)
    {
        this.Relatore = relatore;
        this.Prezzo = prezzo;
    }

    public string Relatore { get; set; }
    public double Prezzo { get; set; }

    public override string ToString()
    {
        return this.Data.ToString("dd/MM/yyyy") + " - " + this.Titolo + " - " + this.Relatore + " - " + this.Prezzo.ToString("0.00") + " euro";
    }
}