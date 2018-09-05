namespace DPA_Musicsheets.Models
{
    public class Signature
    {
        public int Counter { get; }
        public int CounterSize { get; }

        public Signature(int counter, int counterSize)
        {
            Counter = counter;
            CounterSize = counterSize;
        }
    }
}