using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using NegocieOnline.Business.Models.Cep;
using NegocieOnline.Business.Models.Cep.Services;
using NegocieOnline.Infra.Data.Repository;

namespace NegocieOnline.AppMVC.Controllers
{
    public class CepController : Controller
    {
        private readonly ICepService _cepService;

        public CepController()
        {
            _cepService = new CepService(new CepRepository());
        }
        // GET
        public async Task<ActionResult> Index()
        {
            var cep = new Cep()
            {
                CEP = "",
                Bairro = "",
                DDD ="",
                DataCadastro = DateTime.Now
            };

            await _cepService.Adicionar(cep);
            return new EmptyResult();
        }
    }
}