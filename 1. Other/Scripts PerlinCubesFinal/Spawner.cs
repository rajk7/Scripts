using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public int Erows;
    public int Ecols;
}
