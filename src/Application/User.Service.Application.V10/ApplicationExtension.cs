using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using User.Service.Application.V10.Registration.DTO;
using User.Service.Application.V10.Registration.Validators;

namespace User.Service.Application.V10
{
	/// <summary>
	/// Методы расширешения уроdня Application
	/// </summary>
	public static class ApplicationExtension
	{
		/// <summary>
		/// Добавление поддержки Mediatr для текущего проекта
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddMediatrV10Extension(this IServiceCollection services)
		{
			_ = services.AddMediatR(conf =>
				conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			return services;
		}

		/// <summary>
		/// Добавление поддержки валидаторов моделей
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddValidatorV10Extension(this IServiceCollection services)
		{
			services.AddScoped<IValidator<SignUpRequestDTO>, SignUpRequestValidator>();

			return services;
		}
	}
}
