using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtelOtomassyon.BLL.DTOs;
using OtelOtomasyon.DAL.Entities;
using OtelOtomassyon.BLL.Validations;
using OtelOtomasyon.Repository.UOW.Abstract;

namespace OtelOtomassyon.BLL.Services.Concretes
{
   public  class OdaService:IOdaService
    {
        private readonly IOdaRepository _odaRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OdaService(IOdaRepository odaRepository,IUnitOfWork uow)
        {
            _odaRepository = odaRepository;
            _unitOfWork = uow;
        }

        public ResultModel<Oda> OdaEkle(Oda model)
        {
            var validator = new OdaEkleValidator(_odaRepository).Validate(model);
            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Oda>().Add(model);
                if (_unitOfWork.Commit() > 0)
                {
                   
                    return new ResultModel<Oda>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = "Oda ekleme işlemi başarılı"
                    };
                }
            }

            return new ResultModel<Oda>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Kayıt Başarısız"
            };
        }

        public ResultModel<Oda> OdaGuncelle(Oda model)
        {
            var validator = new OdaGuncelleValidator(_odaRepository).Validate(model);
            if (validator.IsValid)
            {
                _unitOfWork.GetRepo<Oda>().Update(model);
                if (_unitOfWork.Commit() > 0)
                {
                    return new ResultModel<Oda>
                    {
                        Errors = null,
                        IsValid = true,
                        Message = "Oda güncelleme işlemi başarılı"
                    };
                }
            }
            return new ResultModel<Oda>
            {
                Errors = validator.Errors.Select(x => x.ErrorMessage).ToList(),
                IsValid = false,
                Message = "Güncelleme Başarısız"
            };
        }
    }
    
}
