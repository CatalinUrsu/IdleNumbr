using System;

namespace IdleNumbers
{
[Serializable]
public struct IdleNumber
{
    public double Value;
    public int Lvl;

    public IdleNumber(int value = 0, int lvl = 0, bool roundNumber = true) : this() => InitNumber(value, lvl, roundNumber);
    public IdleNumber(float value = 0, int lvl = 0, bool roundNumber = true) : this() => InitNumber(value, lvl, roundNumber);
    public IdleNumber(double value = 0, int lvl = 0, bool roundNumber = true) : this() => InitNumber(value, lvl, roundNumber);
    public IdleNumber(IdleNumber targetIdleNumber, bool roundNumber = true) : this() => InitNumber(targetIdleNumber.Value, targetIdleNumber.Lvl, roundNumber);

    void InitNumber(double value, int lvl, bool roundNumber)
    {
        Value = value;
        Lvl = lvl;

        if (!roundNumber) return;
        this.CheckAndRoundIdleNumber();
    }

#region IdleNumber & IdleNumber Operators Override

    public static IdleNumber operator +(IdleNumber idleNumberA, IdleNumber idleNumberB) => Extensions.Addition(idleNumberA, idleNumberB);
    public static IdleNumber operator *(IdleNumber idleNumberA, IdleNumber idleNumberB) => Extensions.Multiply(idleNumberA, idleNumberB);
    public static IdleNumber operator -(IdleNumber idleNumberA, IdleNumber idleNumberB) => Extensions.Subtract(idleNumberA, idleNumberB);
    public static IdleNumber operator /(IdleNumber idleNumberA, IdleNumber idleNumberB) => Extensions.Divide(idleNumberA, idleNumberB);

#endregion

#region IdleNumber & int Operators Override

    public static IdleNumber operator +(IdleNumber idleNumberA, int numberB) => idleNumberA + new IdleNumber(numberB, 0, false);
    public static IdleNumber operator *(IdleNumber idleNumberA, int numberB) => idleNumberA * new IdleNumber(numberB, 0, false);
    public static IdleNumber operator -(IdleNumber idleNumberA, int numberB) => idleNumberA - new IdleNumber(numberB, 0, false);
    public static IdleNumber operator /(IdleNumber idleNumberA, int numberB) => idleNumberA / new IdleNumber(numberB, 0, false);

    public static IdleNumber operator +(int numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) + idleNumberB;
    public static IdleNumber operator *(int numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) * idleNumberB;
    public static IdleNumber operator -(int numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) - idleNumberB;
    public static IdleNumber operator /(int numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) / idleNumberB;

#endregion

#region IdleNumber & float Operators Override

    public static IdleNumber operator +(IdleNumber idleNumberA, float numberB) => idleNumberA + new IdleNumber(numberB, 0, false);
    public static IdleNumber operator *(IdleNumber idleNumberA, float numberB) => idleNumberA * new IdleNumber(numberB, 0, false);
    public static IdleNumber operator -(IdleNumber idleNumberA, float numberB) => idleNumberA - new IdleNumber(numberB, 0, false);
    public static IdleNumber operator /(IdleNumber idleNumberA, float numberB) => idleNumberA / new IdleNumber(numberB, 0, false);

    public static IdleNumber operator +(float numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) + idleNumberB;
    public static IdleNumber operator *(float numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) * idleNumberB;
    public static IdleNumber operator -(float numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) - idleNumberB;
    public static IdleNumber operator /(float numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) / idleNumberB;

#endregion

#region IdleNumber & double Operators Override

    public static IdleNumber operator +(IdleNumber idleNumberA, double numberB) => idleNumberA + new IdleNumber(numberB, 0, false);
    public static IdleNumber operator *(IdleNumber idleNumberA, double numberB) => idleNumberA * new IdleNumber(numberB, 0, false);
    public static IdleNumber operator -(IdleNumber idleNumberA, double numberB) => idleNumberA - new IdleNumber(numberB, 0, false);
    public static IdleNumber operator /(IdleNumber idleNumberA, double numberB) => idleNumberA / new IdleNumber(numberB, 0, false);

    public static IdleNumber operator +(double numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) + idleNumberB;
    public static IdleNumber operator *(double numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) * idleNumberB;
    public static IdleNumber operator -(double numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) - idleNumberB;
    public static IdleNumber operator /(double numberA, IdleNumber idleNumberB) => new IdleNumber(numberA, 0, false) / idleNumberB;

#endregion

}
}