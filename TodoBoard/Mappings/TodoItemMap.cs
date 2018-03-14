using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoBoard.Entities;

namespace TodoBoard.Mappings {
	public class TodoItemMap : ClassMap<TodoItem> {
		public TodoItemMap() {
			Id(item => item.Id);
			Map(item => item.Name);
			Map(item => item.Description);
			References(item => item.Board);
		}
	}
}