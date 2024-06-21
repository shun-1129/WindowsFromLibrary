using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WindowsFromLibrary.Infrastructure
{
    /// <summary>
    /// ViewModelのベース
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region イベント
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region 公開メソッド
        /// <summary>
        /// プロパティ変更処理
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        public void RaisePropertyChanged ( [CallerMemberName] String propertyName = "" )
        {
            if ( PropertyChanged != null )
            {
                PropertyChanged ( this , new PropertyChangedEventArgs ( propertyName ) );
            }
        }
        #endregion
    }
}
