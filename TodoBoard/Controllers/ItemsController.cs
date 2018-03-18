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
		public IEnumerable<Board> Get() {
			return _boardRepo.GetAll();
		}

		// POST: api/Items
		public void Post([FromBody]TodoItem item) {
			_todoItemsRepo.Add(item);
			var board = _boardRepo.GetById(item.Board.Id);
			board.AddItem(item);
			_boardRepo.Update(board);
		}

		// PUT: api/Items/5
		public void Put(int id, [FromBody]TodoItem item) {
			_todoItemsRepo.AddOrUpdate(item);
		}

		// DELETE: api/Items/5
		public void Delete(int id) {
		}
	}
}
