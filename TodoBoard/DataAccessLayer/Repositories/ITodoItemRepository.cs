using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface ITodoItemRepository {
		IEnumerable<TodoItem> GetAll();
		TodoItem Add(TodoItem item);
		void Update(TodoItem item);
		void Delete(int item);
		TodoItem GetById(int id);
	}
}
