using Project1.Models;

namespace Project1.BL
{
    public interface Interface
    {
        Task<List<Item>> GetAllInvoices();
    }
}
