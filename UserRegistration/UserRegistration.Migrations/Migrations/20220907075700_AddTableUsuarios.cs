using FluentMigrator;

namespace UserRegistration.Migrations.Migrations
{
    [Migration(20220907075700, "add table usuarios")]
    public class _20220907075700_AddTableUsuarios : Migration
    {
        private const string TABLE_NAME = "Usuarios";

        public override void Down()
        {
            Delete.FromTable(TABLE_NAME).AllRows();
            Delete.Table(TABLE_NAME);
        }

        public override void Up()
        {
            Create.Table(TABLE_NAME)
              .WithColumn("Id").AsInt32().PrimaryKey("pk_usuario_id").Identity()
              .WithColumn("Nome").AsString(255).NotNullable()
              .WithColumn("Sobrenome").AsString(255).NotNullable()
              .WithColumn("Email").AsString(255).NotNullable()
              .WithColumn("DataNascimento").AsDateTime().NotNullable()
              .WithColumn("EscolaridadeId").AsInt32().ForeignKey("Fk_Usuario_Escolaridade", "Usuarios", "Id")
              .WithColumn("HistoricoEscolarId").AsInt32().ForeignKey("Fk_Usuario_HistoricoEscolar", "Usuarios", "Id");
        }
    }
}