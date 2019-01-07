using System.Web;
using System.Web.Optimization;

namespace WebBanHang
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            /////Admin//////
            bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
                          "~/Content/Admin/vendors/bootstrap/dist/css/bootstrap.min.css",
                          "~/Content/Admin/vendors/font-awesome/css/font-awesome.min.css",
                          "~/Content/Admin/vendors/nprogress/nprogress.css",
                          "~/Content/Admin/vendors/iCheck/skins/flat/green.css",
                          "~/Content/Admin/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                          "~/Content/Admin/vendors/jqvmap/dist/jqvmap.min.css",
                          "~/Content/Admin/vendors/bootstrap-daterangepicker/daterangepicker.css",
                          "~/Content/Admin/vendors/build/css/custom.min.css",
                          "~/Content/Plugin/alertifyjs/css/alertify.min.css",
                          "~/Content/Plugin/alertifyjs/css/themes/default.min.css",
                           "~/Content/Plugin/lobibox-master/dist/css/lobibox.min.css",
                          "~/Content/Admin/vendors/build/css/myStyle.css"

                ));

            bundles.Add(new StyleBundle("~/Content/Admin/cssdatepicker").Include(
                "~/Content/Admin/vendors/jqueryui/css/themes/base/jquery.ui.all.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Client/css").Include(
                           "~/Content/Client/css/reset.css",
                           "~/Content/Client/css/bootstrap.css",
                           "~/Content/Client/css/bootstrap-responsive.css",
                           "~/Content/Client/css//flexslider.css",
                           "~/Content/Client/css/andepict.css",
                           "~/Content/Client/css/product-slider.css",
                           "~/Content/Client/css/jquery.selectbox.css",
                           "~/Content/Client/css/nouislider.css",
                           "~/Content/Client/css/fb_style.css",
                           "~/Content/Client/css/isotope.css",
                           "~/Content/Client/css/cloudzoom.css",
                           "~/Content/Client/css/style.css",
                           "~/Content/Client/css/animate.css",
                           "~/Content/Client/rs-plugin/css/settings.css",
                           "~/Content/Client/rs-plugin/css/extralayers-sport.css",
                           "~/Content/Client/css/style-sport.css"

                  ));

            bundles.Add(new ScriptBundle("~/Content/Admin/js").Include(
                         "~/Content/Admin/vendors/jquery/dist/jquery.min.js",
                         "~/Content/Admin/vendors/bootstrap/dist/js/bootstrap.min.js",
                         "~/Content/Admin/vendors/fastclick/lib/fastclick.js",
                         "~/Content/Admin/vendors/nprogress/nprogress.js",
                         "~/Content/Admin/vendors/Chart.js/dist/Chart.min.js",
                         "~/Content/Admin/vendors/gauge.js/dist/gauge.min.js",
                         "~/Content/Admin/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                         "~/Content/Admin/vendors/iCheck/icheck.min.js",
                         "~/Content/Admin/vendors/skycons/skycons.js",
                         "~/Content/Admin/vendors/Flot/jquery.flot.js",
                         "~/Content/Admin/vendors/Flot/jquery.flot.pie.js",
                         "~/Content/Admin/vendors/Flot/jquery.flot.time.js",
                         "~/Content/Admin/vendors/Flot/jquery.flot.stack.js",
                         "~/Content/Admin/vendors/Flot/jquery.flot.resize.js",
                         "~/Content/Admin/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                         "~/Content/Admin/vendors/flot-spline/js/jquery.flot.spline.min.js",
                         "~/Content/Admin/vendors/flot.curvedlines/curvedLines.js",
                         "~/Content/Admin/vendors/DateJS/build/date.js",
                         "~/Content/Admin/vendors/jqvmap/dist/jquery.vmap.js",
                         "~/Content/Admin/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                         "~/Content/Admin/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                         "~/Content/Admin/vendors/moment/min/moment.min.js",
                         "~/Content/Admin/vendors/bootstrap-daterangepicker/daterangepicker.js",
                         "~/Content/Admin/vendors/build/js/custom.min.js",
                         "~/Content/Plugin/alertifyjs/alertify.min.js",
                         "~/Content/Plugin/lobibox-master/dist/js/lobibox.min.js",
                         "~/Content/Plugin/ckfinder/ckfinder.js",
                         "~/Content/Plugin/ckeditor/ckeditor.js",
                         "~/Content/Admin/vendors/build/js/myJS.js"
                         ));
            bundles.Add(new ScriptBundle("~/Content/Admin/datepicker").Include(

                "~/Content/Admin/vendors/jqueryui/js/jquery-ui-1.8.2.custom.js"
            ));


            bundles.Add(new ScriptBundle("~/Content/Client/js").Include(

                    "~/Content/Client/js/jquery-ui.min.js",
                    "~/Content/Client/js/bootstrap.js",
                    "~/Content/Client/js/jquery.easing.js",
                    "~/Content/Client/js/jquery.flexslider.js",
                    "~/Content/Client/js/jquery.elastislide.js",
                    "~/Content/Client/js/jquery.selectbox-0.2.js",
                    "~/Content/Client/js/jquery.nouislider.js",
                    "~/Content/Client/js/jquery.isotope.min.js",
                    "~/Content/Client/js/cloudzoom.js",
                    "~/Content/Client/js/jquery.inview.js",
                    "~/Content/Client/js/jquery.jcarousel.min.js",
                    "~/Content/Client/js/jquery.parallax.js",
                    "~/Content/Client/js/scripts.js",
                    "~/Content/Client/js/doubletaptogo.js",
                    "~/Content/Client/js/navigation.js",
                    "~/Content/Client/rs-plugin/js/jquery.themepunch.plugins.min.js",
                    "~/Content/Client/rs-plugin/js/jquery.themepunch.revolution.min.js"
                ));
        }
    }
}
