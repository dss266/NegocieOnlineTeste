using NegocieOnline.Business.Models.Cep.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;
using NegocieOnline.Business.Core.Notifications;
using NegocieOnline.Business.Core.Service;

namespace NegocieOnline.Business.Models.Cep.Services
{
    public class CepService: BaseService,ICepService
    {
        private readonly ICepRepository _cepRepository;

        public CepService(ICepRepository cepRepository,INotification notification):base(notification)
        {
            _cepRepository = cepRepository;
        }

        public void Dispose()
        {
            _cepRepository?.Dispose();
        }

        public async Task Adicionar(Cep cep)
        {
            if (!ExecutarValidacao(new CepValidation(),cep))
             return;

            if (await CepExistente(cep))return;
            
            await _cepRepository.Adicionar(cep);

        }

        public async Task Atualizar(Cep cep)
        {
            if (!ExecutarValidacao(new CepValidation(), cep))
                return;

            if (await CepExistente(cep)) return;
            
            await _cepRepository.Atualizar(cep);

        }

        public async Task Remover(Guid id)
        {
            var cep = await _cepRepository.ObterPorId(id);

            if (cep.CEP != null)
            {
                await _cepRepository.Remover(cep.Id);
            }
        }

        public async Task<bool> CepExistente(Cep cep)
        {
            var cepAtual = await _cepRepository.Buscar(c => c.CEP == cep.CEP);

            if (!cepAtual.Any()) return false;

            Notificar("Já existe este CEP cadastrado");

            return true;
        }

    }
}