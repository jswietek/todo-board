using System.Collections.Generic;
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
		public IEnumerable<TodoItem> Get() {
			return _todoItemsRepo.GetAll();
		}

		[HttpPost]
		public int CreateItem([FromBody]TodoItem item) {
			var result = _todoItemsRepo.Add(item);
			_boardRepo.GetById(item.BoardId).AddItem(item);
			return result;
		}

		[HttpPut]
		public void UpdateItem(int id, [FromBody]TodoItem item) {
			_todoItemsRepo.Update(item);
		}
	}
}
