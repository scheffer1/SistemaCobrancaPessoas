using DefaultNamespace;

namespace SistemaCobrancaPessoas.Data;

public class ClientRepository
{

    private List<Client> clients = new List<Client>();
    

    public List<Client> getAll()
    {
        return clients;
    }

    public Client GetById(int id)
    {
        return clients.Find(c => c.Id.Equals(id));
    }

    public bool Save(Client customer)
    {   
        int id = clients.Count;
        id++;
        customer.Id = id;
        clients.Add(customer);
        return true;
    }

    public bool Update(int id, Client updatedCustomer)
    {
        Client customer = GetById(id);
            if (customer == null)
            {
                return false;
            }
            customer.Phone = updatedCustomer.Phone;
            customer.Name = updatedCustomer.Name;
            customer.Billings = updatedCustomer.Billings;
            return true;
    }

    public bool Remove(int id)
    {
        
             Client customer = GetById(id);
            if (customer == null)
            {
                return false;
            }
            clients.Remove(customer);
            return true;
    }

    public bool SaveBilling(int idClient, Billing billing)
    {
            Client client = GetById(idClient);
            if (client == null)
            {
                return false;
            }
            client.Billings.Add(billing);
            return true;
    }

    public bool RemoveBilling(int idClient, int idBilling)
    {
            if (GetById(idClient) == null)
            {
                return false;
            }
            Client customer = GetById(idClient);
            Billing billing = getBillingById(customer, idBilling); 
            if (billing == null)
            {
                return false;
            }
            customer.Billings.Remove(billing);
            return true;
    }
    
    public bool UpdateBilling(int idCustomer, Billing updatedBilling)
    {
        
            if (GetById(idCustomer) == null)
            {
                return false;
            }
            Client customer = GetById(idCustomer);
            foreach (var billing in customer.Billings)
            {
                if (billing.Id.Equals(updatedBilling.Id))
                {
                    billing.issuanceDate = updatedBilling.issuanceDate;
                    billing.DueDate = updatedBilling.DueDate;
                    billing.PaymentDate = updatedBilling.PaymentDate;
                    billing.TotalPrice = updatedBilling.TotalPrice;
                }
            }
            return true;
    }
    

    public Billing getBillingById(Client customer, int idBilling)
    {
        return customer.Billings.Find(b => b.Id.Equals(idBilling));
    }
}