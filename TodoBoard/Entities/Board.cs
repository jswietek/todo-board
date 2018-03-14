using System.Collections.Generic;
using System.Linq;

namespace TodoBoard.Entities {
	public class Board {
		public Board() {
			TodoItems = new List<TodoItem>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public IList<TodoItem> TodoItems { get; set; }

		public void AddItem(TodoItem item) {
			item.Board = this;
			TodoItems.Add(item);
		}

		public void RemoveItem(int id) {
			var removed = TodoItems.FirstOrDefault(item => item.Id == id);
			TodoItems.Remove(removed);
		}

		public void RemoveItem(TodoItem item) {
			TodoItems.Remove(item);
		}
	}
}