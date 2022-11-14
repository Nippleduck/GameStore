using AutoFixture;
using AutoFixture.Xunit2;

namespace GameStore.Application.UnitTests.CustomAttributes
{
    internal class RecursionAllowedAutoDataAttribute : AutoDataAttribute
    {
        public RecursionAllowedAutoDataAttribute() 
            : base(() => new Fixture().Customize(new RecursionAllowedCustomization())) { }
    }

    internal class RecursionAllowedCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
