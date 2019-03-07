using Chess.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Chess
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //public Point GetMousePos() => Mouse.GetPosition(ChessBoard);

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var vm = (MainViewModel)this.DataContext;
            vm?.SquareSelect(e.GetPosition(ChessBoard));
        }
    }
}
