﻿using FluentValidation;
using OtelOtomasyon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomassyon.BLL.Validations
{
   public class KatValidator:AbstractValidator<Kat>
    {
        public KatValidator()
        {

        }
    }
}
