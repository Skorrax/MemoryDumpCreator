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
using MemoryLogic.Logic;

namespace MemoryDumpCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MemoryBL memBL;
        public MainWindow()
        {
            InitializeComponent();
            memBL = new MemoryBL();
        }

        private void BtnCreateDump_Click(object sender, RoutedEventArgs e)
        {
            if(txtProcessName.Text.Length > 0)
            memBL.GetMemoryDump(txtProcessName.Text);
            else if(txtProcessId.Text.Length > 0)
            {
                int id;
                if(Int32.TryParse(txtProcessId.Text, out id))
                {
                    memBL.GetMemoryDump(id);
                }

            }
            txtProcessName.Clear();
        }
    }
}
