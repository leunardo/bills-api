using System;
using System.Collections.Generic;
using infrastructure.interfaces;
using infrastructure.records;

namespace infrastructure.repository
{
    public class BillRepository : IBillRepository
    {
        private readonly Random _rng = new Random(4);
        private readonly DbContext _db;

        public BillRepository(DbContext db)
        {
            _db = db;
        }

        public IEnumerable<BillRecord> GetAll()
        {
            return _db.Bills;
        }

        public void Populate()
        {
            for (int i = 0; i < 60; i++)
            {
                _db.Add(CreateBill());
            }

            _db.SaveChanges();
        }

        private BillRecord CreateBill()
        {
            return new BillRecord
            {
                Amount = (decimal)_rng.NextDouble() * 1000,
                DueDate = DateTime.Today.AddDays(_rng.Next(-365, 365)),
                PaymentDate = DateTime.Today.AddDays(_rng.Next(-365, 365)),
                Id = Guid.NewGuid().ToString(),
                Name = $"Payment of Goods"
            };
        }

        public bool CreateBill(BillRecord bill)
        {
            try
            {
                bill.Id = Guid.NewGuid().ToString();
                _db.Add(bill);
                _db.SaveChanges();

                return true;    
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        ~BillRepository()
        {
            _db.Dispose();
        }
    }
}