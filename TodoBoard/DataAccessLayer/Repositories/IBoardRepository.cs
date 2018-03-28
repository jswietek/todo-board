using System.Collections.Generic;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer.Repositories {
	public interface IBoardRepository {
		Board Add(Board item);
		void Update(Board item);
		void Delete(int id);
		Board GetById(int id);
		IEnumerable<Board> GetAll();
	}
}
