using Alkemy_C.Models;
using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Profesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alkemy_C.DataAccess
{
    public static class ProfesorDataAccess
    {
        public static listaProfesores Profesores() {
            listaProfesores response = new listaProfesores();
            using (MyDbContext db = new MyDbContext())
            {
                response.Teachers = db.Teacher.ToList();
            }
 
            return response;
        }
        public static ResponseGeneric ModificarProfesor(Teacher model) {
            ResponseGeneric response = new ResponseGeneric();
            using (MyDbContext db = new MyDbContext())
            {
                Teacher teacher = db.Teacher.FirstOrDefault(x => x.Id == model.Id);
                teacher.Ci = model.Ci;
                teacher.name = model.name;
                teacher.last_name = model.last_name;
                db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                response.status = true;
            }
 
            return response;
        }
        public static Teacher getProfesor(int Id) {
            Teacher response = new Teacher();
            using (MyDbContext db = new MyDbContext())
            {
                response = db.Teacher.Include("Subjects").FirstOrDefault(x => x.Id == Id);
            }
 
            return response;
        }
        public static ResponseGeneric EliminarProfesor(int Id) {
            ResponseGeneric response = new ResponseGeneric();
            response.status = false;
            try
            {
                using (MyDbContext db = new MyDbContext())
                {
                    db.Teacher.Remove(db.Teacher.FirstOrDefault(x => x.Id == Id));
                    db.SaveChanges();
                    response.status = true;
                }
            }
            catch (Exception ex)
            {
            }

            return response;
        }
        public static ResponseGeneric CrearProfesor(CrearProfesorImportModel model) {
            ResponseGeneric response = new ResponseGeneric();
            response.status = false;
            using (MyDbContext db = new MyDbContext())
            {
                Teacher teacher = new Teacher()
                {
                    Ci = model.ci,
                    name = model.name,
                    last_name = model.last_name,
                    active = "no"
                };
                db.Teacher.Add(teacher);
                db.SaveChanges();
                response.status = true;
            }
 
            return response;
        }
        public static Person getPerson(int Ci) {
            Person response = new Person();
            using (MyDbContext db = new MyDbContext())
            {
                response = db.Person.FirstOrDefault(x => x.Ci == Ci);
            }
 
            return response;
        }
    }
}