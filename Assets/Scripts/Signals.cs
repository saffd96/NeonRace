public readonly struct InputSignal
{
    public readonly PlayerInput CurrentInput;
    public readonly float Percentage;

    public InputSignal(PlayerInput input, float percentage)
    {
        CurrentInput = input;
        Percentage = percentage;
    }
}