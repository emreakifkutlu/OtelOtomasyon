using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public  class OdaService:IOdaService
    {
        private readonly IOdaRepository _odaRepository;
        public OdaService(IOdaRepository odaRepository)
        {
            _odaRepository = odaRepository;
        }

        public int BosOdaSayisiBul()
        {
           
            int BosOdaSayisi = _odaRepository.GetList().Where(x=>x.DoluMu==false).Count();
            return BosOdaSayisi;
        }
            
        }
    
}
