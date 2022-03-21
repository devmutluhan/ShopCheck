using Dapper;
using Models.Model;
using DataAccessLayer.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class InstallmentRepository : BaseRepository, IInstallmentRepository
    {
        public InstallmentRepository(Settings settings) : base(settings.ConnectionString)
        {

        }
        public List<Installment> GetInstallments()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Installment>("Select*From Installment").OrderBy(x=>x.InstallmentId).ToList();
            }
        }
    }
}
