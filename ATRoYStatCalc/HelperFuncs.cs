namespace ATRoYStatCalc
{
    public static class HelperFuncs
    {
        public static int MaxMagicalBonus(this int Base, int Bonus)
        {
            return Bonus > Base / 2 ? Base + (Base / 2) : Base + Bonus;
        }
    }
}
