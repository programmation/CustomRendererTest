using System;
using CustomRendererTest.Controls;
using CustomRendererTest.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]

namespace CustomRendererTest.iOS
{
    public class CustomSwitchRenderer
        : SwitchRenderer
    {
        public CustomSwitchRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            if (Control != null)
            {
                UpdateColors();
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomSwitch.TrackColorProperty.PropertyName
                || e.PropertyName == CustomSwitch.ThumbColorProperty.PropertyName
                || e.PropertyName == CustomSwitch.OnThumbColorProperty.PropertyName
                || e.PropertyName == CustomSwitch.OffThumbColorProperty.PropertyName)
            {
                UpdateColors();
            }
        }

        private void UpdateColors ()
        {
            var element = Element as CustomSwitch;

            Control.OnTintColor = element.TrackColor.ToUIColor();
            Control.TintColor = element.TrackColor.ToUIColor();
            Control.ThumbTintColor = element.ThumbColor.ToUIColor();
        }
    }
}

