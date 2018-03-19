using FluentNHibernate.Mapping;
using TodoBoard.Entities;

namespace TodoBoard.Mappings {
	public class BoardMap : ClassMap<Board> {
		public BoardMap() {
			Id(board => board.Id).GeneratedBy.HiLo("1000");
			Map(board => board.Name);
			HasMany(board => board.TodoItems)
				.Cascade.All();
		}
	}
}