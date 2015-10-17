namespace Sitecore.SharedSource.Mvc.Presentation
{
    using Sitecore.Mvc.Presentation;
    using Controllers;
    using System.IO;

    public class AreaControllerRenderer : Renderer
    {
        private readonly ControllerInfo controllerInfo;
        private readonly AreaControllerRunner controllerRunner;

        public AreaControllerRenderer(ControllerInfo controllerInfo, AreaControllerRunner controllerRunner)
        {
            this.controllerInfo = controllerInfo;
            this.controllerRunner = controllerRunner;
        }

        public override void Render(TextWriter writer)
        {
            var output = this.controllerRunner.Execute();
            if (string.IsNullOrWhiteSpace(output))
            {
                return;
            }

            writer.Write(output);
        }

        public override string CacheKey
        {
            get
            {
                return string.Join("::", new string[] { controllerInfo.Area, controllerInfo.Controller, controllerInfo.Action });
            }
        }

        public override string ToString()
        {
            return string.Format("Area: {0}, Controller: {1}, Area:{2}", new string[] {
                controllerInfo.Area,
                controllerInfo.Controller,
                controllerInfo.Action });
        }
    }
}