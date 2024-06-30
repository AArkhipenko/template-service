using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Service.Domain.Interface.Repositories;
using User.Service.Infrastructure.EF;
using User.Service.Infrastructure.EF.Repositories;

namespace User.Service.Application.V10
{
	/// <summary>
	/// Методы расширешения уровня Infrastructure
	/// </summary>
	public static class InfrastructureExtension
	{
		/// <summary>
		/// Регистрация репозиториев
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddRepositoryExtension(this IServiceCollection services)
		{
			services
				.AddTransient<IPublicRepository, PublicRepository>()
				.AddTransient<IUserRepository, UserRepository>();

			return services;
		}

		/// <summary>
		/// Добавление контекста БД, которая относится к базовому функционалу
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="connectionString">строка подключения к БД</param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddPublicDbContextExtension(
			this IServiceCollection services,
			string connectionString) => services.AddDbContextExtension<PublicDbContext>(connectionString);

		/// <summary>
		/// Добавление контекста БД, которая относится к общему функционалу
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="connectionString">строка подключения к БД</param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddGeneralDbContextExtension(
			this IServiceCollection services,
			string connectionString) => services.AddDbContextExtension<GeneralDbContext>(connectionString);

		/// <summary>
		/// Добавление контекста БД, которая относится к базовому функционалу
		/// </summary>
		/// <typeparam name="TContext">клас контекста, что надо добавить</typeparam>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="connectionString">строка подключения к БД</param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddDbContextExtension<TContext>(
			this IServiceCollection services,
			string connectionString)
			where TContext : DbContext
		{
			services.AddDbContext<TContext>(options =>
			{
				options.UseNpgsql(connectionString);
			});

			return services;
		}
	}
}
