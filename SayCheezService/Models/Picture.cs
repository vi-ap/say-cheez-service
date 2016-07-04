using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace SayCheezService.Models
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public byte[] Content { get; set; }
        public string SerializedContent { get; set; }
        public byte[] ReducedContent { get; set; }

        public Bitmap getImage()
        {
            MemoryStream stream = new MemoryStream(this.Content);
            Bitmap image = new Bitmap(stream);
            stream.Close();
            return image;
        }

        public void SetPropertiesOnNewUpload()
        {
            if(String.IsNullOrEmpty(this.SerializedContent))
            {
                return;
            }

            this.Content = Convert.FromBase64String(this.SerializedContent);

            Bitmap colourImage = getImage();
            Bitmap greyImage = new Bitmap(colourImage);

            for(int x = 0; x < colourImage.Width; x++)
            {
                for(int y = 0; y < colourImage.Height; y++)
                {
                    Color color = colourImage.GetPixel(x, y);
                    int rgb = (int)(color.R + color.G + color.B) / 3;
                    greyImage.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            }

            this.ReducedContent = (byte[])(new ImageConverter()).ConvertTo(greyImage, typeof(byte[]));
        }
    }
}