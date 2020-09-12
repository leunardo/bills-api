using System.Collections.Generic;
using System.Linq;
using application.domain.dtos;
using application.domain.models;
using application.interfaces;
using infrastructure.interfaces;
using infrastructure.records;

namespace application.services
{
    public class BillsService : IBillsService
    {
        private readonly IBillRepository _billRepository;
        private readonly IBusinessRuleRepository _businessRuleRepository;

        public BillsService(
            IBillRepository billRepository, 
            IBusinessRuleRepository businessRuleRepository
        )
        {
            _billRepository = billRepository;
            _businessRuleRepository = businessRuleRepository;
        }

        public bool CreateBill(BillDTO bill)
        {
            return _billRepository.CreateBill(new BillRecord
            {
                Amount = bill.OriginalAmount,
                DueDate = bill.DueDate,
                PaymentDate = bill.PaymentDate,
                Name = bill.Name
            });
        }

        public IEnumerable<Bill> GetAllBills()
        {
            var billRecords = _billRepository.GetAll();
            if (billRecords.Count() == 0)
            {
                _billRepository.Populate();
                billRecords = _billRepository.GetAll();
            }

            var bills = billRecords.Select(record => new Bill(record)).ToList();
            ApplyOverduePenalties(bills);

            return bills;
        }

        private void ApplyOverduePenalties(IEnumerable<Bill> bills)
        {
            var businessRules = _businessRuleRepository.GetAll();

            foreach(var bill in bills)
            {
                if (bill.OverdueDays > 0)
                {
                    var businessRule = businessRules.First(br => 
                        br.DelayedDaysStart < bill.OverdueDays &&
                        br.DelayedDaysEnd > bill.OverdueDays);

                    bill.AdjustedAmount = bill.OriginalAmount;
                    bill.AdjustedAmount += bill.AdjustedAmount * (decimal)businessRule.Penalty;
                    bill.AdjustedAmount += bill.OriginalAmount * (decimal)businessRule.InterestPerDay * bill.OverdueDays;
                }
                else
                {
                    bill.AdjustedAmount = bill.OriginalAmount;  
                }
            }
        }
    }
}