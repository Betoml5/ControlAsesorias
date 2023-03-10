using ControlAsesorias.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlAsesorias.Catalogos
{
    public class AsesoriaCatalogo
    {
        TutoriasContext contenedor = new();
   
        

        public AsesoriaCatalogo()
        {
       
        }

        public IEnumerable<Asesorias> ObtenerAsesorias()
        {
            return contenedor.Asesorias.ToList();
        }

        public IEnumerable<Asesorias> ObtenerAsesoriasPorIdAlumno(int Id)
        {
            return contenedor.Asesorias.Where(x => x.IdTutorado == Id).OrderBy(x => x.Fecha);
        }

        public void CrearAsesoria(Asesorias asesoria)
        {
            contenedor.Asesorias.Add(asesoria);
            contenedor.SaveChanges();
        }

        public void EliminarAsesoria(Asesorias asesoria)
        {
            contenedor.Asesorias.Remove(asesoria);
            contenedor.SaveChanges();
        }

 

    }


}
