using M3Connect.Db.Models;
using System;
using System.Collections.Generic;

namespace M3Connect.Db
{
    public interface IContractRepository
    {
        List<Contract> GetAll();
        Contract GetById(Guid id);
        void Add(Contract contract);
        void Update(Contract contract);
        void Delete(Guid id);
    }
}
