using System.Web.Http;
using WebActivatorEx;
using $rootnamespace$;
using Swashbuckle.MVC.Handler;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
[assembly: PreApplicationStartMethod(typeof(SwaggerMVCConfig), "Register")]
namespace $rootnamespace$
{
    public class SwaggerMVCConfig
    {
		public static void Register()
        {
			DynamicModuleUtility.RegisterModule(typeof(SwashbuckleMVCModule));
		}
	}
}