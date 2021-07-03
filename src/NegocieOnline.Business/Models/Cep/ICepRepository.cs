using System.Threading.Tasks;
using NegocieOnline.Business.Core.Data;

namespace NegocieOnline.Business.Models.Cep
{
    public interface ICepRepository : IRepository<Cep>
    {
        Task<Cep> ObterCep(string cep);
    }
}