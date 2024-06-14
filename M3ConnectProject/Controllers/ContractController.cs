using Microsoft.AspNetCore.Mvc;
using M3ConnectProject.Models;
using System.Linq;
using M3Connect.Db;
using System;
using M3Connect.Db.Models;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace M3ConnectProject.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractRepository _repository;

        public ContractController(IContractRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var contracts = _repository.GetAll();
            var Contracts = new List<ContractViewModel>();
            foreach (var contract in contracts)
            {
                Contracts.Add(new ContractViewModel()
                {
                    ContractDate = DateTime.Now,
                    Id = contract.Id,
                    FullName = contract.FullName,
                    IpAddress = contract.IpAddress,
                    IsActive = contract.IsActive,
                    ServiceType = (Models.ServiceType)contract.ServiceType
                });
            }
            return View(Contracts.OrderBy(x => x.IsActive).Reverse().ToList());
        }

        public IActionResult SuccessList()
        {
            var contracts = _repository.GetAll();
            var Contracts = new List<ContractViewModel>();
            foreach (var contract in contracts)
            {
                Contracts.Add(new ContractViewModel()
                {
                    ContractDate = DateTime.Now,
                    Id = contract.Id,
                    FullName = contract.FullName,
                    IpAddress = contract.IpAddress,
                    IsActive = contract.IsActive,
                    ServiceType = (Models.ServiceType)contract.ServiceType
                });
            }
            return View(Contracts.Where(x => x.IsActive).ToList());
        }

        public IActionResult CancelList()
        {
            var contracts = _repository.GetAll();
            var Contracts = new List<ContractViewModel>();
            foreach (var contract in contracts)
            {
                Contracts.Add(new ContractViewModel()
                {
                    ContractDate = DateTime.Now,
                    Id = contract.Id,
                    FullName = contract.FullName,
                    IpAddress = contract.IpAddress,
                    IsActive = contract.IsActive,
                    ServiceType = (Models.ServiceType)contract.ServiceType
                });
            }
            return View(Contracts.Where(x => x.IsActive == false).ToList());
        }
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return View(new ContractViewModel());
            }
            var contract = _repository.GetById(id.Value);

            var Contract = new ContractViewModel()
            {
                ContractDate = DateTime.Now,
                Id = contract.Id,
                FullName = contract.FullName,
                IpAddress = contract.IpAddress,
                IsActive = contract.IsActive,
                ServiceType = (Models.ServiceType)contract.ServiceType

            };
            if (contract == null)
            {
                return NotFound();
            }
            return View(Contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EnterEdit(ContractViewModel contract)
        {
            if (ModelState.IsValid)
            {
                var Contract = new M3Connect.Db.Models.Contract()
                {
                    ContractDate = DateTime.Now,
                    Id = contract.Id,
                    FullName = contract.FullName,
                    IpAddress = contract.IpAddress,
                    IsActive = contract.IsActive,
                    ServiceType = (M3Connect.Db.Models.ServiceType)contract.ServiceType

                };
                    
                _repository.Add(Contract);
                //else
                //{
                //    _repository.Update(Contract);
                //}
                return RedirectToAction(nameof(Index)); // Перенаправляем на страницу Index
            }
            return View(contract);
        }

        [HttpPost]
        public IActionResult ToggleStatus(Guid id)
        {
            var contract = _repository.GetById(id);
            if (contract != null)
            {
                contract.IsActive = !contract.IsActive;
                _repository.Update(contract);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
