using System.Windows;

namespace Chess.Model
{
    public class Sqare : RaisePropertyChangedBase
    {
        private Point pos;
        public Point Pos
        {
            get => pos;
            set { pos = value; RaisePropertyChanged(); }
        }
    }
}
