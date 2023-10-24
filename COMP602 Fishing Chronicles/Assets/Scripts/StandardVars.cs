public class StandardVars
{
    public static StandardVars vars = new StandardVars();
    public float currentXP = 0;
    public int MaxXP = 100;
    public int level = 1;

    public void getXP(float xp)
    {
        currentXP += xp;

        if (currentXP >= MaxXP)
        {
            float Xpdiff = currentXP - MaxXP;
            level++;
            MaxXP = level * 100;
            currentXP = Xpdiff;
        }
        XP.xpAmount = currentXP;
    }

}
