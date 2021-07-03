using System;
using System.Threading.Tasks;

namespace NegocieOnline.Business.Models.Cep.Services
{
    public interface ICepService: IDisposable
    {
        Task Adicionar(Cep cep);
        Task Atualizar(Cep cep);
        Task Remover(Guid id);
    }
}