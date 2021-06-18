using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    ArtistName = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });


            migrationBuilder.InsertData(
               table: "Albums",
               columns: new[] { "Id", "Title", "ArtistName", "Rating" },
               values: new object[,]
               {
                    { 1, "Fade To Black","Metallica",2 },
                    { 2, "Master Of Puppets","Metallica",2 },
                    { 3, "Stairway To Heaven","Led Zeppelin",2 },
                    { 4, "Sweet Child O' Mine","Gun N' Roses",2 },
                    { 5,"Nothing Else Matters","Metllica",3},
                    { 6,"Back In Back","AC/DC",4},
                    { 7,"Hotel Clifornia","The Eagles",5},
                    { 8,"Enter Sandman","Metallica",1},
                    { 9,"Californication","The Eagles",2},
                    { 10,"Smells Like Ten Spirit", "Nirvana",3},
                    { 11,"One","Metllica",2},
                    { 12,"Tornado of Souls", "Megadeth",2},
                    { 13,"Crazy Train", "Ozzy Osbourne",3},
                    { 14,"For Whom The Bell Tolls", "Metallica",2},
                    { 15,"Sultans Of Swing","Dire Straits",1},
                    { 16,"Can't Stop","Red Hot Chili pepers",2},
                    { 17,"Killing In The Name", "Rage Against The Machine",2},
                    { 18,"Paranoid", "Black Sabbath",3}
               });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
          name: "Albums");

        }
    }
}
