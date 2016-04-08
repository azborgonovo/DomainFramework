namespace DomainFramework.Tests.Classes
{
    public class FakeEntity : Entity<int>
    {
        public string FakeProperty { get; set; }

        public void SetIdentity(int id)
        {
            Id = id;
        }
    }
}