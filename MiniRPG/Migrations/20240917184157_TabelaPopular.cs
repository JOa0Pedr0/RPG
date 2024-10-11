using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniRPG.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPopular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Players", new string[] {"ContadorDeBatalhas","Gold","Xp","Nome","Lvl","Dmg","Def","Health","Classe"}, new object[] {4,200.34,50,"Killerbrhu3",46,400,300,500,"Mago"});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Players");
        }
    }
}
