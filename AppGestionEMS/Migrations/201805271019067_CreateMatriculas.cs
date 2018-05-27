namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        GrupoClaseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Grupo_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.Grupo_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CursoId)
                .Index(t => t.Grupo_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "Grupo_Id", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "User_Id" });
            DropIndex("dbo.Matriculas", new[] { "Grupo_Id" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropTable("dbo.Matriculas");
        }
    }
}
