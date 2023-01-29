using System;

public interface IConsumble
{
      Action ItemEffect();
      Action neutralizer();
      consumption GetConsumptionType();
}