using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface ITodoItemRepository {
		int Add(TodoItem item);
		void AddOrUpdate(TodoItem item);
		void Remove(TodoItem item);
		TodoItem GetById(int id);
		IList<TodoItem> GetByBoard(Board board);
	}
}
