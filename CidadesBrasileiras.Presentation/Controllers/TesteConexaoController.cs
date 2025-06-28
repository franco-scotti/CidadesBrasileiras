using Microsoft.AspNetCore.Mvc;
using CidadesBrasileiras.Infrastructure.Data;

public class TesteConexaoController : Controller
{
    private readonly AppDbContext _context;

    public TesteConexaoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        try
        {
            bool conectado = _context.Database.CanConnect();

            if (conectado)
                return Content("✅ Conexão com o banco de dados bem-sucedida!");
            else
                return Content("❌ Não foi possível conectar ao banco de dados.");
        }
        catch (Exception ex)
        {
            return Content("❌ Erro ao tentar conectar: " + ex.Message);
        }
    }
}
