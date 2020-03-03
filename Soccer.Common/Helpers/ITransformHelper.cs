using Soccer.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soccer.Common.Helpers
{
    public interface ITransformHelper
    {
        List<Group> TopGroups(List<GroupResponse> groupResponses);
    }
}
