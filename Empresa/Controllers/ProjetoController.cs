using Empresa.Repositories;
using Microsoft.AspNetCore.Http;
using Empresa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class ProjetoController : ControllerBase
{
    private readonly ProjetoRepository _projetoRepository;

    public ProjetoController(ProjetoRepository projetoRepository)
    {
        _projetoRepository = projetoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_projetoRepository.Listar());
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpGet("id")]
    public IActionResult BuscarPorId(int id)
    {
        try
        {
            Projeto projetoBuscado = _projetoRepository.BuscarPorId(id);

            if (projetoBuscado == null)
            {
                return NotFound();
            }

            return Ok(projetoBuscado);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Criar(Projeto projeto)
    {
        try
        {
            _projetoRepository.Cadastrar(projeto);

            return Ok("Projeto criado!");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpPut("id")]
    public IActionResult Atualizar(int id, Projeto projeto)
    {
        try
        {
            _projetoRepository.Atualizar(id, projeto);

            return Ok("Projeto atualizado!");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [HttpDelete("id")]
    public IActionResult Deletar(int id)
    {
        try
        {
            _projetoRepository.Deletar(id);

            return Ok("Projeto deletado!");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}