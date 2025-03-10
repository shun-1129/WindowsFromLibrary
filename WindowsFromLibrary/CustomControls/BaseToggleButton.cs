namespace WindowsFromLibrary.CustomControls
{
    /// <summary>
    /// トグルボタン基底クラス
    /// </summary>
    public abstract class BaseToggleButton : CheckBox
    {
        #region プロパティ
        /// <summary>
        /// ON時背景色
        /// </summary>
        public abstract Color OnBackColor { get; set; }
        /// <summary>
        /// OFF時背景色
        /// </summary>
        public abstract Color OffBackColor { get; set; }
        #endregion
    }
}
