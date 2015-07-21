using System;
using Xamarin.Forms;

namespace CustomRendererTest.Controls
{
    public class CustomSwitch
        : Switch
    {
        public static BindableProperty TrackColorProperty = 
            BindableProperty.Create<CustomSwitch, Color>(p => p.TrackColor, Color.Accent);

        public static BindableProperty ThumbColorProperty = 
            BindableProperty.Create<CustomSwitch, Color>(p => p.ThumbColor, Color.White);

        public static BindableProperty OnThumbColorProperty = 
            BindableProperty.Create<CustomSwitch, Color>(p => p.OnThumbColor, Color.White);

        public static BindableProperty OffThumbColorProperty = 
            BindableProperty.Create<CustomSwitch, Color>(p => p.OffThumbColor, Color.White);

        public Color TrackColor
        {
            get
            {
                return (Color)GetValue(TrackColorProperty);
            }
            set
            {
                SetValue(TrackColorProperty, value);
            }
        }

        public Color ThumbColor
        {
            get
            {
                return (Color)GetValue(ThumbColorProperty);
            }
            set
            {
                SetValue(ThumbColorProperty, value);
            }
        }

        public Color OnThumbColor
        {
            get
            {
                return (Color)GetValue(OnThumbColorProperty);
            }
            set
            {
                SetValue(OnThumbColorProperty, value);
            }
        }

        public Color OffThumbColor
        {
            get
            {
                return (Color)GetValue(OffThumbColorProperty);
            }
            set
            {
                SetValue(OffThumbColorProperty, value);
            }
        }

        public CustomSwitch()
        {
        }
    }
}

