using FluentNHibernate.Mapping;
using TodoBoard.Entities;

namespace TodoBoard.Mappings {
	public class TodoItemMap : ClassMap<TodoItem> {
		public TodoItemMap() {
			Id(item => item.Id);
			Map(item => item.Name);
			Map(item => item.Description);
			Map(item => item.BoardId);
		}
	}
}