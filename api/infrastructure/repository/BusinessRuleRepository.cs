using System.Collections.Generic;
using System.Linq;
using infrastructure.interfaces;
using infrastructure.records;

namespace infrastructure.repository
{
    public class BusinessRuleRepository : IBusinessRuleRepository
    {
        private readonly DbContext _db;
        public BusinessRuleRepository(DbContext db)
        {
            _db = db;
            if (_db.BusinessRules.Count() == 0)
            {
                this.Populate();
            }
        }

        public IEnumerable<BusinessRuleRecord> GetAll()
        {
            return _db.BusinessRules;
        }

        public void Populate()
        {
            _db.AddRange(new List<BusinessRuleRecord>
            {
                new BusinessRuleRecord
                {
                    DelayedDaysStart = 1,
                    DelayedDaysEnd = 3,
                    Penalty = 0.02,
                    InterestPerDay = 0.001,
                    Id = "BR-1"
                },
                new BusinessRuleRecord
                {
                    DelayedDaysStart = 3,
                    DelayedDaysEnd = 5,
                    Penalty = 0.03,
                    InterestPerDay = 0.002,
                    Id = "BR-2"
                },
                    new BusinessRuleRecord
                {
                    DelayedDaysStart = 5,
                    DelayedDaysEnd = int.MaxValue,
                    Penalty = 0.05,
                    InterestPerDay = 0.003,
                    Id = "BR-3"
                },
            });

            _db.SaveChanges();
    }
    }
}