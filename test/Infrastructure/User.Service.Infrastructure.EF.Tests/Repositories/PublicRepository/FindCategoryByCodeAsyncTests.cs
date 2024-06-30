using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using User.Service.Domain.Core.Exceptions;
using User.Service.Domain.Interface.Repositories;
using User.Service.Infrastructure.EF.Tables;

using RepoExt = User.Service.Infrastructure.EF.Repositories;

namespace User.Service.Infrastructure.EF.Tests.Repositories.PublicRepository
{
	/// <summary>
	/// Тесты на <see cref="IPublicRepository.FindCategoryByCodeAsync(string)"/>
	/// </summary>
	public class FindCategoryByCodeAsyncTests
    {
		private readonly IPublicRepository _repository;
		private const string CorrectCode = "CorrectCode";
		private const string InCorrectCode = "InCorrectCode";

		/// <summary>
		/// Initializes a new instance of the <see cref="FindCategoryByCodeAsyncTests"/> class.
		/// </summary>
		public FindCategoryByCodeAsyncTests()
		{
			var context = FindCategoryByCodeAsyncTests.ConfigureContext();
			_repository = new RepoExt.PublicRepository(context);
		}

		/// <summary>
		/// На входе метода корретный код категории
		/// Возвращается модель категории
		/// </summary>
		[Fact]
		public async void It_should_return_Category()
		{
			// Arrange
			// Act
			var response = await this._repository.FindCategoryByCodeAsync(CorrectCode);

			// Assert
			Assert.NotNull(response);
			Assert.True(response.Id > 0);
			Assert.Equal(CorrectCode, response.Code);
		}

		/// <summary>
		/// На входе метода некорретный код категории
		/// Выбрасывается исключение NotFoundException
		/// </summary>
		[Fact]
		public async void It_should_throw_NotFoundException()
		{
			// Arrange
			// Act
			// Assert
			await Assert.ThrowsAsync<NotFoundException>(() => this._repository.FindCategoryByCodeAsync(InCorrectCode));
		}

		/// <summary>
		/// Конфигурирование контекста БД
		/// </summary>
		/// <returns><see cref="PublicDbContext"/></returns>
		private static PublicDbContext ConfigureContext()
		{
			var fixture = new Fixture();
			var options = new DbContextOptionsBuilder<PublicDbContext>()
					  .UseInMemoryDatabase(Guid.NewGuid().ToString())
					  .Options;
			var context = new PublicDbContext(options);

			context.Categories.Add(
				fixture
				.Build<Category>()
				.With(x => x.Code, CorrectCode)
				.Create());
			context.SaveChanges();

			return context;
		}
	}
}
