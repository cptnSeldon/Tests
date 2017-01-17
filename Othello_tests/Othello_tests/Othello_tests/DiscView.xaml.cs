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

namespace Othello_tests
{
    /// <summary>
    /// Interaction logic for DiscView.xaml
    /// </summary>
    public partial class DiscView : UserControl
    {
        public DiscView()
        {
            InitializeComponent();
        }

        public void SetState(BoardState currentState)
        {
            // BLACK
            if(currentState == BoardState.TAKEN_B)
            {
                Content = Resources["black"] as Image;
            }

            //WHITE
            else if (currentState == BoardState.TAKEN_W)
            {
                Content = Resources["white"] as Image;
            }

            else
            {
                Content = null;
            }
        }
    }
}
