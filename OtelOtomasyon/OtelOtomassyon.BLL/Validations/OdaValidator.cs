using FluentValidation;
using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Validations
{
   public class OdaValidator:AbstractValidator<Oda>
    {
        protected IOdaRepository _odaRepo;
        public OdaValidator(IOdaRepository odaRepo)
        {
            _odaRepo = odaRepo;

            RuleFor(x => x.OdaAd).NotEmpty().WithMessage("Oda adını girmek zorundasınız");
            RuleFor(x => x.DoluMu.ToString()).NotEmpty().WithMessage("Odanın dolu veya boş olduğunu belirtiniz");
                    
        }

        
    }
}
