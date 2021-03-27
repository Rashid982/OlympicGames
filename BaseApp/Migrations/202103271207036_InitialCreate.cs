namespace BaseApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Score = c.Int(nullable: false),
                        Country_Id = c.Int(),
                        Gender_Id = c.Int(),
                        SportType_Id = c.Int(),
                        Competition_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.SportTypes", t => t.SportType_Id)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id)
                .Index(t => t.Country_Id)
                .Index(t => t.Gender_Id)
                .Index(t => t.SportType_Id)
                .Index(t => t.Competition_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubSportTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender_Id = c.Int(),
                        SportType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.Gender_Id)
                .ForeignKey("dbo.SportTypes", t => t.SportType_Id, cascadeDelete: true)
                .Index(t => t.Gender_Id)
                .Index(t => t.SportType_Id);
            
            CreateTable(
                "dbo.LengthLimites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxLength = c.Double(nullable: false),
                        MinLength = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SportTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WeightLimites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxWeight = c.Double(nullable: false),
                        MinWeight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedalType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFinal = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        SubSportType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubSportTypes", t => t.SubSportType_Id)
                .Index(t => t.SubSportType_Id);
            
            CreateTable(
                "dbo.LengthLimiteSubSportTypes",
                c => new
                    {
                        LengthLimite_Id = c.Int(nullable: false),
                        SubSportType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LengthLimite_Id, t.SubSportType_Id })
                .ForeignKey("dbo.LengthLimites", t => t.LengthLimite_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubSportTypes", t => t.SubSportType_Id, cascadeDelete: true)
                .Index(t => t.LengthLimite_Id)
                .Index(t => t.SubSportType_Id);
            
            CreateTable(
                "dbo.WeightLimiteSubSportTypes",
                c => new
                    {
                        WeightLimite_Id = c.Int(nullable: false),
                        SubSportType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WeightLimite_Id, t.SubSportType_Id })
                .ForeignKey("dbo.WeightLimites", t => t.WeightLimite_Id, cascadeDelete: true)
                .ForeignKey("dbo.SubSportTypes", t => t.SubSportType_Id, cascadeDelete: true)
                .Index(t => t.WeightLimite_Id)
                .Index(t => t.SubSportType_Id);
            
            CreateTable(
                "dbo.MedalAthlets",
                c => new
                    {
                        Medal_Id = c.Int(nullable: false),
                        Athlet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Medal_Id, t.Athlet_Id })
                .ForeignKey("dbo.Medals", t => t.Medal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Athlets", t => t.Athlet_Id, cascadeDelete: true)
                .Index(t => t.Medal_Id)
                .Index(t => t.Athlet_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competitions", "SubSportType_Id", "dbo.SubSportTypes");
            DropForeignKey("dbo.Athlets", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.Athlets", "SportType_Id", "dbo.SportTypes");
            DropForeignKey("dbo.MedalAthlets", "Athlet_Id", "dbo.Athlets");
            DropForeignKey("dbo.MedalAthlets", "Medal_Id", "dbo.Medals");
            DropForeignKey("dbo.WeightLimiteSubSportTypes", "SubSportType_Id", "dbo.SubSportTypes");
            DropForeignKey("dbo.WeightLimiteSubSportTypes", "WeightLimite_Id", "dbo.WeightLimites");
            DropForeignKey("dbo.SubSportTypes", "SportType_Id", "dbo.SportTypes");
            DropForeignKey("dbo.LengthLimiteSubSportTypes", "SubSportType_Id", "dbo.SubSportTypes");
            DropForeignKey("dbo.LengthLimiteSubSportTypes", "LengthLimite_Id", "dbo.LengthLimites");
            DropForeignKey("dbo.SubSportTypes", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Athlets", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Athlets", "Country_Id", "dbo.Countries");
            DropIndex("dbo.MedalAthlets", new[] { "Athlet_Id" });
            DropIndex("dbo.MedalAthlets", new[] { "Medal_Id" });
            DropIndex("dbo.WeightLimiteSubSportTypes", new[] { "SubSportType_Id" });
            DropIndex("dbo.WeightLimiteSubSportTypes", new[] { "WeightLimite_Id" });
            DropIndex("dbo.LengthLimiteSubSportTypes", new[] { "SubSportType_Id" });
            DropIndex("dbo.LengthLimiteSubSportTypes", new[] { "LengthLimite_Id" });
            DropIndex("dbo.Competitions", new[] { "SubSportType_Id" });
            DropIndex("dbo.SubSportTypes", new[] { "SportType_Id" });
            DropIndex("dbo.SubSportTypes", new[] { "Gender_Id" });
            DropIndex("dbo.Athlets", new[] { "Competition_Id" });
            DropIndex("dbo.Athlets", new[] { "SportType_Id" });
            DropIndex("dbo.Athlets", new[] { "Gender_Id" });
            DropIndex("dbo.Athlets", new[] { "Country_Id" });
            DropTable("dbo.MedalAthlets");
            DropTable("dbo.WeightLimiteSubSportTypes");
            DropTable("dbo.LengthLimiteSubSportTypes");
            DropTable("dbo.Competitions");
            DropTable("dbo.Medals");
            DropTable("dbo.WeightLimites");
            DropTable("dbo.SportTypes");
            DropTable("dbo.LengthLimites");
            DropTable("dbo.SubSportTypes");
            DropTable("dbo.Genders");
            DropTable("dbo.Countries");
            DropTable("dbo.Athlets");
        }
    }
}
