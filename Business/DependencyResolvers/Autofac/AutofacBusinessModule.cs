using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<SponsorManager>().As<ISponsorService>().SingleInstance();
            builder.RegisterType<EfSponsorDal>().As<ISponsorDal>().SingleInstance();

            builder.RegisterType<VisitManager>().As<IVisitService>().SingleInstance();
            builder.RegisterType<EfVisitDal>().As<IVisitDal>().SingleInstance();

            builder.RegisterType<AssignmentManager>().As<IAssignmentService>().SingleInstance();
            builder.RegisterType<EfAssignmentDal>().As<IAssignmentDal>().SingleInstance();

            builder.RegisterType<EquipmentManager>().As<IEquipmentService>().SingleInstance();
            builder.RegisterType<EfEquipmentDal>().As<IEquipmentDal>().SingleInstance();

            builder.RegisterType<PatientManager>().As<IPatientService>().SingleInstance();
            builder.RegisterType<EfPatientDal>().As<IPatientDal>().SingleInstance();

            builder.RegisterType<SiteManager>().As<ISiteService>().SingleInstance();
            builder.RegisterType<EfSiteDal>().As<ISiteDal>().SingleInstance();

            builder.RegisterType<StudyManager>().As<IStudyService>().SingleInstance();
            builder.RegisterType<EfStudyDal>().As<IStudyDal>().SingleInstance();

            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
