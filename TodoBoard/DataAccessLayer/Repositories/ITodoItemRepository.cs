using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface ITodoItemRepository {
		IEnumerable<TodoItem> GetAll();
		int Add(TodoItem item);
		void Update(TodoItem item);
		void Remove(TodoItem item);
		TodoItem GetById(int id);
	}
}
