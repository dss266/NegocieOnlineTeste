using System.Data.Entity;
using System.Threading.Tasks;
using NegocieOnline.Business.Models.Cep;

namespace NegocieOnline.Infra.Data.Repository
{
    public class CepRepository:Repository<Cep>,ICepRepository
    {
        public CepRepository(NegocieOnlineDbContext context) : base(context){}
    
        public async Task<Cep> ObterCep(string cep)
        {
            return await _context.Ceps.AsNoTracking()
                .FirstOrDefaultAsync(c=>c.CEP == cep);
        }

        public Task Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}