using Soccer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soccer.Common.Helpers
{
    public class TransformHelper : ITransformHelper
    {
        public List<Group> TopGroups(List<GroupResponse> groupResponses)
        {
            List<Group> listGroup = new List<Group>();

            foreach (var groupResponse in groupResponses)
            {
                var group = new Group();
                foreach (var groupDetail in groupResponse.GroupDetails.OrderByDescending(gd => gd.Points)
                                                         .ThenByDescending(gd => gd.GoalDifference)
                                                         .ThenByDescending(gd => gd.GoalsFor))
                {
                    group.Add(groupDetail);
                }

                group.Name = groupResponse.Name;
                listGroup.Add(group);

            }
            return listGroup;
        }
    }
}
