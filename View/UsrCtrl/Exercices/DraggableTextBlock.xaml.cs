﻿using System;
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

namespace Projet.View.UsrCtrl.Exercices
{
    /// <summary>
    /// Logique d'interaction pour DraggableTextBlock.xaml
    /// </summary>
    public partial class DraggableTextBlock : UserControl
    {
        public DraggableTextBlock()
        {
            InitializeComponent();
            txt.DataContext = txt;
        }
    }
}
