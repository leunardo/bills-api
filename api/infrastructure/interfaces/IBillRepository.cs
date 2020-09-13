using System.Collections.Generic;
using infrastructure.records;

namespace infrastructure.interfaces
{
    public interface IBillRepository
    {
        void Populate();
        IEnumerable<BillRecord> GetAll();
        bool CreateBill(BillRecord bill);
    }
}