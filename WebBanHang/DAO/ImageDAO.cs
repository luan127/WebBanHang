//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebBanHang.Models.EF;
//using System.IO;
//using System.Threading;


//namespace WebBanHang.DAO
//{
//    public class ImageDAO
//    {
//        private ShopMVC5DbContext db = new ShopMVC5DbContext();
//        public void Insert(List<HttpPostedFileBase> listImages, HttpPostedFileBase primaryImage, Product product)
//        {
//            if (listImages != null)
//            {
//                //var entry = db.Entry(movie).Entity;
//                int a = 1;

//                foreach (var i in listImages)
//                {

//                    if (i != null && i.ContentLength > 0)
//                    {

//                        string ImageName = product.Name + "Image" + a.ToString() + ".png";
//                        a++;
//                        i.SaveAs(Path.Combine(Server.MapPath("~/Content/Image/"), ImageName));
//                        var image = new Image { ProductID=product.ID ,Src = "/Content/Image/" + ImageName };

//                        db.Images.Add(image);
//                        db.SaveChanges();

//                    }
//                }
//            }

//        }

//    }

//}