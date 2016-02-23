using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toop_project.src.GUI {
    public partial class SinkButton : Button, INotifyPropertyChanged {

    #region constructors
        public SinkButton() {
            InitializeComponent();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }
    #endregion
    
    #region vars & properties
        // TODO: add colors for this states
        enum MouseState { None, Hover, Pushed }
        MouseState mouseState { 
            get { return _mouseState; } 
            set {
                _mouseState = value;
                updateBrushColor();
            } 
        }
        MouseState _mouseState = MouseState.None;

        Rectangle rect = new Rectangle();
        Rectangle borderRect = new Rectangle();
        Brush mainBrush = new SolidBrush(DefaultBackColor);
        Color borderColor = DefaultForeColor;
        Brush foreBrush = new SolidBrush(DefaultForeColor);
        float borderWidth = 0.0f;
        float sinkBorderWidth = 1.0f;
        Pen borderPen = new Pen(DefaultForeColor, 0.0f);
        StringFormat stringFormat = new StringFormat();

        [Description("Specifies the sinked value."),
        Category("Appearance"),
        DefaultValue(false),
        Browsable(true)]
        public bool Sink { 
            get { return sink; } 
            set {
                sink = value;
                updateBrushColor();
                NotifyPropertyChanged("Sink");
            } 
        }
        bool sink = false;
    #endregion

    #region override methods
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            updateRects();
        }
        protected override void OnBackColorChanged(EventArgs e) {
            base.OnBackColorChanged(e);
            updateBrushColor();
        }
        protected override void OnPaint(PaintEventArgs pevent) {
            var graphics = pevent.Graphics;
            drawElement(graphics);
            drawBorder(graphics);
        }
        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            mouseState = MouseState.Hover;
        }
        protected override void OnMouseLeave(EventArgs e) {
            base.OnMouseLeave(e);
            mouseState = MouseState.None;
        }
        protected override void OnMouseDown(MouseEventArgs mevent) {
            base.OnMouseDown(mevent);
            mouseState = MouseState.Pushed;
        }
        protected override void OnMouseUp(MouseEventArgs mevent) {
            base.OnMouseUp(mevent);
            Sink = !Sink;
        }
    #endregion

    #region methods
        private void drawElement(Graphics graphics) {
            graphics.FillRectangle(mainBrush, rect);
            graphics.DrawString(Text, Font, foreBrush, borderRect, stringFormat);
        }
        private void drawBorder(Graphics graphics) {
            if (borderPen.Width > 0.0f)
                graphics.DrawRectangle(borderPen, borderRect);
        }
        private void updateRects() {
            rect = new Rectangle(new Point(), Size);
            var bord = (int)(borderPen.Width / 2.0f);
            borderRect = new Rectangle(
                new Point(bord, bord),
                new Size(Size.Width - 1 - bord, Size.Height - 1 - bord));
        }
        private void updateBrushColor() {
            resetMainColor();
            updateRects();
            Refresh();
        }
        private void resetMainColor() {
            if (Sink) {
                Color sinkColor = getSinkColor();
                mainBrush = new SolidBrush(sinkColor);
                borderPen = new Pen(ForeColor, sinkBorderWidth);
                // TODO: add colors for this states
                /*
                switch (mouseState) {
                    case MouseState.None:
                        return;
                    case MouseState.Hover:
                        return;
                    case MouseState.Pushed:
                        return;
                }*/
            }
            else {
                mainBrush = new SolidBrush(BackColor);
                borderPen = new Pen(ForeColor, borderWidth);
                // TODO: add colors for this states
                /*
                switch (mouseState) {
                    case MouseState.None:
                        return;
                    case MouseState.Hover:
                        return;
                    case MouseState.Pushed:
                        return;
                }*/
            }
        }
        private Color getSinkColor() {
            const int shadowValue = 25;
            var r = BackColor.R - shadowValue;
            var g = BackColor.G - shadowValue;
            var b = BackColor.B - shadowValue;

            return Color.FromArgb(
                r >= 0 ? r : BackColor.R + shadowValue,
                g >= 0 ? g : BackColor.G + shadowValue,
                b >= 0 ? b : BackColor.B + shadowValue
                );
        }
    #endregion

    #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    #endregion

    }
}