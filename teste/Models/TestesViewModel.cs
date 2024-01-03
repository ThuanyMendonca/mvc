using Microsoft.AspNetCore.Mvc.Rendering;

namespace teste.Models
{
    public class TestesViewModel
    {
        public List<Teste>? Testes { get; set; }
        public SelectList? Generos { get; set; }
        public string? Genero {  get; set; }
        public string? Texto { get; set; }

    }
}
