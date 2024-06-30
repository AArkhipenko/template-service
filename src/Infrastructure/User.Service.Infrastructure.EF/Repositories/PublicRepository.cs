using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using User.Service.Domain.Core.Exceptions;
using User.Service.Domain.Interface.Models;
using User.Service.Domain.Interface.Repositories;

using TableExt = User.Service.Infrastructure.EF.Tables;
using DomainExt = User.Service.Domain.Interface.Models;

namespace User.Service.Infrastructure.EF.Repositories
{
	/// <summary>
	/// Реализация <see cref="IUserRepository"/>
	/// </summary>
    internal class PublicRepository : IPublicRepository
    {
		private readonly PublicDbContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="PublicRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="GeneralDbContext"/></param>
		public PublicRepository(
			PublicDbContext context)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
		}

		/// <inheritdoc/>
		public async Task<DomainExt.Category> FindCategoryByCodeAsync(string code)
		{
			var model = await this._context.Categories.FirstOrDefaultAsync(x => x.Code == code);

			if (model == null)
			{
				throw new NotFoundException($"Не найдена категория с кодом '{code}'");
			}

			return new DomainExt.Category(model.Id, model.Code );
		}
	}
}
