using System.Drawing.Drawing2D;
using static WindowsFromLibrary.CustomControls.Models.ToggleButtonDefinition;

namespace WindowsFromLibrary.CustomControls
{
    /// <summary>
    /// 長方形トグルボタン
    /// </summary>
    public class RectangleToggleButton : BaseToggleButton
    {
        #region メンバ変数
        #endregion

        #region プロパティ
        #endregion

        #region メソッド
        #region 公開メソッド
        /// <summary>
        /// 描画処理
        /// </summary>
        protected override void OnPaint ( PaintEventArgs paintEventArgs )
        {
            int toggleSize = ToggleDirection == ToggleDirection.LeftToRight || ToggleDirection == ToggleDirection.RightToLeft
            ? this.Height - 5
                : this.Width - 5;

            paintEventArgs.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            paintEventArgs.Graphics.Clear ( this.BackColor );

            bool isCheck = this.Checked;

            // 背景描画
            if ( isCheck )
            {
                if ( SolidStyle )
                {
                    paintEventArgs.Graphics.FillPath ( new SolidBrush ( OnBackColor ) , GetFigurePath () );
                }
                else
                {
                    paintEventArgs.Graphics.DrawPath ( new Pen ( OnBackColor , 2 ) , GetFigurePath () );
                }
            }
            else
            {
                if ( SolidStyle )
                {
                    paintEventArgs.Graphics.FillPath ( new SolidBrush ( OffBackColor ) , GetFigurePath () );
                }
                else
                {
                    paintEventArgs.Graphics.DrawPath ( new Pen ( OffBackColor , 2 ) , GetFigurePath () );
                }
            }

            // トグルの位置計算
            Rectangle toggleRect;
            switch ( ToggleDirection )
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

            paintEventArgs.Graphics.FillEllipse ( new SolidBrush ( isCheck ? OnToggleColor : OffToggleColor ) , toggleRect );

            // テキスト描画
            using ( StringFormat stringFormat = new StringFormat () )
            {
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                using ( Brush textBrush = new SolidBrush ( FontColor ) )
                {
                    paintEventArgs.Graphics.DrawString ( State , this.Font , textBrush , toggleRect , stringFormat );
                }
            }
        }
        #endregion

        #region 内部メソッド
        /// <summary>
        /// 形状パス取得
        /// </summary>
        protected override GraphicsPath GetFigurePath ()
        {
            return base.GetFigurePath ();
        }
        #endregion
        #endregion
    }
}
