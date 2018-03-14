using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoBoard.Entities
{
	public enum TodoItemState { Todo, Working, Done }

	public class TodoItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public TodoItemState State { get; set; }
	}
}