namespace JudoKataTournamentDB
{
    interface IUserControl
    {
        bool Save();
        string Title { get;}
        bool Close();
        bool IsDirty();
        void Activate();
    }
}
