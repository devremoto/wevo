using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EF.Mappings
{
    public class PersonMap: IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

			builder.HasKey(x => x.Id);
            builder.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(t => t.Nome).HasColumnName("NOME");
            builder.Property(t => t.CPF).HasColumnName("CPF");
            builder.Property(t => t.Email).HasColumnName("EMAIL");
            builder.Property(t => t.Telefone).HasColumnName("TELEFONE");
            builder.Property(t => t.DataNascimento).HasColumnName("DATA_NASCIMENTO");
			builder.ToTable("TB_PERSON");   
        }
    }
}

