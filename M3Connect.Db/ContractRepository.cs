using M3Connect.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace M3Connect.Db
{
    public class ContractRepository : IContractRepository
    {
        //private readonly List<Contract> _contracts = new List<Contract>();

        private readonly DatabaseContext _dbContext;

        public ContractRepository(DatabaseContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        public ContractRepository()
        {
            // Пример начальных данных
            /*_contracts.Add(new Contract
            {
                Id = 1,
                FullName = "Иванов Иван Иванович",
                IpAddress = "192.168.0.1",
                ServiceType = ServiceType.Internet,
                ContractDate = new System.DateTime(2024, 5, 30),
                IsActive = true
            });
            _contracts.Add(new Contract
            {
                Id = 2,
                FullName = "Петров Петр Петрович",
                IpAddress = "192.168.0.2",
                ServiceType = ServiceType.VideoSurveillance,
                ContractDate = new System.DateTime(2024, 5, 30),
                IsActive = false
            });*/

        }


        public List<Contract> GetAll()
        {
            return _dbContext.Contracts.ToList();
        }

        public Contract GetById(Guid id) => _dbContext.Contracts.FirstOrDefault(c => c.Id == id);

        public void Add(Contract contract)
        {
           
            _dbContext.Contracts.Add(contract);
            _dbContext.SaveChanges();
        }

        public void Update(Contract contract)
        {
            var index = _dbContext.Contracts.ToList().FindIndex(c => c.Id == contract.Id);
            if (index >= 0) _dbContext.Contracts.ToList()[index] = contract;
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbContext.Contracts.ToList().RemoveAll(c => c.Id == id);
            _dbContext.SaveChanges();
        }
    }
}
