namespace DefaultNamespace;

public class Client
{
    public Client(String Name, String Phone)
    {
        this.Name = Name;
        this.Phone = Phone;
        Billings = new List<Billing>();
    }
    
    public int Id { get; set; }
    public String Name { get; set; }
    public String Phone { get; set; }
    public List<Billing> Billings { get; set; }
}