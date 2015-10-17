namespace Sitecore.SharedSource.Mvc.Pipelines.Response.GetRenderer
{
    using Sitecore.Mvc.Pipelines.Response.GetRenderer;
    using Sitecore.Mvc.Presentation;
    using Controllers;
    using Presentation;

    public class GetAreaControllerRendering : GetRendererProcessor
    {
        public override void Process(GetRendererArgs args)
        {
            if (args.Result != null)
            {
                return;
            }

            if (args.RenderingTemplate == null || !args.RenderingTemplate.DescendsFromOrEquals(AppConstants.ControllerRenderingID))
            {
                return;
            }

            args.Result = this.GetRender(args.Rendering, args);
        }

        private Renderer GetRender(Rendering rendering, GetRendererArgs args)
        {
            var controllerInfo = new ControllerInfo(
                rendering.RenderingItem.InnerItem["Controller"],
                rendering.RenderingItem.InnerItem["Controller action"],
                rendering.RenderingItem.InnerItem["Area"]);

            return new AreaControllerRenderer(controllerInfo, new AreaControllerRunner(controllerInfo));
        }
    }
}