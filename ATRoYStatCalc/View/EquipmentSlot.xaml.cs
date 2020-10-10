using ATRoYStatCalc.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATRoYStatCalc.View
{
    /// <summary>
    /// Interaction logic for EquipmentSlot.xaml
    /// </summary>
    public partial class EquipmentSlot : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(EquipmentSlot), new PropertyMetadata(null));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty AvailableStatsProperty = DependencyProperty.Register("AvailableStats", typeof(List<Skill>), typeof(EquipmentSlot), new PropertyMetadata(null));
        public List<Skill> AvailableStats
        {
            get { return (List<Skill>)GetValue(AvailableStatsProperty); }
            set { SetValue(AvailableStatsProperty, value); }
        }

        public static readonly DependencyProperty EquipmentProperty = DependencyProperty.Register("Equipment", typeof(EquipmentPiece), typeof(EquipmentSlot), new PropertyMetadata(null));
        public EquipmentPiece Equipment
        {
            get { return (EquipmentPiece)GetValue(EquipmentProperty); }
            set { SetValue(EquipmentProperty, value); }
        }

        public EquipmentSlot()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
