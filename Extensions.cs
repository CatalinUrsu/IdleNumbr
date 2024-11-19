using System;
using UnityEngine;

namespace IdleNumbers
{
public static class Extensions
{
    public static IdleNumber Addition(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value += numberB.RoundToTargetValue(numberA.Lvl);
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    public static IdleNumber Multiply(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value *= numberB.Value;
        numberA.Lvl += numberB.Lvl;
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    public static IdleNumber Subtract(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value -= numberB.RoundToTargetValue(numberA.Lvl);
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }

    public static IdleNumber Divide(IdleNumber numberA, IdleNumber numberB)
    {
        numberA.Value /= numberB.Value;
        numberA.Lvl -= numberB.Lvl;
        numberA.CheckAndRoundIdleNumber();

        return numberA;
    }
    

    /// <summary>
    /// Round number to certain value (M, B, T, AA, AB) if number is too big or too small
    /// </summary>
    public static void CheckAndRoundIdleNumber(this ref IdleNumber idleNumber)
    {
        bool isNegative = idleNumber.Value < 0;

        idleNumber.Value = Math.Abs(idleNumber.Value);

        if (idleNumber.Value >= 1000)
        {
            while (idleNumber.Value >= 1000)
            {
                if (idleNumber.Lvl < ConstantIdleNumber.LVL.Length - 1)
                {
                    idleNumber.Value /= 1000;
                    idleNumber.Lvl++;
                }
                else
                {
                    idleNumber.Value = Math.Clamp(idleNumber.Value, 0, 999);
                    break;
                }
            }
        }
        else if (idleNumber.Value < 1 && idleNumber.Value > 0)
        {
            if (idleNumber.Lvl > 0)
                while (idleNumber.Value < 1)
                {
                    idleNumber.Value *= 1000;
                    idleNumber.Lvl--;
                }
            else
                idleNumber.Reset();
        }
        else if (idleNumber.Value == 0)
        {
            idleNumber.Reset();
        }

        idleNumber.Value = Math.Round(idleNumber.Value, Math.Clamp(3 * idleNumber.Lvl, 0, 15));

        if (isNegative)
            idleNumber.Value *= -1;
    }

    /// <summary>
    /// Check if currency amount is bigger or equal to price
    /// </summary>
    public static bool IsEnough(this IdleNumber currency, IdleNumber price)
    {
        if (currency.Lvl == price.Lvl)
            return currency.Value >= price.Value;

        return currency.Lvl > price.Lvl;
    }

    public static double RoundToTargetValue(this IdleNumber idleNumber, int targetIdleNumberLvl)
    {
        var lvlDiff = idleNumber.Lvl - targetIdleNumberLvl;

        if (lvlDiff != 0)
            idleNumber.Value *= Math.Pow(1000, lvlDiff);

        return targetIdleNumberLvl == 0
            ? idleNumber.Value
            : Math.Round(idleNumber.Value, Math.Clamp(3 * Math.Abs(lvlDiff), 0, 15));
    }

    public static double RoundToTargetValue(this double number, int targetIdleNumberLvl)
    {
        var lvlDiff = (int)Math.Floor(number / 1000) - targetIdleNumberLvl;

        if (lvlDiff != 0)
            number *= Mathf.Pow(1000, lvlDiff);

        return targetIdleNumberLvl == 0
            ? number
            : Math.Round(number, Math.Clamp(3 * Math.Abs(lvlDiff), 0, 15));
    }

    static void Reset(this ref IdleNumber idleNumber)
    {
        idleNumber.Value = 0;
        idleNumber.Lvl = 0;
    }

    public static string AsString(this IdleNumber number) => $"{(number.Value == 0 ? 0 : (Math.Truncate(number.Value * 100) / 100).ToString("###.##"))} {ConstantIdleNumber.LVL[number.Lvl]}";
}
}