using ControlAsesorias.Catalogos;
using ControlAsesorias.Models;
using ControlAsesorias.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlAsesorias.ViewModels
{
    public class AsesoriasViewModel : INotifyPropertyChanged
    {

        AsesoriaCatalogo asesoriasCatalogo = new();
        AlumnoCatalogo alumnosCatalogo = new();

        public Accion Operacion { get; set; }

        public ObservableCollection<Alumnos>? ListaAlumnos { get; set; } = new();
        public ObservableCollection<Asesorias>? ListaAsesorias { get; set; } = new();
        public Alumnos? Alumno { get; set; }
        public Asesorias Asesoria { get; set; }
        
        public ICommand FiltrarAsesoriasCommand { get; set; }

    
        public ICommand VerRegistrarAsesoriaCommand { get; set; }
        public ICommand RegistrarAsesoriaCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand EliminarAsesoriaCommand { get; set; }
        
        




        public AsesoriasViewModel()
        {

            FiltrarAsesoriasCommand = new RelayCommand(FiltrarAsesorias);
            RegistrarAsesoriaCommand = new RelayCommand(RegistrarAsesoria);
            VerRegistrarAsesoriaCommand = new RelayCommand(VerRegistrarAsesoria);

            CargarAlumnos();
           
            Alumno = ListaAlumnos.FirstOrDefault();
            FiltrarAsesorias();
            Operacion = Accion.VerAsesorias;
            PropertyChange();
        }

        private void RegistrarAsesoria()
        {
            Asesoria.IdTutorado = Alumno.Id;
            asesoriasCatalogo.CrearAsesoria(Asesoria);
            Operacion = Accion.VerAsesorias;
            PropertyChange();
            ActualizarDB();
        }

        private void CargarAlumnos()
        {
            if (ListaAlumnos != null)
            {
                foreach (var item in alumnosCatalogo.ObtenerAlumnos())
                {
                    ListaAlumnos.Add(item);
                }
            }
            
        }

        public void FiltrarAsesorias()
        {
            if (ListaAsesorias != null)
            {
                ListaAsesorias.Clear();

                if (Alumno != null)
                {
                    var asesorias = asesoriasCatalogo.ObtenerAsesoriasPorIdAlumno(Alumno.Id);

                    foreach (var item in asesorias)
                    {
                        ListaAsesorias.Add(item);
                    }
                }
            }
        }


        public void VerRegistrarAsesoria()
        {

            Asesoria = new();
            Operacion = Accion.AgregarAsesorias;
            PropertyChange();   
        }


        public void ActualizarDB()
        {
            ListaAsesorias?.Clear();

            foreach (var item in asesoriasCatalogo.ObtenerAsesorias())
            {
                ListaAsesorias?.Add(item);
            }

            PropertyChange();
        }
        void PropertyChange(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
