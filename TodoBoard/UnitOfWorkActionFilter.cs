﻿using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TodoBoard.DataAccessLayer;

namespace TodoBoard {
	public class UnitOfWorkActionFilter : ActionFilterAttribute {
		public IUnitOfWork UnitOfWork { get; set; }

		public override void OnActionExecuting(HttpActionContext actionContext) {
			UnitOfWork = actionContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
			UnitOfWork?.BeginTransaction();
		}

		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {
			UnitOfWork = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
			if (actionExecutedContext.Exception == null) {
				UnitOfWork.Commit();
			}
			else {
				UnitOfWork.Rollback();
			}
		}
	}
}