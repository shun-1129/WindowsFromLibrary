using WindowsFromLibrary.CustomControls.Models;

namespace WindowsFromLibrary.CustomControls
{
    /// <summary>
    /// 長方形トグルボタン
    /// </summary>
    public class RectangleToggleButton : BaseToggleButton
    {
        #region メンバ変数
        private Color _onBackColor = ToggleButtonDefinition.DEFAULT_ON_BACK_COLOR;
        private Color _offBackColor = ToggleButtonDefinition.DEFAULT_OFF_BACK_COLOR;
        #endregion

        #region プロパティ
        /// <summary>
        /// 
        /// </summary>
        public override Color OnBackColor
        {
            get => _onBackColor;
            set
            {
                _onBackColor = value;
                this.Invalidate ();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override Color OffBackColor
        {
            get => _offBackColor;
            set
            {
                _offBackColor = value;
                this.Invalidate ();
            }
        }
        #endregion
    }
}
