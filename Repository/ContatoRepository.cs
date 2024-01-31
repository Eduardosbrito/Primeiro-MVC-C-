using Microsoft.EntityFrameworkCore;
using PriSistema.Data;
using PriSistema.Interfaces.Repository;
using PriSistema.Models;
using System.Data;

namespace PriSistema.Repository
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _BancoContext;

        public ContatoRepository(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _BancoContext.Contatos.Add(contato);
            _BancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel BuscasPorId(int id)
        {
            return _BancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public bool ApagarPorId(int id)
        {
            ContatoModel contatoDB = BuscasPorId(id);

            if (contatoDB == null)
                throw new Exception("Houve Um erro para deletar o contato.");

            _BancoContext.Contatos.Remove(contatoDB);
            _BancoContext.SaveChanges();

            return true;
        }

        public List<ContatoModel> BuscasTodos()
        {
            return _BancoContext.Contatos.ToList();
        }

        public ContatoModel Alterar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscasPorId(contato.Id);

            if (contatoDB == null)
                throw new Exception("Houve Um erro para salvar o contato.");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _BancoContext.Contatos.Update(contatoDB);
            _BancoContext.SaveChanges();

            return contatoDB;
        }
    }
}
