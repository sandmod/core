namespace Sandmod.Core.Action;

public interface IAction
{
    string Text { get; }

    bool CanExecute();

    bool TryExecute();
}