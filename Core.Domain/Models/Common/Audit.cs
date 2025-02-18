
namespace Core.Domain.Models.Common
{
    public class Audit
    {
        public int CreatedBy { get; }
        public DateTime CreatedOn { get; }
        public int ModifiedBy { get; }
        public DateTime ModifiedOn { get; }

        public Audit(int createdBy)
        {
            //TODO: 0 is the CreatedBy/ModifiedBy value in dev often, so we shouldn't use this right now
            //Validate(createdBy);

            CreatedBy = createdBy;
            CreatedOn = DateTime.UtcNow;
        }

        public Audit(int createdBy, DateTime createdOn)
        {
            //TODO: 0 is the CreatedBy/ModifiedBy value in dev often, so we shouldn't use this right now
            //Validate(createdBy);

            CreatedBy = createdBy;
            CreatedOn = createdOn;
        }

        public Audit(int createdBy, DateTime createdOn, int modifiedBy)
        {
            //TODO: 0 is the CreatedBy/ModifiedBy value in dev often, so we shouldn't use this right now
            //Validate(createdBy, modifiedBy);

            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = DateTime.UtcNow;
        }

        public Audit(int createdBy, DateTime createdOn, int modifiedBy, DateTime modifiedOn)
        {
            //TODO: 0 is the CreatedBy/ModifiedBy value in dev often, so we shouldn't use this right now
            //Validate(createdBy, modifiedBy);

            CreatedBy = createdBy;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
            ModifiedOn = modifiedOn;
        }

        private void Validate(int createdBy)
        {
            if (createdBy <= 0)
                throw new ArgumentException("Argument is required.", nameof(createdBy));
        }

        private void Validate(int createdBy, int modifiedBy)
        {
            if (createdBy <= 0)
                throw new ArgumentException("Argument is required.", nameof(createdBy));

            if (modifiedBy <= 0)
                throw new ArgumentException("Argument is required.", nameof(modifiedBy));
        }

        //protected override IEnumerable<object> GetEqualityComponents()
        //{
        //    yield return CreatedBy;
        //    yield return CreatedOn;
        //    yield return ModifiedBy;
        //    yield return ModifiedOn;
        //}
    }
}
