namespace GameStore.Application.UnitTests.CustomAttributes
{
    internal class RecursionOmitAutoDataAttribute : AutoDataAttribute
    {
        public RecursionOmitAutoDataAttribute() 
            : base(() => new Fixture().Customize(new RecursionOmitCustomization())) { }
    }

    internal class RecursionOmitCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
