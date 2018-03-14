using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer {
	public class DevUnitOfWork : IUnitOfWork {
		static ISessionFactory _sessionFactory;
		static readonly string DB_FILE_NAME = "development.db";
		ITransaction _transaction;

		public DevUnitOfWork() {
			Session = _sessionFactory.OpenSession();
		}

		static DevUnitOfWork() {
			_sessionFactory = Fluently.Configure()
				.Database(SQLiteConfiguration.Standard
				.UsingFile(DB_FILE_NAME)
				)
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Board>())
				.ExposeConfiguration(BuildSchema)
				.BuildSessionFactory();

		}

		static void BuildSchema(Configuration config) {
			if (File.Exists(DB_FILE_NAME)) {
				File.Delete(DB_FILE_NAME);
			}

			new SchemaExport(config)
				.Create(false, true);
		}

		public ISession Session {
			get; private set;
		}

		public void BeginTransaction() {
			_transaction = Session.BeginTransaction();
		}

		public void Commit() {
			try {
				if (_transaction != null && _transaction.IsActive)
					_transaction.Commit();
			}
			catch {
				if (_transaction != null && _transaction.IsActive)
					_transaction.Rollback();

				throw;
			}
			finally {
				Session.Dispose();
			}
		}

		public void Rollback() {
			try {
				if (_transaction != null && _transaction.IsActive)
					_transaction.Rollback();
			}
			finally {
				Session.Dispose();
			}
		}
	}
}