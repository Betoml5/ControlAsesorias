﻿using ControlAsesorias.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlAsesorias.Views.AsesoriasView
{
    /// <summary>
    /// Lógica de interacción para AsesoriasView.xaml
    /// </summary>
    public partial class AsesoriasView : UserControl
    {
        public AsesoriasView()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vw = this.DataContext as AsesoriasViewModel;
            if (vw != null)
            {
                vw.FiltrarAsesoriasCommand.Execute(null);

            }
        }
    }
}
