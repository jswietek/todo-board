using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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

		[HttpGet]
		public Board GetById(int id) {
			return _boardRepo.GetById(id);
		}

		[HttpPost]
		public HttpResponseMessage AddBoard([FromBody] Board board) {
			board = _boardRepo.Add(board);
			var response = Request.CreateResponse<Board>(HttpStatusCode.Created, board);
			return response;
		}

		[HttpPut]
		public HttpResponseMessage UpdateBoard([FromBody] Board board) {
			_boardRepo.Update(board);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}

		[HttpDelete]
		public HttpResponseMessage DeleteBoard(int id) {
			_todoItemsRepo.Delete(id);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}
	}
}
