using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NegocieOnline.AppMVC.ViewModels
{
    public class CepViewModel
    {
        
        public CepViewModel()
        {
            Id = Guid.NewGuid();
        }
        
        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo{0} é obrigatorio")]
        [DisplayName("Cep")]
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        
    }

    public class RootObject
    {
        public List<CepViewModel> CepViewModels { get; set; }
    }
}