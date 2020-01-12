using ContainerVervoerWinFormFramework.Ships.Containers.Enums;

namespace ContainerVervoerWinFormFramework.Ships.Containers.Interface
{
    public interface IContainer
    {
        int ContentWeight { get;}
        int Weight { get; }
        bool MaxWeight { get; }
        ContainerType Type { get; }
    }
}
