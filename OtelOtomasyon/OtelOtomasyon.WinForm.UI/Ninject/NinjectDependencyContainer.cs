using Ninject;
using OtelOtomasyon.DAL.Context;
using OtelOtomasyon.Repository.Abstract;
using OtelOtomasyon.Repository.Concrete;
using OtelOtomasyon.Repository.UOW.Abstract;
using OtelOtomasyon.Repository.UOW.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.WinForm.UI.Ninject
{
    public class NinjectDependencyContainer
    {
        public static IKernel RegisterDependency(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ProjectContext>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            return kernel;
        }
    }
}
