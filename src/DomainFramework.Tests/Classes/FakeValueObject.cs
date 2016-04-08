using System.Collections.Generic;

namespace DomainFramework.Tests.Classes
{
    internal class FakeValueObject : ValueObject<FakeValueObject>
    {
        readonly List<object> _fakeValues;

        public List<object> FakeValues { get { return _fakeValues; } }

        public FakeValueObject(params object[] fakeValues)
        {
            _fakeValues = new List<object>(fakeValues);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            return _fakeValues;
        }
    }
}
