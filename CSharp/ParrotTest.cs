using System;
using NUnit.Framework;

namespace ParrotKata
{
    public class ParrotTest
    {
        [Test]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = new Parrot(ParrotTypeEnum.European, 0, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_WithOneCoconut()
        {
            var parrot = new Parrot(ParrotTypeEnum.African, 1, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 3.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_WithTwoCoconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.African, 2, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedOfAfricanParrot_WithNoCoconuts()
        {
            var parrot = new Parrot(ParrotTypeEnum.African, 0, 0, false);
            Assert.AreEqual(parrot.GetSpeed(), 12.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_Nailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NorwegianBlue, 0, 0, true);
            Assert.AreEqual(parrot.GetSpeed(), 0.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_NotNailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NorwegianBlue, 0, 1.5, false);
            Assert.AreEqual(parrot.GetSpeed(), 18.0);
        }

        [Test]
        public void GetSpeedNorwegianBlueParrot_NotNailedHighVoltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NorwegianBlue, 0, 4, false);
            Assert.AreEqual(parrot.GetSpeed(), 24.0);
        }
    }

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

    public enum ParrotTypeEnum
    {
        European,
        African,
        NorwegianBlue
    }
}