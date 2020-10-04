using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{

  public class Enums
    {
        public enum Result { failed, passed }
        public enum Gender { male, female };
        public enum Vehicle { privateCar, twoWheeledCar, mediumTrack, heavyTrack };
        public enum gearBox { automatic, manual };
       public enum Critirions {keepDistance, reverseParking, parallelParking, mirrorLooking, signaling, giveRightOfWay, stopSign, wearSeatBelt, lights};
        public enum Schools { Tzemed, OrYarok,  Drachim, Shraiber, Auto, smartDrive };

    }
}
