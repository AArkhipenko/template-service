using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.ComponentModel.DataAnnotations;
using User.Service.Domain.Core.Exceptions;
using User.Service.Domain.Interface.Repositories;
using User.Service.Infrastructure.EF.Tables;

using RepoExt = User.Service.Infrastructure.EF.Repositories;
using DomainExt = User.Service.Domain.Interface.Models;

namespace User.Service.Infrastructure.EF.Tests.Repositories.PublicRepository
{
	/// <summary>
	/// Тесты на <see cref="IUserRepository.SimpleCreateUserAsync(string, string)"/>
	/// </summary>
	public class SimpleCreateUserAsyncTests
	{
		private readonly GeneralDbContext _context;
		private readonly IUserRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="SimpleCreateUserAsyncTests"/> class.
		/// </summary>
		public SimpleCreateUserAsyncTests()
		{
			this._context = SimpleCreateUserAsyncTests.ConfigureContext();

			var publicRepositoryMock = new Mock<IPublicRepository>();
			publicRepositoryMock
				.Setup(x => x.FindCategoryByCodeAsync(It.IsAny<string>()))
				.ReturnsAsync(new DomainExt.Category(1, "Category"));

			this._repository = new RepoExt.UserRepository(this._context, publicRepositoryMock.Object);
		}

		/// <summary>
		/// Создание пользователя прошло успешно
		/// </summary>
		[Fact]
		public async void It_should_create_User()
		{
			// Arrange
			var email = "null@null.null";
			var password = "password";

			// Act
			var userId = await this._repository.SimpleCreateUserAsync(email, password);

			// Assert
			Assert.True(userId > 0);

			var user = await this._context.Users.FirstOrDefaultAsync(x => x.Id == userId);
			Assert.NotNull(user);
			Assert.Equal($"{email}User", user.Code);
			Assert.Equal(string.Empty, user.Name);
			Assert.Equal(email, user.Email);
			Assert.Equal(password, user.Password);
		}

		/// <summary>
		/// Конфигурирование контекста БД
		/// </summary>
		/// <returns><see cref="GeneralDbContext"/></returns>
		private static GeneralDbContext ConfigureContext()
		{
			var fixture = new Fixture();
			var options = new DbContextOptionsBuilder<GeneralDbContext>()
					  .UseInMemoryDatabase(Guid.NewGuid().ToString())
					  .Options;
			var context = new GeneralDbContext(options);

			return context;
		}
	}
}
