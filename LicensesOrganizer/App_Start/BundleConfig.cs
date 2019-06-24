using System.Web.Optimization;

public class BundleConfig
{
    public static void RegisterBundles(BundleCollection bundles)
    {
        bundles.Add(new ScriptBundle("~/bootstrap").Include(
            "~/Scripts/jquery-3.0.0.js",
            "~/Scripts/bootstrap.js")
        );

        bundles.Add(new StyleBundle("~/styles/bootstrap").Include(
            "~/Content/bootstrap.css",
            "~/Content/bootstrap-grid.css",
            "~/Content/site.css"
        ));
        bundles.Add(new StyleBundle("~/styles/login").Include(
            "~/Content/app/Login.css"
        ));
        bundles.Add(new StyleBundle("~/styles/layout").Include(
            "~/Content/app/layout.css"
    ));

    }
}