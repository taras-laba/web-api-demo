using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi.Common.Models;

namespace WebApi.Common.Extensions
{
    public class ImageFormatter : BufferedMediaTypeFormatter
    {
        public ImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("image/png"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof (ProcessModel) == type;
        }

        public override void WriteToStream(Type type, object value, System.IO.Stream writeStream, System.Net.Http.HttpContent content)
        {   
 	        var model = value as ProcessModel;
            if (model != null && model.Icon != null)
            {
                Bitmap bmp = model.Icon.ToBitmap();
                bmp.Save(writeStream, ImageFormat.Png);
            }
        }
    }
}
