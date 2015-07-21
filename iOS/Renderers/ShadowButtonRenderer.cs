using System;
using CustomRendererTest.Controls;
using CustomRendererTest.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(ShadowButton), typeof(ShadowButtonRenderer))]

namespace CustomRendererTest.iOS
{
    public class ShadowButtonRenderer
        : ButtonRenderer
    {
        public ShadowButtonRenderer()
        {
            Layer.MasksToBounds = false;
            Layer.ShadowOpacity = 1;
            Layer.ShadowRadius = 0;
            Layer.ShadowOffset = new CGSize (0, 3);
        }

        protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged (e);

            if (e.NewElement == null)
            { 
                return;
            }

            if (Control != null)
            {
                UpdateColors ();
            }
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == ShadowButton.BackgroundColorProperty.PropertyName
                || e.PropertyName == ShadowButton.ShadowColorProperty.PropertyName)
            {
                UpdateColors ();
            }
        }

        private void UpdateColors ()
        {
            var element = Element as ShadowButton;
            Layer.ShadowColor = element.ShadowColor.ToCGColor ();
        }
    }
}

