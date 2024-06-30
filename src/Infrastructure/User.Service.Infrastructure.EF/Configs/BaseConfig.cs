using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TableExt = User.Service.Infrastructure.EF.Tables;

namespace User.Service.Infrastructure.EF.Configs
{
	/// <summary>
	/// Класс для конифгурирования <see cref="TableExt.Base"/> 
	/// </summary>
	internal class BaseConfig : IEntityTypeConfiguration<TableExt.Base>
	{
		/// <summary>
		/// Конифгурирования <see cref="TableExt.Base"/> 
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		public void Configure(EntityTypeBuilder<TableExt.Base> builder)
		{
			builder.ToTable("base", "public");

			builder
				.Property<int>(x => x.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<int>(x => x.IdCategory)
				.HasColumnName("id_category")
				.IsRequired();

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
