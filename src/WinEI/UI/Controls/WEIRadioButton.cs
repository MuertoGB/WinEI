﻿// WinEI
// https://github.com/MuertoGB/WinEI

// UI Components
// WEIRadioButton.cs
// Released under the GNU GLP v3.0

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WinEI.UI.Design;

namespace WinEI.UI.Controls
{
    [DefaultBindingProperty("Checked")]
    [DefaultProperty("Checked")]
    [Designer(typeof(WEIRadioButtonDesigner))]
    internal class WEIRadioButton : RadioButton
    {

        #region Fields
        private bool MouseHovered = false;
        #endregion

        #region Constructor
        public WEIRadioButton()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint, true);

            MouseEnter += new EventHandler(HandleMouseEnter);
            MouseLeave += new EventHandler(HandleMouseEnter);
            BackColor = Color.Transparent;
            ForeColor = Colours.CONTROL_WHITE_TEXT;
        }
        #endregion

        #region Properties
        private Color _borderColorInactive = Colours.BORDER_INACTIVE;
        [Description("The border color of the control when inactive.")]
        [Category("Appearance (WEI)")]
        public Color BorderColor
        {
            get
            {
                return _borderColorInactive;
            }
            set
            {
                _borderColorInactive = value;
                Invalidate();
            }
        }

        private Color _borderColorActive = Colours.BORDER_ACTIVE;
        [Description("The border color of the control when the mouse is over it.")]
        [Category("Appearance (WEI)")]
        public Color BorderColorActive
        {
            get
            {
                return _borderColorActive;
            }
            set
            {
                _borderColorActive = value;
                Invalidate();
            }
        }

        private Color _clientColorInactive = Colours.CLIENT_INACTIVE;
        [Description("The background color of the control when inactive.")]
        [Category("Appearance (WEI)")]
        public Color ClientColor
        {
            get
            {
                return _clientColorInactive;
            }
            set
            {
                _clientColorInactive = value;
                Invalidate();
            }
        }

        private Color _clientColorActive = Colours.CLIENT_ACTIVE;
        [Description("The background color of the control when the mouse is over it.")]
        [Category("Appearance (WEI)")]
        public Color ClientColorActive
        {
            get
            {
                return _clientColorActive;
            }
            set
            {
                _clientColorActive = value;
                Invalidate();
            }
        }

        private Color _checkedColor = Colours.CHECKED;
        [Description("The color of the control when it is checked.")]
        [Category("Appearance (WEI)")]
        public Color CheckedColor
        {
            get
            {
                return _checkedColor;
            }
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }
        #endregion

        #region Paint Methods
        protected override void OnPaint(PaintEventArgs e)
        {
            OnPaintBackground(e);
            OnPaintForegound(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (e != null)
            {
                if (BackColor.A == 255)
                {
                    e.Graphics.Clear(
                        BackColor);

                    return;
                }

                base.OnPaintBackground(e);
            }
        }

        protected virtual void OnPaintForegound(PaintEventArgs e)
        {
            if (e == null)
                return;

            int Diameter =
                ClientRectangle.Height - 1;

            RectangleF outerRectangle =
                new RectangleF(
                    0,
                    0,
                    Diameter,
                    Diameter);

            RectangleF innerRectangle =
                new RectangleF(
                    1,
                    1,
                    Diameter - 2,
                    Diameter - 2);

            outerRectangle.Inflate(-1, -1);

            e.Graphics.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            e.Graphics.SmoothingMode =
                SmoothingMode.AntiAlias;

            e.Graphics.CompositingQuality =
                CompositingQuality.HighQuality;

            Color setCheckBorderColor = Enabled
                ? (MouseHovered ? BorderColorActive : BorderColor)
                : Colours.DISABLED_CONTROL;

            using (Pen pen = new Pen(setCheckBorderColor, width: 2))
            {
                e.Graphics.DrawArc(
                    pen,
                    outerRectangle,
                    135,
                    180);

                e.Graphics.DrawArc(
                    pen,
                    outerRectangle,
                    -45,
                    180);
            }

            innerRectangle.Inflate(-1, -1);

            Color setCheckInnerColor = MouseHovered
                ? ClientColorActive
                : ClientColor;

            using (SolidBrush brush = new SolidBrush(setCheckInnerColor))
            {
                e.Graphics.FillEllipse(
                    brush,
                    innerRectangle);
            }

            if (Checked)
            {
                innerRectangle =
                    new RectangleF(
                        1,
                        1,
                        Diameter - 2,
                        Diameter - 2);

                innerRectangle.Inflate(-4, -4); // Control size of check

                using (SolidBrush brush = new SolidBrush(CheckedColor))
                {
                    e.Graphics.FillEllipse(
                        brush,
                        innerRectangle);
                }
            }

            Rectangle textArea =
                new Rectangle((int)outerRectangle.Width + 5,
                0,
                Width - (int)outerRectangle.Width - 6,
                Height);

            Color textColor = Enabled
                ? ForeColor
                : Colours.CONTROL_DISABLED_TEXT;

            using (StringFormat format = new StringFormat() { LineAlignment = StringAlignment.Center })
            using (SolidBrush brush = new SolidBrush(textColor))
            {
                e.Graphics.DrawRectangle(
                    Pens.Transparent,
                    textArea);

                e.Graphics.DrawString(
                    Text,
                    Font,
                    brush,
                    textArea,
                    format);
            }

            if (Focused)
            {
                using (Pen pen = new Pen(Colours.FOCUS_RECTANGLE, 1))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                    Rectangle rect = ClientRectangle;

                    rect.Width -= 1; rect.Height -= 1;

                    e.Graphics.DrawRectangle(
                        pen,
                        rect);
                }
            }
        }
        #endregion

        #region Overriden Methods
        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            MouseHovered = false;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            MouseHovered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            ResizeRedraw = true;
            base.OnResize(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            GetPreferredSizeN();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Invalidate();
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }
        #endregion

        #region Custom Methods
        private void HandleMouseEnter(object sender, EventArgs e)
        {
            if (ClientRectangle.Contains(PointToClient(MousePosition)))
                if (!MouseHovered)
                {
                    MouseHovered = true;
                    Invalidate();
                }
                else
                {
                    MouseHovered = false;
                    Invalidate();
                }
        }
        private Size GetPreferredSizeN()
        {
            return GetPreferredSize(
                new Size(
                    0,
                    0));
        }
        #endregion

    }
}