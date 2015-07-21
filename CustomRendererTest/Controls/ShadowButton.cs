using System;
using Xamarin.Forms;

namespace CustomRendererTest.Controls
{
    public class ShadowButton
        : Button
    {
        public static BindableProperty ShadowColorProperty = 
            BindableProperty.Create<ShadowButton, Color> (p => p.ShadowColor, Color.White);

        public Color ShadowColor
        {
            get
            {
                return (Color)GetValue (ShadowColorProperty);
            }
            set
            {
                SetValue (ShadowColorProperty, value);
            }
        }
            public ShadowButton()
        {
        }
    }
}

