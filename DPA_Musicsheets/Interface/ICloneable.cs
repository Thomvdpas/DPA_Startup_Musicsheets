namespace DPA_Musicsheets.Interface
{
    public interface ICloneable<T>
    {
        T ShallowClone();
        T Clone();
    }
}