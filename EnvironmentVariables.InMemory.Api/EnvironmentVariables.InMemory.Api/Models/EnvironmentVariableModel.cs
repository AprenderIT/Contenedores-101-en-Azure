
using System.Collections.Generic;

namespace EnvironmentVariables.InMemory.Api.Models
{
    public class EnvironmentVariableModel
    {
        public EnvironmentVariableModel(IDictionary<string, string> variables, string search)
        {
            Variables = variables;
            Search = search;
        }

        public IDictionary<string, string> Variables { get; set; }

        public string Search { get; set; }
    }
}
