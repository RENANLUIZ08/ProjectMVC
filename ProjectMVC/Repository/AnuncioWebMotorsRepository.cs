using ProjectMVC.Data;
using ProjectMVC.Data.Context;
using ProjectMVC.Models;
using ProjectMVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMVC.Repository
{
    public class AnuncioWebMotorsRepository : RepositoryBase<AnuncioWebmotors>, IAnuncioWebmotors
    {
        public AnuncioWebMotorsRepository(ApplicationDbContext contexto) : base(contexto)
        {

        }
    }
}
