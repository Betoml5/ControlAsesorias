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
    public  class AlumnosViewModel:INotifyPropertyChanged
    {

        
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Alumnos> Alumnos { get; set; } = new ObservableCollection<Alumnos>();

        public List<string> Errores { get; set; } = new();

        AlumnoCatalogo catalogo = new();
        private Accion operacion = Accion.VerTutorados;

        public Alumnos Alumno { get; set; }


        public Accion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }


        public ICommand VerRegistrarAlumnoCommand { get; set; }
        public ICommand RegistrarAlumnoCommand { get; set; }
        public ICommand EditarAlumnoCommand { get; set; }
        public ICommand VerEditarAlumnoCommand { get; set; }
        public ICommand EliminarAlumnoCommand { get; set; }
        public ICommand VerAlumnosCommand { get; set; }
        public ICommand VerEliminarAlumnoCommand { get; set; }
        public ICommand RegresarCommand { get; set; }


        public AlumnosViewModel()
        {

            VerRegistrarAlumnoCommand = new RelayCommand(VerRegistrarAlumno);
            RegistrarAlumnoCommand = new RelayCommand(RegistrarAlumno);
            EditarAlumnoCommand = new RelayCommand<int>(EditarAlumno);
            VerEditarAlumnoCommand = new RelayCommand<int>(VerEditarAlumno);
            EliminarAlumnoCommand = new RelayCommand(EliminarAlumno);
            VerAlumnosCommand = new RelayCommand(VerAlumnos);
            VerEliminarAlumnoCommand = new RelayCommand<int>(VerEliminar);
            RegresarCommand = new RelayCommand(Regresar);



            var alumnos = catalogo.ObtenerAlumnos();
            foreach (var alumno in alumnos)
            {
                Alumnos.Add(alumno);
            }
        }



        public void VerRegistrarAlumno()
        {
            Alumno = new();
            Operacion = Accion.AgregarTutorados;
            PropertyChange();
        }

        public void RegistrarAlumno()
        {
            catalogo.AgregarAlumno(Alumno);
            Operacion = Accion.VerTutorados;
            PropertyChange();
            ActualizarDB();
        }

        public void EditarAlumno(int Id)
        {
            Operacion = Accion.EditarTutorados;
            PropertyChange();
        }

        public void VerEditarAlumno(int Id)
        {

            Operacion = Accion.EditarTutorados;
            PropertyChange();
        }

        public void EliminarAlumno()
        {

            if (Alumno != null)
            {
                catalogo.EliminarAlumno(Alumno);
                ActualizarDB();
            }
            Operacion = Accion.VerTutorados;
            PropertyChange();
        }

        public void VerAlumnos()
        {
            Operacion = Accion.VerTutorados;
            PropertyChange();
        }

        public void VerEliminar(int Id)
        {
            Operacion = Accion.EliminarTutorados;
            Alumno = catalogo.ObtenerAlumno(Id);
            PropertyChange();
        }

        public void Regresar()
        {
            Operacion = Accion.VerTutorados;
            PropertyChange();
        }

        public void ActualizarDB()
        {
            Alumnos.Clear();

            foreach (var item in catalogo.ObtenerAlumnos())
            {
                Alumnos.Add(item);
            }

            PropertyChange();
        }
        // create a method to invoce propertyChanged

        void PropertyChange(string? prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
