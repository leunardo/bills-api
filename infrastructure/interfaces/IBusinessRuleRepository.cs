using System.Collections.Generic;
using infrastructure.records;

namespace infrastructure.interfaces
{
    public interface IBusinessRuleRepository
    {
        void Populate();
        IEnumerable<BusinessRuleRecord> GetAll();
    }
}