namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAsignacionDocentes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        GrupoClaseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoClaseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CursoId)
                .Index(t => t.GrupoClaseId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AsignacionDocentes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoClaseId", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursos");
            DropIndex("dbo.AsignacionDocentes", new[] { "User_Id" });
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoClaseId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "CursoId" });
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
