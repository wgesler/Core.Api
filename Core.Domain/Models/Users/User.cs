using Core.Domain.Models.Common;

namespace Core.Domain.Models.Users
{
    public class User
    {
        public Identifier Identifier { get; }
        public string? EmailAddress { get; }
        public byte[]? Hash { get; }
        public byte[]? Salt { get; }
        public bool IsActive { get; }
		public bool IsLocked { get; set; }
		public int FailedLoginAttempts { get; set; }
		public Identifier CompanyIdentifier { get; }
        public Audit Audit { get; }
        public IEnumerable<UserAttribute> UserInfo { get; private set; }

        public User(string emailAddress, byte[] hash, byte[] salt, Identifier companyIdentifier, Audit audit)
        {
            Validate(emailAddress, companyIdentifier.Id);
            ValidatePassword(hash, salt);

            Identifier = new Identifier();
            EmailAddress = emailAddress;
            Hash = hash;
            Salt = salt;
            CompanyIdentifier = companyIdentifier;
            Audit = audit;
            UserInfo = new List<UserAttribute>().AsReadOnly();
        }

        public User(Identifier identifier, byte[] hash, byte[] salt, Audit audit)
        {
            ValidatePassword(hash, salt);

            Identifier = identifier;
            Hash = hash;
            Salt = salt;
            CompanyIdentifier = new Identifier();
            Audit = audit;
            UserInfo = new List<UserAttribute>().AsReadOnly();
        }

        public User(Identifier identifier, string emailAddress, Identifier companyIdentifier, Audit audit)
        {
            Validate(emailAddress, companyIdentifier.Id);

            Identifier = identifier;
            EmailAddress = emailAddress;
            CompanyIdentifier = companyIdentifier;
            Audit = audit;
            UserInfo = new List<UserAttribute>().AsReadOnly();
        }

        public User(Identifier identifier, string emailAddress, byte[] hash, byte[] salt, bool isActive, bool isLocked, int failedLoginAttempts,
			Identifier companyIdentifier, Audit audit)
        {
            Validate(emailAddress, companyIdentifier.Id);
            ValidatePassword(hash, salt);

            Identifier = identifier;
            EmailAddress = emailAddress;
            Hash = hash;
            Salt = salt;
            IsActive = isActive;
			IsLocked = isLocked;
			FailedLoginAttempts = failedLoginAttempts;
            CompanyIdentifier = companyIdentifier;
            Audit = audit;
            UserInfo = new List<UserAttribute>().AsReadOnly();
        }

        public void SetUserInfo(IEnumerable<UserAttribute> userInfo)
        {
            UserInfo = userInfo;
        }

        private static void Validate(string emailAddress, int companyId)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentException("Argument is required.", nameof(emailAddress));
            if (companyId <= 0)
                throw new ArgumentException("Argument is required.", nameof(companyId));
        }

        private static void ValidatePassword(byte[] hash, byte[] salt)
        {
            if (hash == null)
                throw new ArgumentException("Argument is required.", nameof(hash));
            if (salt == null)
                throw new ArgumentException("Argument is required.", nameof(salt));
        }
    }
}
