using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelOtomasyon.Repository.Abstract;
using FluentValidation;
using OtelOtomasyon.DAL.Entities;

namespace OtelOtomassyon.BLL.Validations
{
    public class OdaGuncelleValidator :OdaValidator
    {
        public OdaGuncelleValidator(IOdaRepository odaRepo) : base(odaRepo)
        {
            
            RuleFor(x => x).Must(HasSameCategory).WithMessage("Aynı isimde oda mevcuttur.");
        }

        public bool HasSameCategory(Oda model)
        {
            //sistemde var olan ismi tekrar kullanacak şekilde kategoriyi güncellememize izin vermemesi lazım
            //gönderinIsim databasede gönderilenId dışındaki bir kategori ismi mi ?
            //böyle bir kayıt varsa null değilse o zaman bunu güncelleyemeyiz.
            var data = _odaRepo.Where(x => x.OdaAd == model.OdaAd && x.Id != model.Id).FirstOrDefault();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }
}
