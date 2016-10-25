using System;
using PlayTime.Data.Models;

namespace PlayTime.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<PlayTimeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PlayTime.Data.PlayTimeContext";
        }

        protected override void Seed(PlayTimeContext context)
        {
            context.TaskStatusSet.Add(new TaskStatus { Name = "Indmeldt" });
            context.TaskStatusSet.Add(new TaskStatus { Name = "Afventer DIS/PLAY" });
            context.TaskStatusSet.Add(new TaskStatus { Name = "Afventer kunde" });
            context.TaskStatusSet.Add(new TaskStatus { Name = "Afsluttet" });
        }
    }
}
