using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NegocieOnline.AppMVC.ViewModels;
using NegocieOnline.Business.Core.Data;
using NegocieOnline.Business.Core.Notifications;
using NegocieOnline.Business.Models.Cep;
using NegocieOnline.Business.Models.Cep.Services;
using NegocieOnline.Infra.Data.Repository;
using Newtonsoft.Json;
using RestSharp;

namespace NegocieOnline.AppMVC.Controllers
{
    public class CepController : Controller
    {

        private readonly ICepRepository _cepRepository;
        private readonly ICepService _cepService;
        private readonly IMapper _mapper;



        public CepController(ICepRepository cepRepository, ICepService cepService, IMapper mapper)
        {
            _cepRepository = cepRepository;
            _cepService = cepService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CepViewModel>>(await _cepRepository.ObterTodos()));
        }

        // GET: Cep/Details/5
        public async Task<ActionResult> Details(string c)
        {
            var cepViewModel = await BuscarPorCep(c);


            if (cepViewModel == null)
            {
                return HttpNotFound();
            }

            return View(cepViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CepViewModel cepViewModel)
        {
            
            if (ModelState.IsValid)
            {

                var cep = GetCepAsync(cepViewModel.cep);


                cep.DataCadastro = DateTime.Now;

                await _cepService.Adicionar(_mapper.Map<Cep>(cep));

                return RedirectToAction("Index");
            }

            return View(cepViewModel);
        }

        public CepViewModel GetCepAsync(string cep)
        {

            if (cep.Contains('-'))
            {
                cep = cep.Remove('-');

                var client = new RestClient("https://viacep.com.br/ws/" + cep + "/json/");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var result = response.Content;

                CepViewModel resultado = JsonConvert.DeserializeObject<CepViewModel>(result);

                return resultado;
            }
            else
            {


                var client = new RestClient("https://viacep.com.br/ws/" + cep + "/json/");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                var body = @"";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                var result = response.Content;

                CepViewModel resultado = JsonConvert.DeserializeObject<CepViewModel>(result);

                return resultado;
            }




        }

        private async Task<CepViewModel> BuscarPorCep(string c)
        {
            c = c.Remove('-');

            var cep = _mapper.Map<CepViewModel>(await _cepRepository.ObterCep(c));

            return cep;

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cepRepository.Dispose();
                _cepService.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    internal interface IRepository
    {
    }
}
