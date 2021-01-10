using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WanWan.Pan.App.Helpers;

namespace WanWan.Pan.App.Common.Converters
{
    /// <summary>
    /// 地址转图片转换器
    /// </summary>
    public class IUrlToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string fileurl = $"{AppDomain.CurrentDomain.BaseDirectory}Skin\\Kind\\{value.ToString()}";
                if (File.Exists(fileurl))
                {
                    BitmapImage fileImg = ImageHelper.ConvertToImage(fileurl);
                    return fileImg;
                }
            }
            BitmapImage img = ImageHelper.ConvertToImage($"{AppDomain.CurrentDomain.BaseDirectory}Images\\background.png");
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
