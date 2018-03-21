using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using TodoBoard.Entities;

namespace TodoBoard.DataAccessLayer {
	public class DevUnitOfWork : IUnitOfWork {
		static ISessionFactory _sessionFactory;
		static readonly string DB_FILE_NAME = HostingEnvironment.MapPath(@"~\development.db");
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


			using (var session = _sessionFactory.OpenSession()) {
				using (var transaction = session.BeginTransaction()) {
					var board = new Board() {
						Name = "test_board1",
						TodoItems = new List<TodoItem>() {
							new TodoItem() {
								Name = "test_todo_item1",
								Description = "test_todo_description"
							}
						}
					};

					session.Save(board);
					transaction.Commit();
				}
			}


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
				Session.Close();
			}
		}

		public void Rollback() {
			try {
				if (_transaction != null && _transaction.IsActive)
					_transaction.Rollback();
			}
			finally {
				Session.Close();
			}
		}
	}
}