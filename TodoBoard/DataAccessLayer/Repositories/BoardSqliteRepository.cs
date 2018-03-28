using System.Collections.Generic;
using System.Linq;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public class BoardSqliteRepository : IBoardRepository {
		IUnitOfWork _unitOfWork;

		public BoardSqliteRepository(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		public Board Add(Board item) {
			return (Board)_unitOfWork.Session.Save(item);
		}

		public Board GetById(int id) {
			return _unitOfWork.Session.Get<Board>(id);
		}

		public IEnumerable<Board> GetAll() {
			return _unitOfWork.Session.Query<Board>().ToList();
		}

		public void Delete(int id) {
			var board = GetById(id);
			_unitOfWork.Session.Delete(board);
		}

		public void Update(Board item) {
			_unitOfWork.Session.Update(item);
		}
	}
}