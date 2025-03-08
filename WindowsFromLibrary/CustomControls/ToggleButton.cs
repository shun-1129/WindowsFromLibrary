using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace WindowsFromLibrary.CustomControl
{
    /// <summary>
    /// トグルボタンクラス
    /// </summary>
    public class ToggleButton : CheckBox
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
            set => _state = value;
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
        #endregion

        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ToggleButton ()
        {
            this.MinimumSize = new Size ( 45 , 22 );
            this.AutoSize = false;
        }
        #endregion

        /// <summary>
        /// 形状パス取得
        /// </summary>
        /// <returns></returns>
        private GraphicsPath GetFigurePath ()
        {
            int arcSize = this.Height - 1;
            Rectangle leftArc = new Rectangle ( 0 , 0, arcSize , arcSize );
            Rectangle rightArc = new Rectangle ( this.Width - arcSize - 2 , 0, arcSize , arcSize );

            GraphicsPath graphicsPath = new GraphicsPath ();
            graphicsPath.StartFigure ();
            graphicsPath.AddArc ( leftArc , 90 , 180 );
            graphicsPath.AddArc ( rightArc , 270 , 180 );
            graphicsPath.CloseFigure ();

            return graphicsPath;
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="paintEventArgs">イベント</param>
        protected override void OnPaint ( PaintEventArgs paintEventArgs )
        {
            int toggleSize = this.Height - 5;
            paintEventArgs.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            paintEventArgs.Graphics.Clear ( this.BackColor );

            // ON時
            if ( this.Checked )
            {
                if ( _solidStyle )
                {
                    paintEventArgs.Graphics.FillPath ( new SolidBrush ( _onBackColor ) , GetFigurePath () );
                }
                else
                {
                    paintEventArgs.Graphics.DrawPath ( new Pen ( _onBackColor , 2 ) , GetFigurePath () );
                }

                paintEventArgs.Graphics.FillEllipse (
                    new SolidBrush ( _onToggleColor ) ,
                    new Rectangle ( this.Width - this.Height + 1 , 2 , toggleSize , toggleSize )
                );
            }
            // OFF時
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

                paintEventArgs.Graphics.FillEllipse (
                    new SolidBrush ( _offToggleColor ) ,
                    new Rectangle ( 2 , 2 , toggleSize , toggleSize )
                );
            }

            // テキストの描画
            using ( StringFormat stringFormat = new StringFormat () )
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                // トグルの円の位置を取得
                int circleX = this.Checked ? ( this.Width - this.Height + 1 ) : 2;
                Rectangle circleRect = new Rectangle ( circleX , 2 , toggleSize , toggleSize );

                using ( Brush textBrush = new SolidBrush ( _fontColor ) )
                {
                    paintEventArgs.Graphics.DrawString ( State , this.Font , textBrush , circleRect , stringFormat );
                }
            }
        }
    }
}
