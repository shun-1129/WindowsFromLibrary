using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace WindowsFromLibrary.Infrastructure
{
    public static class PropertyBindHelper
    {
        /// <summary>
        /// 値、状態をバインド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="item1">バインドするプロパティの Expression</param>
        /// <param name="item2">バインドする値のExpression</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Bind<T, U> ( Expression<Func<T>> item1 , Expression<Func<U>> item2 )
        {
            Tuple<object , string> ResolveLambda<V> ( Expression<Func<V>> expression )
            {
                var lambda = expression as LambdaExpression;
                if ( lambda == null ) throw new ArgumentException ();
                var property = lambda.Body as MemberExpression;
                if ( property == null ) throw new ArgumentException ();
                var members = new List<MemberInfo>();
                var parent = property.Expression;
                return new Tuple<object , string> ( Expression.Lambda ( parent ).Compile ().DynamicInvoke () , property.Member.Name );
            }
            var tuple1 = ResolveLambda(item1);
            var tuple2 = ResolveLambda(item2);
            var control = tuple1.Item1 as Control;
            if ( control == null ) throw new ArgumentException ();
            control.DataBindings.Add ( new Binding ( tuple1.Item2 , tuple2.Item1 , tuple2.Item2 ) );
        }

        /// <summary>
        /// TextBoxへ値をバインド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textBox">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> ( TextBox textBox , Expression<Func<T>> expression )
        {
            Bind ( () => textBox.Text , expression );
        }

        /// <summary>
        /// Labelへ値をバインド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="label">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> ( Label label , Expression<Func<T>> expression )
        {
            Bind ( () => label.Text , expression );
        }

        /// <summary>
        /// DataGridView
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> ( DataGridView dataGridView , Expression<Func<T>> expression )
        {
            Bind ( () => dataGridView.DataSource , expression );
        }

        /// <summary>
        /// Buttonへ値をバインド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="button">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> ( Button button , Expression<Func<T>> expression )
        {
            Bind ( () => button.Text , expression );
        }


        /// <summary>
        /// Buttonへ値をバインド
        /// </summary>
        /// <param name="button">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind ( Button button , DelegateCommand command )
        {
            button.Click += ( sender , aegs ) => { command.Execute (); };
        }

        /// <summary>
        /// Buttonへ値をバインド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="button">バインドするプロパティ</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> (Button button , DelegateCommand<T> command )
        {
            button.Click += ( sender , aegs ) => { command.Execute ( aegs ); };
        }

        /// <summary>
        /// Buttonへ値をバインドする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="button">バインドするプロパティ</param>
        /// <param name="command">バインドする値</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T> ( Button button , DelegateCommand command , Expression<Func<T>> expression )
        {
            Bind ( () => button.Text , expression );
            button.Click += ( sender , aegs ) => { command.Execute (); };
        }

        /// <summary>
        /// Buttonへ値をバインドする
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="button">バインドするプロパティ</param>
        /// <param name="command">バインドする値</param>
        /// <param name="expression">バインドする値</param>
        public static void Bind<T, U> ( Button button , DelegateCommand<T> command , Expression<Func<U>> expression )
        {
            Bind ( () => button.Text , expression );
            button.Click += ( sender , aegs ) => { command.Execute (aegs); };
        }
    }
}
