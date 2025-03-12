using System.Drawing.Drawing2D;
using WindowsFromLibrary.CustomControls.Models;
using static WindowsFromLibrary.CustomControls.Models.ToggleButtonDefinition;

namespace WindowsFromLibrary.CustomControls
{
    /// <summary>
    /// トグルボタン基底クラス
    /// </summary>
    public abstract class BaseToggleButton : CheckBox
    {
        #region メンバ変数
        /// <summary>
        /// トグル形状方向
        /// </summary>
        private ToggleDirection _toggleDirection;
        /// <summary>
        /// ID
        /// </summary>
        private int _id;
        /// <summary>
        /// ON時背景色
        /// </summary>
        private Color _onBackColor = ToggleButtonDefinition.DEFAULT_ON_BACK_COLOR;
        /// <summary>
        /// OFF時背景色
        /// </summary>
        private Color _offBackColor = ToggleButtonDefinition.DEFAULT_OFF_BACK_COLOR;
        /// <summary>
        /// ON時トグル色
        /// </summary>
        private Color _onToggleColor = ToggleButtonDefinition.DEFAULT_ON_TOGGLE_COLOR;
        /// <summary>
        /// OFF時トグル色
        /// </summary>
        private Color _offToggleColor = ToggleButtonDefinition.DEFAULT_OFF_TOGGLE_COLOR;
        /// <summary>
        /// 状態
        /// </summary>
        private string _state = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        private bool _solidStyle = false;
        /// <summary>
        /// フォント色
        /// </summary>
        private Color _fontColor = Color.Black;
        /// <summary>
        /// フォントサイズ
        /// </summary>
        private float _fontSize = 10f;
        #endregion

        #region プロパティ
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// トグル形状方向
        /// </summary>
        public ToggleDirection ToggleDirection
        {
            get => _toggleDirection;
            set
            {
                _toggleDirection = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// ON時背景色
        /// </summary>
        public Color OnBackColor
        {
            get => _onBackColor;
            set
            {
                _onBackColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// OFF時背景色
        /// </summary>
        public Color OffBackColor
        {
            get => _offBackColor;
            set
            {
                _offBackColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// ON時トグル色
        /// </summary>
        public Color OnToggleColor
        {
            get => _onToggleColor;
            set
            {
                _onToggleColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// OFF時トグル色
        /// </summary>
        public Color OffToggleColor
        {
            get => _offToggleColor;
            set
            {
                _offToggleColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// 状態
        /// </summary>
        public string State
        {
            get => _state;
            set
            {
                _state = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool SolidStyle
        {
            get => _solidStyle;
            set
            {
                _solidStyle = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// フォント色
        /// </summary>
        public Color FontColor
        {
            get => _fontColor;
            set
            {
                _fontColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// フォントサイズ
        /// </summary>
        public float FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                this.Invalidate ();
            }
        }
        #endregion

        #region メソッド
        #region 公開メソッド
        #endregion

        #region 内部メソッド
        /// <summary>
        /// 形状パス取得
        /// </summary>
        protected virtual GraphicsPath GetFigurePath ()
        {
            if ( ToggleDirection == ToggleDirection.LeftToRight || ToggleDirection == ToggleDirection.RightToLeft )
            {
                int arcSize = this.Height - 1;
                Rectangle leftArc = new Rectangle ( 0 , 0 , arcSize , arcSize );
                Rectangle rightArc = new Rectangle ( this.Width - arcSize - 2 , 0 , arcSize , arcSize );

                GraphicsPath graphicsPath = new GraphicsPath ();
                graphicsPath.AddArc ( leftArc , 90 , 180 );
                graphicsPath.AddArc ( rightArc , 270 , 180 );
                graphicsPath.CloseFigure ();
                return graphicsPath;
            }
            else
            {
                int arcSize = this.Width - 1;
                Rectangle topArc = new Rectangle ( 0 , 0 , arcSize , arcSize );
                Rectangle bottomArc = new Rectangle ( 0 , this.Height - arcSize - 2 , arcSize , arcSize );

                GraphicsPath graphicsPath = new GraphicsPath ();
                graphicsPath.AddArc ( topArc , 180 , 180 );
                graphicsPath.AddArc ( bottomArc , 0 , 180 );
                graphicsPath.CloseFigure ();
                return graphicsPath;
            }
        }
        #endregion
        #endregion
    }
}
