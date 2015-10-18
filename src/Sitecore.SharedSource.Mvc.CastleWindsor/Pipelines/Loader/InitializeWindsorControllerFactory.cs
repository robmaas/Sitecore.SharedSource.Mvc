namespace Sitecore.SharedSource.Mvc.CastleWindsor.Pipelines.Loader
{
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    using Sitecore.Mvc.Controllers;
    using Sitecore.Pipelines;
    using System.Web.Mvc;

    public class InitializeWindsorControllerFactory
    {
        public void Process(PipelineArgs args)
        {
            Container.InnerContainer.Install(FromAssembly.This());
            IControllerFactory controllerFactory = new WindsorControllerFactory(Container.InnerContainer.Kernel);
            SitecoreControllerFactory sitecoreControllerFactory = new SitecoreControllerFactory(controllerFactory);
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(sitecoreControllerFactory);
        }
    }

}