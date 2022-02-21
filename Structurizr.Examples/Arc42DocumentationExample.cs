using System.IO;
using Structurizr.Api;
using Structurizr.Documentation;
using CommandLine;

namespace Structurizr.Examples
{

    /// <summary>
    /// An empty software architecture document using the arc42 template.
    /// 
    /// See https://structurizr.com/share/27791/documentation for the live version.
    /// </summary>
    public class Arc42DocumentationExample
    {

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
            {
           StructurizrClient structurizrClient = new StructurizrClient(o.ApiKey, o.ApiSecret);
           Workspace workspace = structurizrClient.GetWorkspace(o.WorkspaceId);
           var softwareSystem = workspace.Model.GetSoftwareSystemWithName(o.Name);

           workspace.Documentation.Sections.Clear();

           Arc42DocumentationTemplate template = new Arc42DocumentationTemplate(workspace);

           // this is the Markdown version
           DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "arc42" + Path.DirectorySeparatorChar + "markdown");
           template.AddIntroductionAndGoalsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction-and-goals.md")));
           template.AddConstraintsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "02-architecture-constraints.md")));
           template.AddContextAndScopeSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-scope-and-context.md")));
           template.AddSolutionStrategySection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "04-solution-strategy.md")));
           template.AddBuildingBlockViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "05-building-block-view.md")));
           template.AddRuntimeViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "06-runtime-view.md")));
           template.AddDeploymentViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "07-deployment-view.md")));
           template.AddCrosscuttingConceptsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "08-crosscutting-concepts.md")));
           template.AddArchitecturalDecisionsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "09-architecture-decisions.md")));
           template.AddQualityRequirementsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "10-quality-requirements.md")));
           template.AddRisksAndTechnicalDebtSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "11-risks-and-technical-debt.md")));
           template.AddGlossarySection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "12-glossary.md")));

           // this is the AsciiDoc version
           //            DirectoryInfo documentationRoot = new DirectoryInfo("Documentation" + Path.DirectorySeparatorChar + "arc42" + Path.DirectorySeparatorChar + "asciidoc");
           //            template.AddIntroductionAndGoalsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "01-introduction-and-goals.adoc")));
           //            template.AddConstraintsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "02-architecture-constraints.adoc")));
           //            template.AddContextAndScopeSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "03-system-scope-and-context.adoc")));
           //            template.AddSolutionStrategySection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "04-solution-strategy.adoc")));
           //            template.AddBuildingBlockViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "05-building-block-view.adoc")));
           //            template.AddRuntimeViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "06-runtime-view.adoc")));
           //            template.AddDeploymentViewSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "07-deployment-view.adoc")));
           //            template.AddCrosscuttingConceptsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "08-crosscutting-concepts.adoc")));
           //            template.AddArchitecturalDecisionsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "09-architecture-decisions.adoc")));
           //            template.AddQualityRequirementsSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "10-quality-requirements.adoc")));
           //            template.AddRisksAndTechnicalDebtSection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "11-risks-and-technical-debt.adoc")));
           //            template.AddGlossarySection(softwareSystem, new FileInfo(Path.Combine(documentationRoot.FullName, "12-glossary.adoc")));

           structurizrClient.PutWorkspace(o.WorkspaceId, workspace);
       });
        }

    }

}