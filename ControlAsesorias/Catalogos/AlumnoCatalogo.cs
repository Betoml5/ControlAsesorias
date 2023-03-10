using ControlAsesorias.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsesorias.Catalogos
{
    public class AlumnoCatalogo
    {

        TutoriasContext contenedor = new TutoriasContext();

        public IEnumerable<Alumnos> ObtenerAlumnos()
        {
            return contenedor.Alumnos.OrderBy(alumno => alumno.Nombre);
        }

        public Alumnos ObtenerAlumno(int Id)
        {
           return contenedor.Alumnos.Where(alumno => alumno.Id == Id).FirstOrDefault();   
        }
        public void AgregarAlumno(Alumnos alumno)
        {
            contenedor.Database.ExecuteSqlRaw($"EXEC spRegistrarAlumno @nombre='{alumno.Nombre}', @numeroControl='{alumno.NumeroControl}', @promedio='{alumno.Promedio}'");
            contenedor.SaveChanges();
        }
        public void EditarAlumno(Alumnos alumno)
        {
            contenedor.Entry(alumno).State = EntityState.Modified;
            contenedor.SaveChanges();
        }

        public void EliminarAlumno(Alumnos alumno)
        {
            contenedor.Alumnos.Remove(alumno);
            contenedor.SaveChanges();
        }

    }
}
