﻿using Microsoft.EntityFrameworkCore;
using PriSistema.Models;

namespace PriSistema.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
