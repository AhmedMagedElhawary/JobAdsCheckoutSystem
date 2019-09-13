using System;
using System.Reflection;

namespace JobAdsCheckoutSystemWeb.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvIder
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}