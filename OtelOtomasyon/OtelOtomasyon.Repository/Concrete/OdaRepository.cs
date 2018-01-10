using OtelOtomasyon.Core.Abstract;
using OtelOtomasyon.Core.Concrete;
using OtelOtomasyon.DAL.Context;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.Repository.Concrete
{
    public class OdaRepository : EFRepositoryBase<Oda, ProjectContext>, IOdaRepository
    {
        
        public OdaRepository(DbContext Context) : base(Context)
        {
            
         }

        public int BosOdaSayisiBul()
        {
            int BosOdaSayisi = _dbContext.Set<Oda>().Where(x => x.DoluMu == false).Count();
            return BosOdaSayisi;
        }
    }
}
