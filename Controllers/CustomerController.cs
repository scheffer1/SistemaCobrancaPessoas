using SistemaCobrancaPessoas.Services;
using SistemaCobrancaPessoas.Views;

namespace SistemaCobrancaPessoas.Controllers;

public class CustomerController
{
    public void openView()
    {
        CustomerView.Menu(new ClientService());
    }
    
}