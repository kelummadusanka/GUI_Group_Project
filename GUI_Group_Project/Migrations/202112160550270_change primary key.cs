namespace GUI_Group_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeprimarykey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boughtlottoes",
                c => new
                    {
                        BoughtlottoID = c.Int(nullable: false, identity: true),
                        LotteryID = c.Int(nullable: false),
                        No1 = c.Int(nullable: false),
                        No2 = c.Int(nullable: false),
                        No3 = c.Int(nullable: false),
                        Letter = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BoughtlottoID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IDCard = c.String(),
                        BirthDay = c.String(),
                        Address = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        Zipcode = c.String(),
                        Email = c.String(),
                        Mobile = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Winninglottoes",
                c => new
                    {
                        LotteryID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        No1 = c.Int(nullable: false),
                        No2 = c.Int(nullable: false),
                        No3 = c.Int(nullable: false),
                        Letter = c.String(),
                    })
                .PrimaryKey(t => t.LotteryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Winninglottoes");
            DropTable("dbo.Customers");
            DropTable("dbo.Boughtlottoes");
        }
    }
}
