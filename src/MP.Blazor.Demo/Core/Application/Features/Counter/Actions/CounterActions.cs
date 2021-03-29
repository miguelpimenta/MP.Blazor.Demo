namespace MP.Blazor.Demo.Core.Application.Features.Counter.Actions
{
    public record IncreaseCounter
    {
        public int Step { get; set; } = 1;
    }

    public record ResetCounter
    {
        public int Step { get; set; } = 0;
    }

    public record DecreaseCounter
    {
        public int Step { get; set; } = 1;
    }
}