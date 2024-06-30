using Microsoft.EntityFrameworkCore;
using User.Service.Infrastructure.EF.Configs;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF
{
	/// <summary>
	/// Контекст БД, которая относится к базовому функционалу
	/// </summary>
	internal class PublicDbContext : DbContext
	{
		/// <summary>
		/// Таблица <see cref="TableExt.Base"/>
		/// </summary>
		public DbSet<TableExt.Base> Bases { get; set; }

		/// <summary>
		/// Таблица <see cref="TableExt.Category"/>
		/// </summary>
		public DbSet<TableExt.Category> Categories { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PublicDbContext"/> class.
		/// </summary>
		/// <param name="options"><inheritdoc cref="DbContextOptions" path="/summary"/></param>
		public PublicDbContext(DbContextOptions<PublicDbContext> options)
			: base(options)
		{
		}

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BaseConfig());
			modelBuilder.ApplyConfiguration(new CategoryConfig());
		}
	}
}
