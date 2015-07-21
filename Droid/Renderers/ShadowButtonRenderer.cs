using System;
using Android.Graphics.Drawables;
using CustomRendererTest.Controls;
using CustomRendererTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ShadowButton), typeof(ShadowButtonRenderer))]

namespace CustomRendererTest.Droid
{
    public class ShadowButtonRenderer
        : ButtonRenderer
    {
        private GradientDrawable _pressed;
        private LayerDrawable _normal;

        protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged (e);

            if (e.NewElement == null) {
                return;
            }

            if (Control != null) {
                UpdateColors ();
            }
        }

        protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged (sender, e);

            if (e.PropertyName == ShadowButton.BackgroundColorProperty.PropertyName
                || e.PropertyName == ShadowButton.BorderColorProperty.PropertyName
                || e.PropertyName == ShadowButton.BorderWidthProperty.PropertyName
                || e.PropertyName == ShadowButton.BorderRadiusProperty.PropertyName
                || e.PropertyName == ShadowButton.ShadowColorProperty.PropertyName)
            {
                UpdateColors (); 
            }
        }

        private void UpdateColors ()
        {
            var button = Element as ShadowButton;

            var normal = new Android.Graphics.Drawables.GradientDrawable ();
            normal.SetColor (button.BackgroundColor.ToAndroid ());
            normal.SetStroke ((int)button.BorderWidth, button.BorderColor.ToAndroid ());
            normal.SetCornerRadius (button.BorderRadius);
            var shadow = new Android.Graphics.Drawables.GradientDrawable ();
            shadow.SetColor (button.ShadowColor.ToAndroid ());
            shadow.SetStroke ((int)button.BorderWidth, button.ShadowColor.ToAndroid ());
            shadow.SetCornerRadius (button.BorderRadius);

            _normal = new Android.Graphics.Drawables.LayerDrawable ( 
                new Drawable [] { shadow, normal }
            ); 

            var density = 3;

            _normal.SetLayerInset (1, 0, 0, 0, 2 * density);

            _pressed = new Android.Graphics.Drawables.GradientDrawable ();

            var highlight = Context.ObtainStyledAttributes (new int [] {
                Android.Resource.Attribute.ColorActivatedHighlight  
            }).GetColor(0, Android.Graphics.Color.Gray);
            _pressed.SetColor (highlight);
            _pressed.SetStroke ((int)button.BorderWidth, button.BorderColor.ToAndroid ());
            _pressed.SetCornerRadius (button.BorderRadius);

            var sld = new StateListDrawable ();
            sld.AddState (new int[] { Android.Resource.Attribute.StatePressed }, _pressed);
            sld.AddState (new int[] {}, _normal );

            Control.SetPaddingRelative (0, 0, 2, 0);
            Control.SetBackgroundDrawable (sld);        
        }
        
        public ShadowButtonRenderer()
        {
        }
    }
}

