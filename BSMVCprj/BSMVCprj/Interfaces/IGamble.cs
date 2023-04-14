namespace BSMVCprj.Interfaces
{
    public interface IGamble
    {
        int RPSWin(int Id);
        int RPSLoose(int Id);
        int SlotWin(int Id,decimal Win);
        int Slotloose(int Id);
    }
}
