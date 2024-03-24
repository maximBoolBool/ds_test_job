using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WeatherEntities.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    uploaddate = table.Column<DateTime>(name: "upload_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "days",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    timeonly = table.Column<TimeOnly>(name: "time_only", type: "time without time zone", nullable: false),
                    temperature = table.Column<double>(type: "double precision", nullable: false),
                    relativehumidity = table.Column<double>(name: "relative_humidity", type: "double precision", nullable: false),
                    dewpointtemperature = table.Column<double>(name: "dew_point_temperature", type: "double precision", nullable: false),
                    pressureofmercurycolumn = table.Column<int>(name: "pressure_of_mercury_column", type: "integer", nullable: false),
                    winddirection = table.Column<int>(name: "wind_direction", type: "integer", nullable: false),
                    windspeed = table.Column<short>(name: "wind_speed", type: "smallint", nullable: false),
                    vvwindassessment = table.Column<int>(name: "vv_wind_assessment", type: "integer", nullable: false),
                    cloudcover = table.Column<short>(name: "cloud_cover", type: "smallint", nullable: false),
                    height = table.Column<int>(type: "integer", nullable: false),
                    visibilityvariable = table.Column<short>(name: "visibility_variable", type: "smallint", nullable: false),
                    weatherphenomena = table.Column<string>(name: "weather_phenomena", type: "text", nullable: true),
                    fileid = table.Column<long>(name: "file_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_days", x => x.id);
                    table.ForeignKey(
                        name: "FK_days_files_file_id",
                        column: x => x.fileid,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_days_file_id",
                table: "days",
                column: "file_id");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherTrackEntity_Field1_Field2",
                table: "days",
                columns: new[] { "date", "time_only" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_files_name",
                table: "files",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "days");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
