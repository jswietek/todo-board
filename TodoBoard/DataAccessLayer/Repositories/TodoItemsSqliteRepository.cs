using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public class TodoItemsSqliteRepository : ITodoItemRepository {
		IUnitOfWork _unitOfWork;

		public TodoItemsSqliteRepository(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		public void Add(TodoItem item) {
			_unitOfWork.Session.Save(item);
		}

		public void Remove(TodoItem item) {
			_unitOfWork.Session.Delete(item);
		}

		public void Update(TodoItem item) {
			_unitOfWork.Session.Update(item);
		}

		public IList<TodoItem> GetByBoard(Board board) {
			return _unitOfWork.Session.QueryOver<TodoItem>().Where(item => item.Board.Id == board.Id).List();
		}

		public TodoItem GetById(int id) {
			return _unitOfWork.Session.Get<TodoItem>(id);
		}
	}
}