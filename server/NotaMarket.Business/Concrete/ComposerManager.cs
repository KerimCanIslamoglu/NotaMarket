using NotaMarket.Business.Abstract;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Concrete
{
    public class ComposerManager : IComposerService
    {
        private IComposerDal _composerDal;

        public ComposerManager(IComposerDal composerDal)
        {
            _composerDal = composerDal;
        }

        public void CreateComposer(Composer composer)
        {
            _composerDal.Create(composer);
        }

        public Composer GetComposerById(int id)
        {
            return _composerDal.GetById(id);
        }

        public List<Composer> GetComposers()
        {
            return _composerDal.GetAll();
        }
    }
}
