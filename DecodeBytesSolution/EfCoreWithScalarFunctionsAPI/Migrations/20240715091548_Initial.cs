using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreWithScalarFunctionsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION ufn_GetTotalUnitPriceBySalesOfferId(@specialOfferId as int)
                RETURNS DECIMAL(16,2) AS
                BEGIN
                DECLARE @result as decimal(16,2);
                SELECT @result = SUM(Unitprice) FROM Sales.SalesOrderDetail AS SOD
                WHERE SOD.SpecialOfferID = @specialOfferId
                RETURN @result;
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP FUNCTION dbo.ufn_GetTotalUnitPriceBySalesOfferId");
        }
    }
}
