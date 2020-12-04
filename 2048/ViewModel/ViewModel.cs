using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048.Commands;

namespace _2048.ViewModel
{
    public class ViewModel
    {
        public ObservableCollection<ObservableCollection<Block>> VisibleBlocks { get; set; } = new ObservableCollection<ObservableCollection<Block>>();
        public List<Block> Blocks { get; set; } = new List<Block>(16);
        bool ValueChanged = false;
        public ViewModel()
        {
            VisibleBlocks.Add(new ObservableCollection<Block>());
            VisibleBlocks.Add(new ObservableCollection<Block>());
            VisibleBlocks.Add(new ObservableCollection<Block>());
            VisibleBlocks.Add(new ObservableCollection<Block>());
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    VisibleBlocks[x].Add(new Block());
                }
            Blocks.AddRange(VisibleBlocks[x]);
            }
            RandomBlock();
            RandomBlock();
        }
        Random rnd = new Random();
        private void RandomBlock()
        {
            Block tmp = VisibleBlocks[rnd.Next(4)][rnd.Next(4)];
            tmp.Number = Convert.ToByte(rnd.Next(1,2)*2);
            tmp.Visible = true;
            Blocks.Remove(tmp);
            ValueChanged = false;
        }
        public void MoveLeft()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (!VisibleBlocks[x][y].Visible)
                    {
                        continue;
                    }
                    for (int i = x + 1; i < 4; i++)
                    {
                        if (VisibleBlocks[i][y].Visible)
                        {
                            ValueChanged = true;
                            VisibleBlocks[x][y] += VisibleBlocks[i][y];
                            x = i;
                        }
                    }
                }
            }
            byte counter = 0;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (VisibleBlocks[x][y].Visible)
                    {
                        if (counter != x)
                        {
                            VisibleBlocks[counter][y].Number = VisibleBlocks[x][y].Number;
                            VisibleBlocks[x][y].Number = 0;
                            VisibleBlocks[x][y].Visible = false;
                            Blocks.Add(VisibleBlocks[x][y]);
                            VisibleBlocks[counter][y].Visible = true;
                            ValueChanged = true;
                        }
                        counter++;
                    }
                }
                counter = 0;
            }
            if (ValueChanged)
            {
                RandomBlock();
            }
        }
        public void MoveRight()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (!VisibleBlocks[x][y].Visible)
                    {
                        continue;
                    }
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (VisibleBlocks[i][y].Visible)
                        {
                            ValueChanged = true;
                            VisibleBlocks[x][y] += VisibleBlocks[i][y];
                            x = i;
                        }
                    }
                }
            }
            byte counter = 3;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 3; x >= 0; x--)
                {
                    if (VisibleBlocks[x][y].Visible)
                    {
                        if (counter != x)
                        {
                            VisibleBlocks[counter][y].Number = VisibleBlocks[x][y].Number;
                            VisibleBlocks[x][y].Number = 0;
                            VisibleBlocks[x][y].Visible = false;
                            Blocks.Add(VisibleBlocks[x][y]);
                            VisibleBlocks[counter][y].Visible = true;
                            ValueChanged = true;
                        }
                        counter--;
                    }
                }
                counter = 3;
            }
            if (ValueChanged)
            {
                RandomBlock();
            }
        }
        public void MoveUp()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (!VisibleBlocks[x][y].Visible)
                    {
                        continue;
                    }
                    for (int i = y + 1; i < 4; i++)
                    {
                        if (VisibleBlocks[x][y].Visible)
                        {
                            ValueChanged = true;
                            VisibleBlocks[x][y] += VisibleBlocks[x][i];
                            y = i;
                        }
                    }
                }
            }
            byte counter = 0;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (VisibleBlocks[x][y].Visible)
                    {
                        if (counter != y)
                        {
                            VisibleBlocks[x][counter].Number = VisibleBlocks[x][y].Number;
                            VisibleBlocks[x][y].Number = 0;
                            VisibleBlocks[x][y].Visible = false;
                            Blocks.Add(VisibleBlocks[x][y]);
                            VisibleBlocks[x][counter].Visible = true;
                            ValueChanged = true;
                        }
                        counter++;
                    }
                }
                counter = 0;
            }
            if (ValueChanged)
            {
                RandomBlock();
            }
        }
        public void MoveDown()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (!VisibleBlocks[x][y].Visible)
                    {
                        continue;
                    }
                    for (int i = y - 1; i > 0; i--)
                    {
                        if (VisibleBlocks[x][y].Visible)
                        {
                            ValueChanged = true;
                            VisibleBlocks[x][y] += VisibleBlocks[x][i];
                            y = i;
                        }
                    }
                }
            }
            byte counter = 3;
            for (int x = 0; x < 4; x++)
            {
                for (int y = 3; y >= 0; y--)
                {
                    if (VisibleBlocks[x][y].Visible)
                    {
                        if (counter != y)
                        {
                            VisibleBlocks[x][counter].Number = VisibleBlocks[x][y].Number;
                            VisibleBlocks[x][y].Number = 0;
                            VisibleBlocks[x][y].Visible = false;
                            Blocks.Add(VisibleBlocks[x][y]);
                            VisibleBlocks[x][counter].Visible = true;
                            ValueChanged = true;
                        }
                        counter--;
                    }
                }
                counter = 3;
            }
            if (ValueChanged)
            {
                RandomBlock();
            }
        }
    }
}
