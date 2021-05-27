using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Abstract
{
    public interface IComposerService
    {
        List<Composer> GetComposers();
        Composer GetComposerById(int id);
        void CreateComposer(Composer composer);
    }
}
