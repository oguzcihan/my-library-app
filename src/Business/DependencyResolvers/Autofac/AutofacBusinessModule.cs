using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Business.Abstracts;
using Business.Concretes;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    /// <summary>
    /// Autofac dependency resolver plugin
    /// </summary>
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Book
            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<BookDal>().As<IBookDal>();

            //Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryDal>().As<ICategoryDal>();

            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            //Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>(); //ITokenHelper istenirse JWTHelper class ı çalışır.


        }
    }
}
