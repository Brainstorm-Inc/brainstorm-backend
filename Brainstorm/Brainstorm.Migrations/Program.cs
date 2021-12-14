using Booking.Migrations;
using Microsoft.EntityFrameworkCore;

var ctx = new DesignTimeContextFactory().CreateDbContext(args);
ctx.Database.Migrate();