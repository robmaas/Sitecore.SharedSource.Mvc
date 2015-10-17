namespace Sitecore.SharedSource.Mvc.Controllers
{
    using Sitecore.Mvc.Controllers;
    using Sitecore.Mvc.Presentation;
    using System.Web.Mvc;

    public class AreaControllerRunner : ControllerRunner
    {
        private readonly ControllerInfo controllerInfo;

        public AreaControllerRunner(ControllerInfo controllerInfo) : base(controllerInfo.Controller, controllerInfo.Action)
        {
            this.controllerInfo = controllerInfo;
        }

        protected override IController CreateController()
        {
            var requestContext = PageContext.Current.RequestContext;
            requestContext.RouteData.Values["controller"] = this.controllerInfo.Controller;
            requestContext.RouteData.Values["action"] = this.controllerInfo.Action;

            if (!string.IsNullOrWhiteSpace(this.controllerInfo.Area))
            {
                requestContext.RouteData.DataTokens["area"] = this.controllerInfo.Area;
            }

            if (!string.IsNullOrWhiteSpace(this.controllerInfo.Namespace))
            {
                requestContext.RouteData.DataTokens["namespaces"] = new string[] { this.controllerInfo.Namespace };
            }

            return System.Web.Mvc.ControllerBuilder.Current.GetControllerFactory().CreateController(requestContext, this.controllerInfo.Controller);
        }

        protected override void ReleaseController(Controller controller)
        {
            System.Web.Mvc.ControllerBuilder.Current.GetControllerFactory().ReleaseController(controller);
        }
    }

}