using System;
using CustomRendererTest.Controls;
using CustomRendererTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]

namespace CustomRendererTest.Droid
{
    public class CustomSwitchRenderer
        : SwitchRenderer
    {
        public CustomSwitchRenderer ()
        {    
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
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

            //            if (e.PropertyName == MCSwitch.TrackColorProperty.PropertyName
            //                || e.PropertyName == MCSwitch.ThumbColorProperty.PropertyName
            //                || e.PropertyName == MCSwitch.OnThumbColorProperty.PropertyName
            //                || e.PropertyName == MCSwitch.OffThumbColorProperty.PropertyName)
            //            {
            UpdateColors();
            //            }
        }

        private void UpdateColors()
        {
            var element = Element as CustomSwitch;

            var track = new Android.Graphics.Drawables.GradientDrawable();

            track.SetColor(element.TrackColor.ToAndroid());
            track.SetSize((int)Element.Width, (int)Element.Height);
            Control.TrackDrawable = track;

            var thumb = new Android.Graphics.Drawables.GradientDrawable();

            if (Element.IsToggled)
            {
                thumb.SetColor(element.OnThumbColor.ToAndroid());
            }
            else
            {
                thumb.SetColor(element.OffThumbColor.ToAndroid());
            }

            Control.ThumbDrawable = thumb;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

        }
    }
}

