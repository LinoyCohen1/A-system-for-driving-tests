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
using System.Collections;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for groupTeacherUserControl1.xaml
    /// </summary>
    public partial class groupTeacherUserControl1 : UserControl
    {
        private IEnumerable source;
        public IEnumerable Source
        {
            get { return source; }
            set
            {
                source = value;
                listView.ItemsSource = source;
            }
        }
        public groupTeacherUserControl1()
        {
            InitializeComponent();
        }
    }
}
