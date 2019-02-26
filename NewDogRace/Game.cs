using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewDogRace
{
    // extends the class of player to use and the check the player is particiapting or not in the game
   public class Game : Player{
        
        //Object of the Random class 
        Random rnd = new Random();

        //method used to jump dog one to next position
        public int jumpDog1() {
            return rnd.Next(1,39);
        }
        //method used to jump dog two to next position
        public int jumpDog2()
        {
            return rnd.Next(1,40);
        }
        //method used to jump dog third to next position
        public int jumpDog3()
        {
            return rnd.Next(1, 45);
        }



    }
}
