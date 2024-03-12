using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls; //ListBox會用到
using Windows.UI.Xaml.Data;  //Binding好像也是要用這個

namespace p01JoeyTest.UControl.Practice.Controls
{
    class FlipViewIndicator:ListBox
    {
        public FlipViewIndicator()
        {
            this.DefaultStyleKey = typeof(FlipViewIndicator);   //不知為何要用這個
        }

        public FlipView FlipView
        {
            get { return (FlipView)GetValue(FlipViewProperty); }    //寫這行後,就有建議要建立 DependencyProperty 變數型態的 FlipViewProperty
            set { SetValue(FlipViewProperty, value); }
        }

        // 非常重要
        public DependencyProperty FlipViewProperty =
            DependencyProperty.Register("FlipView", typeof(FlipView), typeof(FlipViewIndicator), new PropertyMetadata(null, (depobj, args) => {
                FlipViewIndicator fvi = (FlipViewIndicator)depobj;
                FlipView fv = (FlipView)args.NewValue;
                fv.SelectionChanged += (s, e) =>
                {
                    fvi.ItemsSource = fv.ItemsSource;
                };
                fvi.ItemsSource = fv.ItemsSource;
                Binding eb = new Binding();
                eb.Mode = BindingMode.TwoWay;
                eb.Source = fv;
                eb.Path = new PropertyPath("SelectedItem");
                fvi.SetBinding(FlipViewIndicator.SelectedItemProperty, eb);
            }));
    }
}
