using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WindowsFromLibrary.CustomControl
{
    /// <summary>
    /// トグルの向きを指定する列挙型
    /// </summary>
    public enum ToggleDirection
    {
        /// <summary>
        /// ON:右 , OFF:左
        /// </summary>
        LeftToRight,
        /// <summary>
        /// ON:左 , OFF:右
        /// </summary>
        RightToLeft,
        /// <summary>
        /// ON:下 , OFF:上
        /// </summary>
        TopToBottom,
        /// <summary>
        /// ON:上 , OFF下
        /// </summary>
        BottomToTop
    }

    /// <summary>
    /// スタジアム形トグルボタンクラス
    /// </summary>
    public class StadiumShapeToggleButton : CheckBox
    {
        #region メンバ変数
        private Color _onBackColor = Color.MediumBlue;
        private Color _onToggleColor = Color.WhiteSmoke;
        private Color _offBackColor = Color.Gray;
        private Color _offToggleColor = Color.Gainsboro;
        private bool _solidStyle = true;
        private string _state = string.Empty;
        private float _fontSize = 10f;
        private Color _fontColor = Color.Black;
        private ToggleDirection _toggleDirection = ToggleDirection.LeftToRight;
        private int _id;
        #endregion

        #region プロパティ
        /// <summary>
        /// ON時バックカラー
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
        /// ON時トグルカラー
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
        /// OFF時バックカラー
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
        /// OFF時トグルカラー
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
        /// テキスト
        /// </summary>
        public override string Text { get => base.Text; }
        /// <summary>
        /// ソリッドスタイル
        /// </summary>
        [DefaultValue ( true )]
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
        /// フォントサイズ
        /// </summary>
        public float FontSize
        {
            get => _fontSize; set
            {
                _fontSize = value;
                this.Font = new Font ( this.Font.FontFamily , _fontSize );
                this.Invalidate ();
            }
        }
        /// <summary>
        /// フォントカラー
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
        /// トグルボタン表示角度
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
        /// ID
        /// </summary>
        public int Id { get => _id; set => _id =  value ; }
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public StadiumShapeToggleButton ()
        {
            this.MinimumSize = new Size ( 45 , 22 );
            this.AutoSize = false;
        }
        #endregion

        /// <summary>
        /// 形状パス取得
        /// </summary>
        private GraphicsPath GetFigurePath ()
        {
            if ( _toggleDirection == ToggleDirection.LeftToRight || _toggleDirection == ToggleDirection.RightToLeft )
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

        /// <summary>
        /// 描画処理
        /// </summary>
        protected override void OnPaint ( PaintEventArgs paintEventArgs )
        {
            int toggleSize = _toggleDirection == ToggleDirection.LeftToRight || _toggleDirection == ToggleDirection.RightToLeft
                ? this.Height - 5
                : this.Width - 5;

            paintEventArgs.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            paintEventArgs.Graphics.Clear ( this.BackColor );

            bool isCheck = this.Checked;

            // 背景描画
            if ( isCheck )
            {
                if ( _solidStyle )
                {
                    paintEventArgs.Graphics.FillPath ( new SolidBrush ( _onBackColor ) , GetFigurePath () );
                }
                else
                {
                    paintEventArgs.Graphics.DrawPath ( new Pen ( _onBackColor , 2 ) , GetFigurePath () );
                }
            }
            else
            {
                if ( _solidStyle )
                {
                    paintEventArgs.Graphics.FillPath ( new SolidBrush ( _offBackColor ) , GetFigurePath () );
                }
                else
                {
                    paintEventArgs.Graphics.DrawPath ( new Pen ( _offBackColor , 2 ) , GetFigurePath () );
                }
            }

            // トグルの位置計算
            Rectangle toggleRect;
            switch ( _toggleDirection )
            {
                case ToggleDirection.LeftToRight:
                    toggleRect = new Rectangle ( isCheck ? this.Width - this.Height + 1 : 2 , 2 , toggleSize , toggleSize );
                    break;
                case ToggleDirection.RightToLeft:
                    toggleRect = new Rectangle ( isCheck ? 2 : this.Width - this.Height + 1 , 2 , toggleSize , toggleSize );
                    break;
                case ToggleDirection.TopToBottom:
                    toggleRect = new Rectangle ( 2 , isCheck ? this.Height - this.Width + 1 : 2 , toggleSize , toggleSize );
                    break;
                case ToggleDirection.BottomToTop:
                    toggleRect = new Rectangle ( 2 , isCheck ? 2 : this.Height - this.Width + 1 , toggleSize , toggleSize );
                    break;
                default:
                    toggleRect = new Rectangle ( 2 , 2 , toggleSize , toggleSize );
                    break;
            }

            paintEventArgs.Graphics.FillEllipse ( new SolidBrush ( isCheck ? _onToggleColor : _offToggleColor ) , toggleRect );

            // テキスト描画
            using ( StringFormat stringFormat = new StringFormat () )
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                using ( Brush textBrush = new SolidBrush ( _fontColor ) )
                {
                    paintEventArgs.Graphics.DrawString ( State , this.Font , textBrush , toggleRect , stringFormat );
                }
            }
        }
    }
}
