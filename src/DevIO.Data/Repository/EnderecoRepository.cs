using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MyDbContext context) : base(context) { }

        public async Task<Endereco> GetEnderecoByFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(f => f.Id == fornecedorId);
        }
    }
}
