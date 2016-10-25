namespace PlayTime.Data
{
    using System.Data.Entity;

    using PlayTime.Data.Migrations;

    public class PlayTimeInitializer : MigrateDatabaseToLatestVersion<PlayTimeContext, Configuration>
    {
        
    }
}