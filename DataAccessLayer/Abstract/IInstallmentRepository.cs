using Models.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IInstallmentRepository
    {
        List<Installment> GetInstallments();
    }
}
