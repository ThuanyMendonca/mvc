using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace teste.Models
{
	public class Teste
	{
		public int ID { get; set; }

		[MaxLength(100)]
		[Required(ErrorMessage = "Esse campo é obrigatório")]
		public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Data de Lançamento")]
		[DataType(DataType.Date)]
		public DateTime DataLancamento { get; set; }
        
		[Required(ErrorMessage = "Esse campo é obrigatório"), 
			StringLength(10),
			RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")
		]
        public string Genero { get; set; } = string.Empty;
        
		[Display(Name = "Preço")]
		[Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public decimal Preco { get; set; }
        
		[Required(ErrorMessage = "Esse campo é obrigatório")]
		[Range(0,5)]
        public int? Pontos { get; set; }
		
	}
}
