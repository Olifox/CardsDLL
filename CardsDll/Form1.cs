using System;
using System.Drawing;
using System.Windows.Forms;

namespace CardsDll
{
    public partial class Form1 : Form
    {
        private readonly Cards _cardHandle;
        private IntPtr _hdc;
        private Coordinates _coor;

        public Form1()
        {
            InitializeComponent();
            Width = 1150;
            Height = 450;
            _coor = new Coordinates();
            _cardHandle = new Cards();
           // this.MouseMove += Form1_MouseMove;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics x = e.Graphics;

            _hdc = x.GetHdc();
            x.ReleaseHdc(_hdc);
            Draw();
            OnMouseEnter();
        }

        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    int mouseX = Cursor.Position.X - this.Location.X;
        //    int mouseY = Cursor.Position.Y - this.Location.Y - 7;
        //    if (mouseX > 10 && mouseX < 81 && mouseY > 10 && mouseY < 105)
        //    {
        //        _cardHandle.DrawCardBack(_hdc, 10, 10, 53);
        //    }
        //}

        private void Draw()
        {
            foreach (var c in _coor.GetAll())
                _cardHandle.DrawCard(_hdc, c[0], c[1], c[2], 0, 0);
            _cardHandle.DrawCardBack(_hdc, 1050, 310, 53);
        }

        private void OnMouseEnter()
        {
            while (true)
            {
                int mouseX = Cursor.Position.X - this.Location.X;
                int mouseY = Cursor.Position.Y - this.Location.Y-7;
                if (_coor.CheckForCoordinates(mouseX, mouseY))
                {
                    var e = _coor.GetOnCoordinates(mouseX, mouseY);
                    _cardHandle.DrawCardBack(_hdc, e[0], e[1], 53);
                    while (_coor.CheckForCards(mouseX,mouseY,e[2]))
                    {
                        mouseX = Cursor.Position.X - this.Location.X;
                        mouseY = Cursor.Position.Y - this.Location.Y - 7;
                    }
                    _cardHandle.DrawCard(_hdc,e[0], e[1], e[2], 0, 0);
                }
            }
        }
    }
}
