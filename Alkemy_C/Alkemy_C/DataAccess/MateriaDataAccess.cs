using Alkemy_C.Models.EF_Models;
using Alkemy_C.Models.Materia;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace Alkemy_C.DataAccess
{
    public static class MateriaDataAccess
    {
        public static listaMaterias Materias() {
            listaMaterias response = new listaMaterias();
            using (var db = new MyDbContext())
            {
                response.Subjects = db.Subject.ToList();
            }
            return response;
        }
        public static Subject getMateria(int Id) {
            Subject response = new Subject();
            using (var db = new MyDbContext())
            {
                response = db.Subject.Include("Schedules").FirstOrDefault(x => x.Id == Id);

            }
            return response;
        }
        public static bool EliminarMateria(int Id) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                db.Subject.Remove(db.Subject.FirstOrDefault(x => x.Id == Id));
                db.SaveChanges();
                retorno = true;
            }
            return retorno;
        }
        public static Subject getMateriaFULL(int Id)
        {
            Subject response = new Subject();
            using (var db = new MyDbContext())
            {
                response = db.Subject.Include("Schedules").Include("Teachers").FirstOrDefault(x => x.Id == Id);

            }
            return response;
        }
        public static IEnumerable<Schedule> getHorarios() {
            IEnumerable<Schedule> response;
            using (var db = new MyDbContext())
            {
                response = db.Schedule.ToList();

            }
            return response;
        }
        public static bool EliminarHorario(int horarioId, int materiaId) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                Subject materia = db.Subject.FirstOrDefault(x => x.Id == materiaId);
                if (materia != null)
                {
                    materia.Schedules.Remove(db.Schedule.FirstOrDefault(x => x.Id == horarioId));
                    db.Entry(materia).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool EditarMateria(EditarMateriaImportModel model) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                Subject materia = db.Subject.FirstOrDefault(x => x.Id == model.idMateria);
                materia.name = model.name;
                materia.places = model.places;
                materia.Teachers.Clear();
                materia.Teachers.Add(db.Teacher.FirstOrDefault(x => x.Id == model.idTeacher));
                db.Entry(materia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                retorno = true;
            }
            return retorno;
        }
        public static bool ExistenciaMateria(string name) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                if (db.Subject.FirstOrDefault(x => x.name == name) == null)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool AgregarMateria(AgregarMateriaImportModel model) {
            using (var db = new MyDbContext())
            {
                Subject newMateria = new Subject() {
                    name = model.name,
                    places = model.places
                };
                db.Subject.Add(newMateria);
                db.SaveChanges();
                foreach (var item in model.SelectedSchedules)
                {
                    Schedule Schedule = db.Schedule.Include("Subjects").FirstOrDefault(x => x.Id == item);
                    Schedule.Subjects.Add(newMateria);
                }
                Teacher teacher = db.Teacher.FirstOrDefault(x => x.Id == model.Teacher);
                teacher.Subjects.Add(newMateria);
                db.SaveChanges();
            }
            return true;
        }
        public static Alumn getAlumno(int Id) {
            Alumn response = new Alumn();
            using (MyDbContext db = new MyDbContext())
            {

                response = db.Alumn.Include("Subjects.Schedules").FirstOrDefault(x => x.Id == Id);

            }


            return response;
        }
        public static bool AlumnoInscrito(int alumnoId,int Id) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                
                retorno = db.Alumn.Include("Subjects").FirstOrDefault(x => x.Id == alumnoId).Subjects.Any(y => y.Id == Id);
            }

            return retorno;
        }

        public static bool Inscribirse(int alumnoId, int materiaId) {
            bool retorno = false;
            using (var db = new MyDbContext())
            {
                
                Subject materia = db.Subject.FirstOrDefault(x => x.Id == materiaId);
                Alumn alumno = db.Alumn.FirstOrDefault(x => x.Id == alumnoId);
                alumno.Subjects.Add(materia);
                materia.Alumns.Add(alumno);
                materia.places = materia.places - 1;
                db.SaveChanges();

            }
            return retorno;
        }
    }
}