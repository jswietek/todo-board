using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TodoBoard.DataAccessLayer;
using TodoBoard.DataAccessLayer.Repositories;

namespace TodoBoard {
	public class WebApiApplication : System.Web.HttpApplication {
		protected void Application_Start() {
			GlobalConfiguration.Configure(WebApiConfig.Register);
			SetDependencyInjectionResolver(GlobalConfiguration.Configuration);
		}

		void SetDependencyInjectionResolver(HttpConfiguration config) {
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterWebApiFilterProvider(config);

			builder.Register(c => new UnitOfWorkActionFilter())
				.AsWebApiActionFilterFor<ApiController>()
				.InstancePerRequest();

			RegisterDependencies(builder);

			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		void RegisterDependencies(ContainerBuilder builder) {
			builder.RegisterType<DevUnitOfWork>().As<IUnitOfWork>();
			builder.RegisterType<BoardSqliteRepository>().As<IBoardRepository>();
			builder.RegisterType<TodoItemsSqliteRepository>().As<ITodoItemRepository>();
		}
	}
}
