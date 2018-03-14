using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoBoard.DataAccessLayer.Repositories;
using TodoBoard.Entities;

namespace TodoBoard.Controllers {
	public class ItemsController : ApiController {
		ITodoItemRepository _todoItemsRepo;
		IBoardRepository _boardRepo;

		public ItemsController(ITodoItemRepository todoItemsRepo, IBoardRepository boardRepo) {
			_todoItemsRepo = todoItemsRepo;
			_boardRepo = boardRepo;
		}

		[HttpGet]
		public IEnumerable<Board> Get() {
			return _boardRepo.GetAll();
		}

		// POST: api/Items
		public void Post([FromBody]string value) {
		}

		// PUT: api/Items/5
		public void Put(int id, [FromBody]string value) {
		}

		// DELETE: api/Items/5
		public void Delete(int id) {
		}
	}
}
