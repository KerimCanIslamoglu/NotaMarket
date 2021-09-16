using NotaMarket.DataAccess.Abstract;
using NotaMarket.DataAccess.Context;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Concrete
{
    public class ComposerDal : GenericRepository<Composer, ApplicationDbContext>, IComposerDal
    {
    }
}
