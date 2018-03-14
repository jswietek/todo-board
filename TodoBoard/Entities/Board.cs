using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoBoard.Entities
{
	public class Board
	{
		public Board()
		{
			TodoItems = new List<TodoItem>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public IList<TodoItem> TodoItems { get; set; }
	}
}