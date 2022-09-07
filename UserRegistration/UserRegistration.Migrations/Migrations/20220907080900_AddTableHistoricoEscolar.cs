using FluentMigrator;

namespace UserRegistration.Migrations.Migrations
{
    [Migration(20220907080900, "add table histórico escolar")]
    public class _20220907080900_AddTableHistoricoEscolar : Migration
    {
        private const string TABLE_NAME = "HistoricoEscolar";

        public override void Down()
        {
            Delete.FromTable(TABLE_NAME).AllRows();
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
              .WithColumn("Id").AsInt32().PrimaryKey("pk_historicoEscolar_id").Identity()
              .WithColumn("Formato").AsString(255).NotNullable()
              .WithColumn("Nome").AsString(255).NotNullable();
        }
    }
}