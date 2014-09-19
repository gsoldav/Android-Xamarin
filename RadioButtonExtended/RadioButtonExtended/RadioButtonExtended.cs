using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Graphics;
using Android.Graphics.Drawables;

namespace RadioButtonExtended
{
    public class RadioButtonExtended : RadioButton
    {
        public RadioButtonExtended(Context context)
            : base(context)
        {
        }

        public RadioButtonExtended(Context context, Android.Util.IAttributeSet attrs)
            : base(context, attrs)
        {
            SetButtonDrawable(Color.Transparent);
        }

        public RadioButtonExtended(Context context, Android.Util.IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            String rdText = this.Text.ToString();
            Paint textPaint = new Paint();
            textPaint.AntiAlias = true;
            textPaint.TextSize = this.TextSize;
            textPaint.TextAlign = Android.Graphics.Paint.Align.Center;

            float canvasWidth = canvas.Width;
            float textWidth = textPaint.MeasureText(rdText);

            if (Checked)
            {
                this.SetBackgroundResource(Resource.Drawable.RoundedShape);
                int[] colors = new int[] { this.Context.Resources.GetColor(Resource.Color.radioUnselectTop), this.Context.Resources.GetColor(Resource.Color.radioSelectTop )};
                GradientDrawable grad = new GradientDrawable(GradientDrawable.Orientation.TopBottom, colors);
                grad.SetBounds(0, 0, this.Width, this.Height);
                grad.SetCornerRadius(7f);
                this.SetBackgroundDrawable(grad);
            }
            else
            {
                this.SetBackgroundResource(Resource.Drawable.RoundedShape);
                int[] colors = new int[] { this.Context.Resources.GetColor(Resource.Color.radioUnselectTop), this.Context.Resources.GetColor(Resource.Color.radioUnselectBottom) };
                GradientDrawable grad = new GradientDrawable(GradientDrawable.Orientation.TopBottom, colors);
                grad.SetBounds(0, 0, this.Width, this.Height);
                grad.SetCornerRadius(7f);
                this.SetBackgroundDrawable(grad);
            }

            Paint paint = new Paint();
            paint.Color = Color.Transparent;
            paint.SetStyle(Android.Graphics.Paint.Style.Stroke);
            Rect rect = new Rect(0, 0, this.Width, this.Height);
            canvas.DrawRect(rect, paint);

            base.OnDraw(canvas);
        }

        protected override void  OnSizeChanged(int w, int h, int oldw, int oldh)
        {
 	         base.OnSizeChanged(w, h, oldw, oldh);
        }
      
    }
}