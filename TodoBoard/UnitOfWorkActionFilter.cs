using Autofac.Integration.WebApi;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TodoBoard.DataAccessLayer;

namespace TodoBoard {
	public class UnitOfWorkActionFilter : IAutofacActionFilter {
		public IUnitOfWork UnitOfWork { get; set; }

		public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken) {
			UnitOfWork = actionContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
			UnitOfWork?.BeginTransaction();
			return Task.FromResult(0);
		}

		public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken) {
			if (actionExecutedContext.Exception == null) {
				UnitOfWork.Commit();
			}
			else {
				UnitOfWork.Rollback();
			}
			return Task.FromResult(0);
		}
	}
}