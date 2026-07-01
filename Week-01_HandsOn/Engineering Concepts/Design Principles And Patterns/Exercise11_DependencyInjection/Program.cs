using System;

namespace DependencyInjectionExample
{
    interface CustomerRepository
    {
        string findCustomerById(string id);
    }

    class CustomerRepositoryImpl : CustomerRepository
    {
        public string findCustomerById(string id)
        {
            if (id == "101")
            {
                return "Krishna Mishra";
            }
            return "Customer Not Found";
        }
    }

    class CustomerService
    {
        private CustomerRepository repository;
        public CustomerService(CustomerRepository repository)
        {
            this.repository = repository;
        }

        public void showCustomer(string id)
        {
            string customerName = repository.findCustomerById(id);
            Console.WriteLine("Customer Details: " + customerName);
        }
    }

    public class Program
    {
        public static void Main()
        {
            CustomerRepository repo = new CustomerRepositoryImpl();
            CustomerService service = new CustomerService(repo);

            service.showCustomer("101");
        }
    }
}