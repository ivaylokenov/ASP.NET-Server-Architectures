namespace Blog.Application.Ports
{
    using System.Threading.Tasks;

    public interface IInputPort<in TInput, out TOutput>
    {
        Task Handle(TInput input, IOutputPort<TOutput> output);
    }
}
