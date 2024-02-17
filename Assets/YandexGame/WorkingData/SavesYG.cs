namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public ulong Money;
        public ulong ClickValue = 1;

        public int NextHeroIndex = 1;

        public int CurrentBoostIndex;
        public ulong[] NumberImprovements = new ulong[10];
    }
}
