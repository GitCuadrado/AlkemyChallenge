namespace Alkemy_C.Migrations
{
 
    using System;
    using Alkemy_C.Models.EF_Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
  

    internal sealed class Configuration : DbMigrationsConfiguration<Alkemy_C.Models.EF_Models.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Alkemy_C.Models.EF_Models.MyDbContext context)
        {
            //context.Person.Add(new Person { Ci = 54520666, name = "AAAA", last_name = "BBBB", Id = 1 });

            //context.Teacher.Add(new Teacher { Ci = 54520660, name = "Juan", last_name = "Martinez", Id = 1, active = "no" });
            //context.Teacher.Add(new Teacher { Ci = 54520661, name = "Pepe", last_name = "Argento", Id = 2, active = "no" });

            //context.Admin.Add(new Admin { Ci = 54520661, name = "Don", last_name = "Gato", Id = 6 });

            //context.Alumn.Add(new Alumn { Ci = 54520662, name = "Agustin", last_name = "Cuadrado", Id = 3 });
            //context.Alumn.Add(new Alumn { Ci = 54520663, name = "Nahuel", last_name = "Gramajo", Id = 4 });
            //context.Alumn.Add(new Alumn { Ci = 54520664, name = "Luciano", last_name = "Ñoqui", Id = 5 });

            //context.Schedule.Add(new Schedule { day = "Lunes", hr_start = new DateTime(2020, 1, 1, 14, 0, 0), hr_end = new DateTime(2020, 1, 1, 16, 0, 0), Id = 1 });
            //context.Schedule.Add(new Schedule { day = "Martes", hr_start = new DateTime(2020, 1, 1, 14, 0, 0), hr_end = new DateTime(2020, 1, 1, 16, 0, 0), Id = 2 });
            //context.Schedule.Add(new Schedule { day = "Miercoles", hr_start = new DateTime(2020, 1, 1, 14, 0, 0), hr_end = new DateTime(2020, 1, 1, 16, 0, 0), Id = 3 });
            //context.Schedule.Add(new Schedule { day = "Jueves", hr_start = new DateTime(2020, 1, 1, 14, 0, 0), hr_end = new DateTime(2020, 1, 1, 16, 0, 0), Id = 4 });
            //context.Schedule.Add(new Schedule { day = "Viernes", hr_start = new DateTime(2020, 1, 1, 14, 0, 0), hr_end = new DateTime(2020, 1, 1, 16, 0, 0), Id = 5 });

            //context.Subject.Add(new Subject { Id = 1, name = "Matematica", places = 40});
            //context.Subject.Add(new Subject { Id = 2, name = "Programacion II", places = 35 });
            //context.Subject.Add(new Subject { Id = 3, name = "Logica", places = 30 });
            //context.Subject.Add(new Subject { Id = 4, name = "Redes", places = 20 });

            //context.Subject.FirstOrDefault(x => x.Id == 1).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 1));
            //context.Subject.FirstOrDefault(x => x.Id == 1).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 2));
            //context.Subject.FirstOrDefault(x => x.Id == 2).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 3));
            //context.Subject.FirstOrDefault(x => x.Id == 2).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 4));
            //context.Subject.FirstOrDefault(x => x.Id == 3).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 5));
            //context.Subject.FirstOrDefault(x => x.Id == 3).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 4));
            //context.Subject.FirstOrDefault(x => x.Id == 4).Schedules.Add(context.Schedule.FirstOrDefault(x => x.Id == 2));

            //context.Schedule.FirstOrDefault(x => x.Id == 1).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 1));
            //context.Schedule.FirstOrDefault(x => x.Id == 2).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 1));
            //context.Schedule.FirstOrDefault(x => x.Id == 3).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 2));
            //context.Schedule.FirstOrDefault(x => x.Id == 4).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 2));
            //context.Schedule.FirstOrDefault(x => x.Id == 5).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 3));
            //context.Schedule.FirstOrDefault(x => x.Id == 4).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 3));
            //context.Schedule.FirstOrDefault(x => x.Id == 2).Subjects.Add(context.Subject.FirstOrDefault(x => x.Id == 4));
            //context.SaveChanges();
        }
    }
}
