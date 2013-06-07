using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("academy_User");
            HasKey(x => x.UserId);
            Property(x => x.UserId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("UserId");
            Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("FirstName");
            Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName");
            Property(x => x.University)
                .IsRequired()
                .HasColumnName("University");
            Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");
            Property(x => x.RegistrationDate)
                .IsRequired()
                .HasColumnName("RegistrationDate");
            Property(x => x.LastAccessDate)
                .IsRequired()
                .HasColumnName("LastAccessDate");
            Property(x => x.PhotoFileName)
                .IsOptional()
                .HasColumnName("PhotoFileName");
            HasMany(x => x.Disciplines)
                .WithMany(x => x.Users)
                .Map(x =>
                    {
                        x.ToTable("academy_User_Discipline");
                        x.MapLeftKey("UserId");
                        x.MapRightKey("DisciplineId");
                    });
        }
    }
}
