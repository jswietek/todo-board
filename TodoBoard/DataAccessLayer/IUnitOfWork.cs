using NHibernate;

namespace TodoBoard.DataAccessLayer {
	public interface IUnitOfWork {
		ISession Session { get; }
		void BeginTransaction();
		void Commit();
		void Rollback();
	}
}
