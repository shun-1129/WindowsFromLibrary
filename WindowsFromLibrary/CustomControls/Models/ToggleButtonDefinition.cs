namespace WindowsFromLibrary.CustomControls.Models
{
    /// <summary>
    /// トグルボタン定義
    /// </summary>
    public class ToggleButtonDefinition
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
        /// デフォルトステート文字列
        /// </summary>
        public static readonly string DEFAULT_STATE_STR = "未";

        /// <summary>
        /// デフォルトON時背景色
        /// </summary>
        public static readonly Color DEFAULT_ON_BACK_COLOR = Color.AliceBlue;

        /// <summary>
        /// デフォルトOFF時背景色
        /// </summary>
        public static readonly Color DEFAULT_OFF_BACK_COLOR = Color.Red;

        /// <summary>
        /// デフォルトON時トグル色
        /// </summary>
        public static readonly Color DEFAULT_ON_TOGGLE_COLOR = Color.WhiteSmoke;

        /// <summary>
        /// デフォルトOFF時トグル色
        /// </summary>
        public static readonly Color DEFAULT_OFF_TOGGLE_COLOR = Color.WhiteSmoke;
    }
}
