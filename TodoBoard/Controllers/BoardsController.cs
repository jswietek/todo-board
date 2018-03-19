using System.Collections.Generic;
using System.Web.Http;
using TodoBoard.DataAccessLayer.Repositories;
using TodoBoard.Entities;

namespace TodoBoard.Controllers {
	public class BoardsController : ApiController {
		IBoardRepository _boardRepo;

		public BoardsController(IBoardRepository boardRepo) {
			_boardRepo = boardRepo;
		}

		[HttpGet]
		public IEnumerable<Board> Get() {
			return _boardRepo.GetAll();
		}

		[HttpPost]
		public int AddBoard([FromBody] Board board) {
			return _boardRepo.Add(board);
		}

		[HttpPut]
		public void UpdateBoard([FromBody] Board board) {
			_boardRepo.Update(board);
		}
	}
}
