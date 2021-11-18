using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Models
{
    public class AnuncioWebmotors
    {
        [DisplayName("#")]
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Por favor, informe a Marca")]
        [DisplayName("Marca")]
        [StringLength(45, ErrorMessage = "A Marca deve conter até 45 caracteres")]
        public string marca { get; set; }
        [Required(ErrorMessage = "Por favor, informe o Modelo")]
        [DisplayName("Modelo")]
        [StringLength(45, ErrorMessage = "A Modelo deve conter até 45 caracteres")]
        public string modelo { get; set; }
        [Required(ErrorMessage = "Por favor, informe a Versão")]
        [DisplayName("Versão")]
        [StringLength(45, ErrorMessage = "A Versão deve conter até 45 caracteres")]
        public string versao { get; set; }
        [Required(ErrorMessage = "Por favor, informe o Ano de Fabricação")]
        [DisplayName("Ano")]
        public int ano { get; set; }
        [Required(ErrorMessage = "Por favor, informe a Quilometragem")]
        [DisplayName("Quilometragem")]
        public int quilometragem { get; set; }
        [Required(ErrorMessage = "Por favor, informe a Observação")]
        [DisplayName("Observação")]
        public string observacao { get; set; }
    }
}
