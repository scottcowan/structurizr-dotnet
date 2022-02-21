using CommandLine;

namespace Structurizr.Examples
{
    
    public class Options
    {
	    [Option('w', "workspace", Required = true)]
	    public long WorkspaceId { get; set; }

        [Option('k', "apikey", Required = true)]
	    public string ApiKey { get; set; }

        [Option('s', "secret", Required = true)]
	    public string ApiSecret { get; set; }

        [Option('n', "name", Required = true)]
        public string Name {get; set;}
    }
}