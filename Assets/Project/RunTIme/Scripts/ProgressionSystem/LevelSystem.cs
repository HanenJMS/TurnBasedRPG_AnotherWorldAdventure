namespace AnotherWorldProject.ProgressionSystem
{
    public class LevelSystem
    {
        int level;
        int experience;
        int experienceToNextLevel;

        public LevelSystem()
        {
            level = 0;
            experience = 0;
            experienceToNextLevel = 100;
        }


        void AddToExperience(int amount)
        {
            experience += amount;
            if(experience >= experienceToNextLevel)
            {
                level++;
                experience -= experienceToNextLevel;
                experienceToNextLevel *= level;
            }
            
        }
    }
}

