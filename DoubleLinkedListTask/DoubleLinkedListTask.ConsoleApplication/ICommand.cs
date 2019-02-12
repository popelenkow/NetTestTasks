

namespace DoubleLinkedListTask.ConsoleApplication
{
    public interface ICommand
    {
        void Execute(object parameter);

        string GetDescription();
    }

    public interface ICommand<T> : ICommand
    {
        void Execute(T parameter);
    }

    public abstract class Command<T> : ICommand<T>
    {
        public abstract void Execute(T parameter);

        void ICommand.Execute(object parameter)
        {
            Execute((T)parameter);
        }

        public abstract string GetDescription();
    }
}
