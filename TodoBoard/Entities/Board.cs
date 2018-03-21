using System.Collections.Generic;
using System.Linq;

namespace TodoBoard.Entities {
	public class Board {
		public Board() {
			TodoItems = new List<TodoItem>();
		}

		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IList<TodoItem> TodoItems { get; set; }

		public virtual void AddItem(TodoItem item) {
			item.BoardId = Id;
			TodoItems.Add(item);
		}

		public virtual void RemoveItem(int id) {
			var removed = TodoItems.FirstOrDefault(item => item.Id == id);
			TodoItems.Remove(removed);
		}

		public virtual void RemoveItem(TodoItem item) {
			TodoItems.Remove(item);
		}
	}
}