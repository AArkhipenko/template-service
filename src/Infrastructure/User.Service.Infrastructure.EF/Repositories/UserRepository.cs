using User.Service.Domain.Interface.Repositories;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Repositories
{
	/// <summary>
	/// Реализация <see cref="IUserRepository"/>
	/// </summary>
    internal class UserRepository : IUserRepository
    {
		private readonly GeneralDbContext _context;
		private readonly IPublicRepository _publicRepository;

		private const string UserCategoryCode = "UserCategory";

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="GeneralDbContext"/></param>
		/// <param name="publicRepository"><see cref="IPublicRepository"/></param>
		public UserRepository(
			GeneralDbContext context,
			IPublicRepository publicRepository)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._publicRepository = publicRepository ?? throw new ArgumentNullException(nameof(publicRepository));
		}

		/// <inheritdoc/>
		public async Task SimpleCreateUserAsync(string email, string password)
		{
			var category = await this._publicRepository.FindCategoryByCodeAsync(UserCategoryCode);

			var model = new TableExt.User
			{
				IdCategory = category.Id,
				Code = $"{email}User",
				Name = string.Empty,
				Email = email,
				Password = password
			};

			await this._context.Users.AddAsync(model);
			await this._context.SaveChangesAsync();
		}
	}
}
