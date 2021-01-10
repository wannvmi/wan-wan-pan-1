using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WanWan.Pan.App.Contracts.Views;

namespace WanWan.Pan.App.Views
{
    /// <summary>
    /// ShellWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShellWindow : Window, IShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
            this.Zone.MouseDoubleClick += (sender, e) => { Max(); };
            //Messenger.Default.Register<bool>(this, "PackUp", PackUp);
        }

        #region Messenger

        /// <summary>
        /// 收起面板
        /// </summary>
        /// <param name="ischecked"></param>
        public void PackUp(bool ischecked)
        {
            MenuToggleButton.IsChecked = ischecked;
        }

        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="msg"></param>
        public void Max(bool Mask = false)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        #endregion

        public Frame GetNavigationFrame()
            => ShellFrame;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();
    }
}
