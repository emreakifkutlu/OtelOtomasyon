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
 public class OdaEkleValidator:OdaValidator
    {
        public OdaEkleValidator(IOdaRepository odaRepo) : base(odaRepo)
        {

         
            RuleFor(x => x.OdaAd).Must(UniqeNameCheck).WithMessage("Aynı isimde oda mevcuttur.");
        }
         public bool UniqeNameCheck(string name)
        {
            var data = _odaRepo.Where(x => x.OdaAd == name).FirstOrDefault();

            if (data == null)
            {
                return true;
            }

            return false;
        }
    }

   
}
