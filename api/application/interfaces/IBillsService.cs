using System.Collections;
using System.Collections.Generic;
using application.domain.dtos;
using application.domain.models;

namespace application.interfaces 
{
    public interface IBillsService
    {
        IEnumerable<Bill> GetAllBills();
        bool CreateBill(BillDTO bill);
    }
}