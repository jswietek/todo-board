namespace TodoBoard.Entities {
	public class TodoItem {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Board Board { get; set; }
	}
}