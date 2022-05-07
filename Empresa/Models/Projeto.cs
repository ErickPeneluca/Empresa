using System.ComponentModel.DataAnnotations;

namespace Empresa.Models;

public class Projeto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Porte { get; set; }
}