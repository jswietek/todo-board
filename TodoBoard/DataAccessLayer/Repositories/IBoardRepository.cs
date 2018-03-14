using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface IBoardRepository {
		void Add(Board item);
		void Update(Board item);
		void Remove(Board item);
		Board GetById(int id);
	}
}
