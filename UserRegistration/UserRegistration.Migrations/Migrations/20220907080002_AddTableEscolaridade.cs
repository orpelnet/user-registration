using FluentMigrator;

namespace UserRegistration.Migrations.Migrations
{
    [Migration(20220907080002, "add table escolaridade")]
    public class _20220907080002_AddTableEscolaridade : Migration
    {
        private const string TABLE_NAME = "Escolaridade";

        public override void Down()
        {
            Delete.FromTable(TABLE_NAME).AllRows();
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
              .WithColumn("Id").AsInt32().PrimaryKey("pk_ecolaridade_id")
              .WithColumn("Descricao").AsString(255).NotNullable();

            Insert.IntoTable(TABLE_NAME).Row(new
            {
                Id = 1,
                Descricao = "Infantil"
            });

            Insert.IntoTable(TABLE_NAME).Row(new
            {
                Id = 2,
                Descricao = "Fundamental"
            });

            Insert.IntoTable(TABLE_NAME).Row(new
            {
                Id = 3,
                Descricao = "Médio"
            });

            Insert.IntoTable(TABLE_NAME).Row(new
            {
                Id = 4,
                Descricao = "Superior"
            });
        }
    }
}