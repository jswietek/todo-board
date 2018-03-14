using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public class BoardSqliteRepository : IBoardRepository {
		IUnitOfWork _unitOfWork;

		public BoardSqliteRepository(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		public void Add(Board item) {
			_unitOfWork.Session.Save(item);
		}

		public Board GetById(int id) {
			return _unitOfWork.Session.Get<Board>(id);
		}

		public void Remove(Board item) {
			_unitOfWork.Session.Delete(item);
		}

		public void Update(Board item) {
			_unitOfWork.Session.Update(item);
		}
	}
}