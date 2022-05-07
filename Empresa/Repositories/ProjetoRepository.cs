using Empresa.Contexts;
using Empresa.Models;

namespace Empresa.Repositories;

public class ProjetoRepository
{
    private readonly EmpresaContext _context;

    public ProjetoRepository(EmpresaContext context)
    {
        _context = context;
    }

    public List<Projeto> Listar()
    {
        return _context.Projeto.ToList();
    }

    public Projeto BuscarPorId(int id)
    {
        return _context.Projeto.Find(id);
    }

    public void Cadastrar(Projeto projeto)
    {
        _context.Projeto.Add(projeto);
        _context.SaveChanges();
    }

    public void Atualizar(int id, Projeto projeto)
    {
        Projeto projetoBuscado = _context.Projeto.Find(id);
        if (projetoBuscado != null)
        {
            projetoBuscado.Nome = projeto.Nome;
            projetoBuscado.Porte = projeto.Porte;
        }

        _context.Projeto.Update(projetoBuscado);
        _context.SaveChanges();
    }

    public void Deletar(int id)
    {
        Projeto projetoBuscado = _context.Projeto.Find(id);
        _context.Projeto.Remove(projetoBuscado);
        _context.SaveChanges();
    }

}