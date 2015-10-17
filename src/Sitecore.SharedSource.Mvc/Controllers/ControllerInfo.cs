namespace Sitecore.SharedSource.Mvc.Controllers
{
    using System.Linq;

    public class ControllerInfo
    {
        public ControllerInfo(string controllerName, string action, string area)
        {
            this.Action = action;
            if (controllerName.IndexOf(',') > -1)
            {
                this.Controller = controllerName;
            }
            else
            {
                var controllerSegments = controllerName.Split('.');
                if (controllerSegments.Count() > 0)
                {
                    this.Namespace = string.Join(".", controllerSegments.Take(controllerSegments.Count() - 1));
                }

                this.Controller = controllerSegments.Last().Replace("Controller", string.Empty);
                this.Area = area;
            }
        }

        public string Controller { get; private set; }

        public string Action { get; private set; }

        public string Area { get; private set; }

        public string Namespace { get; private set; }
    }
}