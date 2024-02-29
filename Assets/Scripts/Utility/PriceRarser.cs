using System;

public static class PriceRarser
{
    public static double GetParsePrice(int price, float planetPriceCoefficient, float merchantPriceCoefficient)
    {
        return Math.Ceiling(price * planetPriceCoefficient * merchantPriceCoefficient);
    }
}