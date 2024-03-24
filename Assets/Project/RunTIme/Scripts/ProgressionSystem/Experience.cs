namespace AnotherWorldProject.ProgressionSystem
{
    [System.Serializable]
    public class Experience
    {
        int currentExp = 0;

        void AddExp(int exp)
        {
            currentExp += exp;
        }

        object SavingSystem_Save()
        {
            return currentExp;
        }
        void SavingSystem_Load(object exp)
        {
            currentExp = (int)exp;
        }
    }
}

