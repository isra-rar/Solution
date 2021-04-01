using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {

        public FornecedorRepository(MyDbContext context) : base(context) { }

        public async Task<Fornecedor> GetEnderecoByFornecedor(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Fornecedor> GetFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(p => p.Produtos).Include(e => e.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
