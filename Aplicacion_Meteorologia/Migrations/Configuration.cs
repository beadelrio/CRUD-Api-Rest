namespace Aplicacion_Meteorologia.Migrations
{
    using Aplicacion_Meteorologia.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Aplicacion_Meteorologia.Models.Aplicacion_MeteorologiaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Aplicacion_Meteorologia.Models.Aplicacion_MeteorologiaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Usuarios.AddOrUpdate(x => x.Id,
                new Usuario() { Id = "beariocalderon", Password = "1234", NombreCompleto = "Beatriz del Rio Calderon", Dni = "12345678A", Localizacion = "3117735", Meteorologia = "Madrid,ES: 5.48 ºC, Min: 4 ºC, Max: 6 ºC" },
                new Usuario() { Id = "juanmartingonzalez", Password = "5678", NombreCompleto = "Juan Martin González", Dni = "987654321B", Localizacion = "2643743", Meteorologia = "London,GB: 2.27 ºC, Min: 1 ºC, Max: 4 ºC" },
                new Usuario() { Id = "josegarcialopez", Password = "123456", NombreCompleto = "José García López", Dni = "123443210C", Localizacion = "2643123", Meteorologia = "Manchester,GB: 2.41 ºC, Min: 1 ºC, Max: 4 ºC" }
            );
        }
    }
}
