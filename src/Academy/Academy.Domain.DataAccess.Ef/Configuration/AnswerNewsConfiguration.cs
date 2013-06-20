﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Academy.Domain.Objects;

namespace Academy.Domain.DataAccess.Ef.Configuration
{
    internal class AnswerNewsConfiguration : EntityTypeConfiguration<AnswerNews>
    {
        public AnswerNewsConfiguration()
        {
            ToTable("academy_AnswerNews");
            HasKey(x => x.AnswerNewsId);
            Property(x => x.AnswerNewsId)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read");
            HasRequired(x => x.User)
                .WithMany(x => x.AnswerNewses)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Answer)
                .WithMany(x => x.AnswerNewses)
                .HasForeignKey(x => x.AnswerId)
                .WillCascadeOnDelete(false);
        }
    }
}