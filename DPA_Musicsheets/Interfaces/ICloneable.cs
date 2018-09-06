namespace DPA_Musicsheets.Interfaces
{
    public interface ICloneable<T>
    {
        T ShallowClone();
        T Clone();
    }
}