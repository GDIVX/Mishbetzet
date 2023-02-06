namespace Mishbetzet
{
    public abstract class Command
    {
        public abstract void Execute(params string[] values);
    }
}