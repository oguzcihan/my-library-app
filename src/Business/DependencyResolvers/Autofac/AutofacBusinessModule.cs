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
using DataAccess.Concretes;
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
            builder.RegisterType<BookRepository>().As<IBookRepository>();

            //Category
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();

            //User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            //Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>(); //ITokenHelper istenirse JWTHelper class ı çalışır.


        }
    }
}
