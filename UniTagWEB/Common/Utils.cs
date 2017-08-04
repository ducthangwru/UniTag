using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniTagWEB.Common
{
    public class Utils
    {
        public static Respon ImageFromBase64(string base64)
        {
            if (base64 == null) return null;
            string[] words = base64.Split(',');
            base64 = words.Last();
            string[] exts = words.First().Split(';', '/');
            string extention = "." + exts[1];
            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
            if (!AllowedFileExtensions.Contains(extention)) return null;
            byte[] bytes = Convert.FromBase64String(base64);
            if (bytes.LongLength > 1024 * 1024) return null;
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            Respon res = new Respon(image, extention);
            return res;
        }
        public class Respon
        {
            public Respon(Image image, string extension)
            {
                this.image = image;
                this.extension = extension;
            }
            public Image image { get; set; }
            public string extension { get; set; }
        }
    }
}