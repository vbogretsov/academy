using System;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class QuestionConfiguration : TitledPostConfiguration<Question>
    {
        public QuestionConfiguration()
            : base("academy_Question", "QuestionId")
        {
            HasRequired(x => x.User)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasMany(x => x.Disciplines)
                .WithMany(x => x.Questions)
                .Map(x =>
                    {
                        x.ToTable("academy_Discipline_Question");
                        x.MapLeftKey("QuestionId");
                        x.MapRightKey("DisciplineId");
                    });
        }
    }
}
