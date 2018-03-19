using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface IBoardRepository {
		int Add(Board item);
		void Update(Board item);
		void Remove(Board item);
		Board GetById(int id);
		IEnumerable<Board> GetAll();
	}
}
