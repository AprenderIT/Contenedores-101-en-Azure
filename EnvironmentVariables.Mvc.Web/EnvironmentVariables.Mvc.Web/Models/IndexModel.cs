using EnvironmentVariables.Mvc.Web.Data;

using System.Collections.Generic;

namespace EnvironmentVariables.Mvc.Web.Models
{
    public class IndexModel
    {
        public IndexModel(IEnumerable<Profile> profiles)
        {
            Profiles = profiles;
        }

        public IEnumerable<Profile> Profiles { get; set; }
    }
}
