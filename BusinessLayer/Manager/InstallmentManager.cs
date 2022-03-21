using DataAccessLayer.Abstract;
using Models.Model;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class InstallmentManager
    {
        private readonly IInstallmentRepository ınstallmentRepository;
        public InstallmentManager(IInstallmentRepository ınstallmentRepository)
        {
            this.ınstallmentRepository = ınstallmentRepository;
        }

        public List<Installment> Get()
        {
            return ınstallmentRepository.GetInstallments();
        }
    }
}
