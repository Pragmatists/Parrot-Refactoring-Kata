using System;

namespace ParrotKata
{
    public class Parrot
    {
        private readonly bool isNailed;
        private readonly int numberOfCoconuts;
        private readonly ParrotTypeEnum type;
        private readonly double voltage;


        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            this.type = type;
            this.numberOfCoconuts = numberOfCoconuts;
            this.voltage = voltage;
            this.isNailed = isNailed;
        }

        public double GetSpeed()
        {
            switch (type)
            {
                case ParrotTypeEnum.European:
                    return BaseSpeed;
                case ParrotTypeEnum.African:
                    return Math.Max(0, BaseSpeed - GetLoadFactor()*numberOfCoconuts);
                case ParrotTypeEnum.NorwegianBlue:
                    return isNailed ? 0 : GetBaseSpeed(voltage);
            }
            throw new Exception("Should be unreachable");
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage*BaseSpeed);
        }

        private double GetLoadFactor()
        {
            return 9.0;
        }

        private double BaseSpeed
        {
            get { return 12.0; }
        }
    }
}