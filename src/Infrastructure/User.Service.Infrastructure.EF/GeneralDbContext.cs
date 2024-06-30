using Microsoft.EntityFrameworkCore;
using User.Service.Infrastructure.EF.Configs;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF
{
	/// <summary>
	/// Контекст БД, который относится к общему функционалу
	/// </summary>
	internal class GeneralDbContext : DbContext
	{
		/// <summary>
		/// Таблица <see cref="TableExt.User"/>
		/// </summary>
		public DbSet<TableExt.User> Users { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="GeneralDbContext"/> class.
		/// </summary>
		/// <param name="options"><inheritdoc cref="DbContextOptions" path="/summary"/></param>
		public GeneralDbContext(DbContextOptions<GeneralDbContext> options)
			: base(options)
		{
		}

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfig());
		}
	}
}
