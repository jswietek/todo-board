using System.Collections.Generic;
using System.Linq;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public class TodoItemsSqliteRepository : ITodoItemRepository {
		IUnitOfWork _unitOfWork;

		public TodoItemsSqliteRepository(IUnitOfWork unitOfWork) {
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<TodoItem> GetAll() {
			return _unitOfWork.Session.Query<TodoItem>().ToList();
		}

		public int Add(TodoItem item) {
			return ((TodoItem)_unitOfWork.Session.Save(item)).Id;
		}

		public void Remove(TodoItem item) {
			_unitOfWork.Session.Delete(item);
		}

		public void Update(TodoItem item) {
			_unitOfWork.Session.Update(item);
		}

		public IList<TodoItem> GetByBoard(Board board) {
			return _unitOfWork.Session.QueryOver<TodoItem>().Where(item => item.BoardId == board.Id).List();
		}

		public TodoItem GetById(int id) {
			return _unitOfWork.Session.Get<TodoItem>(id);
		}
	}
}