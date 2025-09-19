using Project1.Models;

namespace Project1.BL
{
    public class Service : Interface
    {
        private readonly DAL.Interface _interface;

        public Service(DAL.Interface _interface)
        {
            this._interface = _interface;
        }

        #region GetAllInvoices
        public async Task<List<Item>> GetAllInvoices()
        {
            return _interface.GetAllInvoices();
        }
        #endregion
    }
}
