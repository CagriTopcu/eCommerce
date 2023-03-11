using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Categories
{
    public class Category : AuditedEntity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Category()
        { 
        }

        public Category(Guid id, string name, string description) 
            : base(id)
        {
            SetName(name);
            SetDescription(description);
        }

        internal Category ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        
        public Category ChangeDescription([NotNull] string description)
        {
            SetDescription(description);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: CategoryConsts.MaxNameLength,
                minLength: CategoryConsts.MinNameLength);
        }

        private void SetDescription([NotNull] string description)
        {
            Description = Check.NotNullOrWhiteSpace(
                description,
                nameof(description),
                maxLength: CategoryConsts.MaxDescriptionLength,
                minLength: CategoryConsts.MinDescriptionLength);
        }
    }
}
