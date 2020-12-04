using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.ViewModel
{
    public class Block : INotifyPropertyChanged
    {
        public byte X { get; set; }
        public byte Y { get; set; }
        byte number;

        public event PropertyChangedEventHandler PropertyChanged;

        public byte Number
        {
            get => number;
            set
            {
                number = value;
                if (value == 0)
                {
                    Visible = false;
                }
                NotifyPropertyChanged();
            }
        }
        public bool Visible { get; set; } = true;
        public static Block operator +(Block left, Block right)
        {
            if (left != null && right != null)
            {
                if (left.Visible && right.Visible)
                {
                    if (left.Number == right.Number)
                    {
                        left.Number += right.Number;
                        right.Visible = false;
                        right.Number = 0;
                    }
                }
            }
            return left;
        }
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
