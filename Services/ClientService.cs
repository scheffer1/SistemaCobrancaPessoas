using DefaultNamespace;
using SistemaCobrancaPessoas.Data;

namespace SistemaCobrancaPessoas.Services;

public class ClientService
{
    private ClientRepository ClientRepository;

    public ClientService()
    {
        ClientRepository = new ClientRepository();
    }

    public Client GetById(int id)
    {
        return ClientRepository.GetById(id);
    }
    
    public List<Client> getAll()
    {
        return ClientRepository.getAll();
    }

    public bool Save(Client client)
    {
        return ClientRepository.Save(client);
    }

    public bool Update(int id, Client updatedClient)
    {
       return ClientRepository.Update(id, updatedClient);
    }

    public bool Remove(int id)
    {
        return ClientRepository.Remove(id);
    }

    public bool SaveBilling(int idCustomer, Billing billing)
    {
        return ClientRepository.SaveBilling(idCustomer, billing);
    }

    public bool RemoveBilling(int idCustomer, int idBilling)
    {
        return ClientRepository.RemoveBilling(idCustomer, idBilling);
    }

    public bool UpdateBilling(int idCustomer, Billing updatedBilling)
    {
        return ClientRepository.UpdateBilling(idCustomer, updatedBilling);
    }
}