using System;
using System.ComponentModel.DataAnnotations;

namespace teste.Models
{
	public class Teste
	{
		public int ID { get; set; }
		public string Titulo { get; set; } = string.Empty;

		[DataType(DataType.Date)]
		public DateTime DataLancamento { get; set; }
		public string Genero { get; set; } = string.Empty;
		public decimal Preco { get; set; }
		
	}
}
