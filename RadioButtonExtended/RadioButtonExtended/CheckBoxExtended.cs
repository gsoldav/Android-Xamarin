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
using Android.Util;

namespace RadioButtonExtended
{
    public class CheckBoxExtended : CheckBox
    {
        private Drawable buttonDrawable;
        //private float mX;

        public CheckBoxExtended(Context context)
            : base(context)
        {
            this.SetButtonDrawable(Android.Resource.Color.Transparent);
            buttonDrawable = Resources.GetDrawable(Resource.Drawable.checkbox);
        }

        public CheckBoxExtended(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            //FirstLog.Debug(FirstApplication.ApplicationName + "Log", "FirstCheckBox(2)");

            ////buttonDrawable = Resources.GetDrawable(Resource.Drawable.checkbox);
            //if (attrs != null)
            //{
            //    FirstLog.Debug(FirstApplication.ApplicationName + "Log", "CheckBox.Button attrs[" + attrs.AttributeCount + "]");
            //    for (int nAttr = 0; nAttr < attrs.AttributeCount; nAttr++)
            //    {
            //        FirstLog.Debug(FirstApplication.ApplicationName + "Log", "attribute [" + attrs.GetAttributeName(nAttr) + "]");
            //        buttonDrawable = Resources.GetDrawable(Resource.Drawable.checkbox);
            //    }
            //}
            //else
            
            //FirstLog.Debug(FirstApplication.ApplicationName + "Log", "CheckBox attrs null");

            int[] attrsArray = new int[] { Android.Resource.Attribute.Button  };    // 0
            Android.Content.Res.TypedArray ta = context.ObtainStyledAttributes(attrs, attrsArray);
            int id = ta.GetResourceId(0 /* index of attribute in attrsArray */, View.NoId);
            buttonDrawable = ta.GetDrawable(0);
            //if (buttonDrawable == null)
            //    FirstLog.Warn(FirstApplication.ApplicationName, "buttonDrawable null");

            ////buttonDrawable = this.Background.Current;
            //StateListDrawable stateDrawable = (StateListDrawable)Resources.GetDrawable(Resource.Drawable.checkbox);
            //buttonDrawable = stateDrawable.Current;

            if (buttonDrawable != null)
            {
                try { this.SetButtonDrawable(Android.Resource.Color.Transparent); }
                catch (Exception) { }
            }
        }

        public CheckBoxExtended(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            //FirstLog.Debug(FirstApplication.ApplicationName + "Log", "FirstCheckBox(3)");

            buttonDrawable = Resources.GetDrawable(Resource.Drawable.checkbox);
            //buttonDrawable = this.Background.Current;

            //StateListDrawable stateDrawable = (StateListDrawable)Resources.GetDrawable(Resource.Drawable.checkbox);
            //buttonDrawable = stateDrawable.Current;
            
            try { this.SetButtonDrawable(Android.Resource.Color.Transparent); }
            catch (Exception) { }
        }

        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            try
            {
                base.OnDraw(canvas);
                if (buttonDrawable == null)
                    return;
                //FirstLog.Debug(FirstApplication.ApplicationName + "Log", "FirstCheckBox.OnDraw..");            

                buttonDrawable.SetState(GetDrawableState());

                GravityFlags verticalGravity = Gravity & GravityFlags.CenterVertical;
                GravityFlags horizontalGravity = Gravity & GravityFlags.CenterHorizontal;


                if (buttonDrawable != null)
                {
                    int size = Math.Min(this.Width, this.Height);
                    Drawable currentButtonDrawable = buttonDrawable.Current;
                    if (currentButtonDrawable.IntrinsicWidth != size || currentButtonDrawable.IntrinsicHeight != size)
                    {
                        //FirstLog.Debug(FirstApplication.ApplicationName + "Log", "FirstCheckBox.OnDraw buttonDrawable not null size[" + currentButtonDrawable.IntrinsicWidth + "," + currentButtonDrawable.IntrinsicHeight + "] [" + this.Width + "," + this.Height + "]");
                        currentButtonDrawable = ResizeBitmap(DrawableToBitmap(currentButtonDrawable), size, size);
                    }

                    int height = currentButtonDrawable.IntrinsicHeight;
                    int width = currentButtonDrawable.IntrinsicWidth;
                    int y = 0;

                    //switch (gravi)
                    //{
                    //    case Gravity:
                    //        y = getHeight() - height;
                    //        break;
                    //    case Gravity.CENTER_VERTICAL:
                    y = (this.Height - height) / 2;
                    //        break;
                    //}

                    //int size = Math.Min(this.Width, this.Height);
                    //buttonDrawable = ResizeBitmap(DrawableToBitmap(buttonDrawable.Current), size, size);



                    int buttonWidth = currentButtonDrawable.IntrinsicWidth;
                    int buttonLeft = Width - buttonWidth;

                    currentButtonDrawable.SetBounds(buttonLeft, y, buttonLeft + buttonWidth, y + height);
                    currentButtonDrawable.Draw(canvas);
                }
                //else
                //    FirstLog.Warn(FirstApplication.ApplicationName, "FirstCheckBox.OnDraw buttonDrawable is null");

            }
            catch(Exception ex)
            {
                //FirstLog.Error(FirstApplication.ApplicationName + "Log", "FirstCheckBox.OnDraw: " + ex.Message);
            }
        }

        //protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        //{
        //    base.OnSizeChanged(w, h, oldw, oldh);
        //    mX = w * 0.5f; // remember the center of the screen
        //}

        public Drawable ResizeBitmap(Bitmap bitmapOrg, int desiredWidth, int desiredHeight)
        {
            try
            {
                int width = bitmapOrg.Width;
                int height = bitmapOrg.Height;
                int newWidth = desiredWidth;
                int newHeight = desiredHeight;

                // calculate the scale - in this case = 0.4f
                float scaleWidth = ((float)newWidth) / width;
                float scaleHeight = ((float)newHeight) / height;

                // createa matrix for the manipulation
                Matrix matrix = new Matrix();
                // resize the bit map
                matrix.PostScale(scaleWidth, scaleHeight);
                // rotate the Bitmap
                //matrix.PostRotate(45);

                // re*create the new Bitmap
                Bitmap resizedBitmap = Bitmap.CreateBitmap(bitmapOrg, 0, 0, width, height, matrix, true);

                // make a Drawable from Bitmap to allow to set the BitMap 
                // to the ImageView, ImageButton or what ever

                Drawable bmpDraw = new Android.Graphics.Drawables.BitmapDrawable(resizedBitmap);
                return bmpDraw;
            }
            catch (Exception ex)
            {
                //FirstLog.Error(FirstApplication.ApplicationName + "Log", "ResizeBitmap: " + ex.Message);
                return new Android.Graphics.Drawables.BitmapDrawable(bitmapOrg);
            }
        }

        private Bitmap DrawableToBitmap(Drawable drawable)
        {
            try
            {
                if (drawable is BitmapDrawable)
                    return ((BitmapDrawable)drawable).Bitmap;

                Bitmap bitmap = Bitmap.CreateBitmap(drawable.IntrinsicWidth, drawable.IntrinsicHeight, Bitmap.Config.Argb8888);
                Canvas canvas = new Canvas(bitmap);
                drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
                drawable.Draw(canvas);

                return bitmap;
            }
            catch (Exception ex)
            {
                //FirstLog.Error(FirstApplication.ApplicationName + "Log", "ResizeBitmap: " + ex.Message);
                return null;
            }
        }


    }
}