using ProjetoSistema.Models;

public interface IMotoService
{
    Task<List<Moto>?> FindAllAsync();
}