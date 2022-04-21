using System.ComponentModel.Design;
using System.Security.AccessControl;
using DefaultNamespace;
using Microsoft.VisualBasic;
using SistemaCobrancaPessoas.Services;

namespace SistemaCobrancaPessoas.Views;

public static class CustomerView
{
    public static Billing createCharge()
    {
        Console.Write("ID da transação: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Data: ");
        string dueDate = Console.ReadLine();
        
        DateTime issuanceDate = DateTime.Now;

        Console.Write("Preço: ");
        double totalPrice = double.Parse(Console.ReadLine());
        
        Console.Write("Data de pagamento: ");
        string paymentDate = Console.ReadLine();

        Billing billing = new Billing(id, dueDate, issuanceDate, totalPrice, paymentDate);
        return billing;
    }
    public static Client addClient()
    {
        Console.Write("Nome: ");
        string name = Console.ReadLine().Trim();
        Console.Write("Fone: ");
        string phone = Console.ReadLine().Trim();
        
        Client client = new Client(name, phone);
        return client;
    }
    
    
    public static void Menu(ClientService clientService)
    {
        
        string input = string.Empty;

        while (input != "0")
        {
            Console.WriteLine("\n\nSelecione a Ação");
            Console.WriteLine("1 - Cadastrar Cliente");                   
            Console.WriteLine("2 - Atualizar Cliente");
            Console.WriteLine("3 - Remover Cliente"); 
            Console.WriteLine("4 - Listar Cliente"); 
            Console.WriteLine("5 - Adicionar Cobrança"); 
            Console.WriteLine("6 - Atualizar Cobrança"); 
            Console.WriteLine("7 - Remover Cobrança"); 
            Console.WriteLine("0 - Sair"); 
            input = Console.ReadLine();

            int id;
            switch (input)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    Console.WriteLine("\n\nCadastro\n" +
                                      "-------------");
                    Client client = addClient();

                    clientService.Save(client);
                    
                    break;
                
                case "2":
                    Console.Write("ID do Cliente: ");
                    id = int.Parse(Console.ReadLine());
                    Client updatedCustomer = addClient();
                    clientService.Update(id, updatedCustomer);
                    break;
                
                case "3":
                    Console.Write("ID Do Cliente: ");
                    id = int.Parse(Console.ReadLine());
                    clientService.Remove(id);
                    break;
                
                case "4":
                    List<Client> clients = clientService.getAll();
                    clients.ForEach(c =>
                        Console.Write($"Id: {c.Id} \n Nome: {c.Name} \n " + $"Fone: {c.Phone} \n Cobranças [ " +
                                      $"{String.Join(", ", c.Billings)}" + " ]\n"));
                    break;
                    
                case "5":
                    Console.Write("ID do Cliente: ");
                    int customerId = int.Parse(Console.ReadLine());
                    
                    Billing charge = createCharge();
                    clientService.SaveBilling(customerId, charge);
                    break;
                
                case "6":
                    Console.Write("ID do cliente: ");
                    id = int.Parse(Console.ReadLine());
                    Billing updatedBilling = createCharge();
                    clientService.UpdateBilling(id, updatedBilling);
                    break;
                
                case "7":
                    Console.Write("ID do cliente: ");
                    id = int.Parse(Console.ReadLine());
                    Console.Write("ID da cobrança: ");
                    int idBilling = int.Parse(Console.ReadLine());
                    clientService.RemoveBilling(id, idBilling);

                    break;
                default:
                    Console.WriteLine("código inválido");
                    continue;
            }
        }
    }
}