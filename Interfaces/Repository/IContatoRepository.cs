using PriSistema.Models;

namespace PriSistema.Interfaces.Repository
{
    public interface IContatoRepository
    {
        ContatoModel Adicionar(ContatoModel contato);
        List<ContatoModel> BuscasTodos();
        ContatoModel BuscasPorId(int id);
        bool ApagarPorId(int id);
        ContatoModel Alterar(ContatoModel contato);
    }
}
