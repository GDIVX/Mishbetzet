namespace Mishbetzet
{
    public abstract class Command
    {
        public abstract void Execute(params string[] values);
    }
    public class Print : Command
    {
        public override void Execute(params string[] values)
        {
            foreach (var item in values) { Console.WriteLine(item); }
        }
    }
}