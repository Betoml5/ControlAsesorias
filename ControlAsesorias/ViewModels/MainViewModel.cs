using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlAsesorias.ViewModels
{
    public class MainViewModel:INotifyPropertyChanged
    {
        AlumnosViewModel alumnosViewModel = new();
        AsesoriasViewModel asesoriasViewModel = new();
        public event PropertyChangedEventHandler? PropertyChanged;
        private object vwActual;

        public object ViewModelActual
        {
            get { return vwActual; }
            set {
                vwActual = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public ICommand NavegarAsesoriasCommand { get; set; }
        public ICommand NavegarAlumnosCommand { get; set; }
        public MainViewModel()
        {
            NavegarAsesoriasCommand = new RelayCommand(NavegarAsesorias);
            NavegarAlumnosCommand = new RelayCommand(NavegarAlumnos);
            ViewModelActual = alumnosViewModel;
        }

        private void NavegarAsesorias()
        {
            ViewModelActual = asesoriasViewModel;
        }

        private void NavegarAlumnos()
        {
            ViewModelActual = alumnosViewModel;
        }

      
    }
}
