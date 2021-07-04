namespace kata.rover.test
{
    public interface ICommand{
        VecteurMovement Execute(EDirection direction);
    }
}