namespace TodoBoard.Entities {
	public class TodoItem {
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
		public virtual Board Board { get; set; }
	}
}