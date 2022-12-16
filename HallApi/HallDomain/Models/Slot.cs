namespace HallDomain.Models
{
    public class Slot
    {
        public int startSlot { get; set; }
        public int endSlot { get; set; }
        public Slot(int i, int j)
        {
            startSlot = i;
            endSlot = j;
        }
    }
}
