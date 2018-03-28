using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoBoard.DataAccessLayer.Repositories;
using TodoBoard.Entities;

namespace TodoBoard.Controllers {
	public class ItemsController : ApiController {
		ITodoItemRepository _todoItemsRepo;

		public ItemsController(ITodoItemRepository todoItemsRepo) {
			_todoItemsRepo = todoItemsRepo;
		}

		[HttpGet]
		public IEnumerable<TodoItem> Get() {
			return _todoItemsRepo.GetAll();
		}

		[HttpGet]
		public TodoItem GetById(int id) {
			return _todoItemsRepo.GetById(id);
		}

		[HttpPost]
		public HttpResponseMessage CreateItem([FromBody]TodoItem item) {
			item = _todoItemsRepo.Add(item);

			var response = Request.CreateResponse<TodoItem>(HttpStatusCode.Created, item);
			response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.Id }));

			return response;
		}

		[HttpPut]
		public HttpResponseMessage UpdateItem(int id, [FromBody]TodoItem item) {
			_todoItemsRepo.Update(item);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[HttpDelete]
		public HttpResponseMessage DeleteItem(int id) {
			_todoItemsRepo.Delete(id);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}
	}
}
