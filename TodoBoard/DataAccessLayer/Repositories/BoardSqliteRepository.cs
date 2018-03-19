using System.Collections.Generic;
using System.Linq;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public class BoardSqliteRepository : IBoardRepository {
		IUnitOfWork _unitOfWork;

		public BoardSqliteRepository(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		public int Add(Board item) {
			return (int)_unitOfWork.Session.Save(item);
		}

		public Board GetById(int id) {
			return _unitOfWork.Session.Get<Board>(id);
		}

		public IEnumerable<Board> GetAll() {
			return _unitOfWork.Session.Query<Board>().ToList();
		}

		public void Remove(Board item) {
			_unitOfWork.Session.Delete(item);
		}

		public void Update(Board item) {
			_unitOfWork.Session.Update(item);
		}
	}
}