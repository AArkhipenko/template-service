using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Configs
{
	/// <summary>
	/// Класс для конифгурирования <see cref="TableExt.Category"/> 
	/// </summary>
	internal class CategoryConfig : IEntityTypeConfiguration<TableExt.Category>
	{
		/// <summary>
		/// Конифгурирования <see cref="TableExt.Base"/> 
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		public void Configure(EntityTypeBuilder<TableExt.Category> builder)
		{
			builder.ToTable("category", "public");

			builder
				.Property<int>(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(x => x.Code)
				.HasColumnName("code")
				.IsRequired();

			builder
				.Property<string>(x => x.Name)
				.HasColumnName("name")
				.IsRequired();

			builder
				.Property<DateTime>(x => x.Created)
				.HasColumnName("created")
				.IsRequired();

			builder
				.Property<DateTime>(x => x.Edited)
				.HasColumnName("edited")
				.IsRequired();
		}
	}
}
