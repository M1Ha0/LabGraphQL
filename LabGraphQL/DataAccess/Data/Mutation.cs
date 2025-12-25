using LabGraphQL.DataAccess.DAO;
using LabGraphQL.DataAccess.Entity;
using HotChocolate.Subscriptions;

namespace LabGraphQL.DataAccess.Data
{
    public class Mutation
    {
        public async Task<Parent> CreateParent([Service] ParentRepository parentRepository, [Service] ITopicEventSender eventSender, string parentName, string surName, string phone)
        {
            var parent = new Parent { Name = parentName, SurName = surName, Phone = phone };
            var parentDep = await parentRepository.CreateParent(parent);
            await eventSender.SendAsync("CreateParent", parentDep);
            return parentDep;
        }
        public async Task<Child> CreateChild([Service] ChildRepository childRepository, [Service] ITopicEventSender eventSender, string childName, DateOnly birhDate, int parentId)
        {
            Child child = new Child
            {
                Name = childName,
                BirhDate = birhDate,
                ParentId = parentId,
            };
            var createChild = await childRepository.CreateChild(child);
            return createChild;
        }

        public async Task<Child> CreateWithParentName([Service] ChildRepository childRepository, [Service] ITopicEventSender eventSender, string childName, DateOnly birhDate, string parentName)
        {
            Child child = new Child
            {
                Name = childName,
                BirhDate = birhDate,
                Parent = new Parent { Name = parentName }
            };
            var createChild = await childRepository.CreateChild(child);
            return createChild;
        }
        public async Task<Child> EditChild([Service] ChildRepository childRepository, [Service] ITopicEventSender eventSender, string childName, DateOnly birhDate, int parentId)
        {
            Child child = new Child
            {
                Name = childName,
                BirhDate = birhDate,
                ParentId = parentId,
            };
            var editChild = await childRepository.EditChild(child);
            return editChild;
        }
        public async Task<Child> DeleteChild([Service] ChildRepository childRepository, [Service] ITopicEventSender eventSender, int id)
        {
            return await childRepository.DeleteChild(id);
        }
    }
}
