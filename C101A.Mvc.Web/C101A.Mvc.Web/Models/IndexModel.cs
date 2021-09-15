using C101A.Mvc.Web.Data;

using System.Collections.Generic;

namespace C101A.Mvc.Web.Models
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
