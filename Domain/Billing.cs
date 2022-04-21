namespace DefaultNamespace;

public class Billing
{
    public Billing(int id, string dueDate, DateTime issuanceDate, double totalPrice, string paymentDate)
    {
        this.Id = id;
        this.DueDate = dueDate;
        this.issuanceDate = issuanceDate;
        this.TotalPrice = totalPrice;
        this.PaymentDate = paymentDate;
    }
    
    public int Id { get; set; }
    public string DueDate {get; set; }
    public DateTime issuanceDate { get; set; }
    public double TotalPrice { get; set; }
    public string PaymentDate { get; set; }
    
    public override string ToString()
    {
        return $"Id: {this.Id} Preço: {this.TotalPrice}";
    }
}