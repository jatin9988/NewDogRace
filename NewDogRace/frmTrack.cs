using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDogRace
{
    public partial class frmTrack : Form
    {
        // this is used for moving the position of the Dogs using random
        int dog1 = 0, dog2 = 0, dog3 = 0,move=0;
        
        // pass the predefine value of the players
        int Amount1 = 90,Amount2=100,Amount3=80;
        
        //pass the bet amount to global variable
        int Bet1 = 0,Bet2=0,Bet3=0;

        // pass the no of Player who choose the bet 
        int Plyr1 = 0,Plyr2=0,Plyr3=0;

        // get the Dog No which is used for bet
        int dogNo1 = 0, dogNo2 = 0, dogNo3 = 0;

        private void Player2_Click(object sender, EventArgs e)
        {

        }

        //get the Winner Dog No. to Verify
        int winrDog = 0,ct=0;

        // object of random class
        Random rnd = new Random();
        Game obj = new Game();

        public frmTrack()
        {
            InitializeComponent();
            //get the default position of all the dogs
            dog1 = Dog1.Left;
            dog2 = Dog2.Left;
            dog3 = Dog3.Left;
        }

        public void Fndwinner()
        {
            if (Plyr1==1  && winrDog==dogNo1) {
                // if Player one is winner then incerment the budget of the Palyer one
                Amount1 += Bet1;
                Player1.Text = "Jaspreet has " + Amount1+" Dollar";
            }
            if (Plyr1==1 && winrDog!=dogNo1) {
                // if Player one is Looser then incerment the budget of the Palyer one
                Amount1 -= Bet1;
                Player1.Text = "Jaspreet has " + Amount1 + " Dollar";
            }

            if (Plyr2 == 1 && winrDog == dogNo2)
            {
                // if Player 2nd is winner then incerment the budget of the Palyer one
                Amount2 += Bet2;
                Player2.Text = "Kirat has " + Amount2 + " Dollar";
            }
            if (Plyr2== 1 && winrDog != dogNo2)
            {
                // if Player 2nd is Looser then incerment the budget of the Palyer one
                Amount2 -= Bet2;
                Player2.Text = "Kirat has " + Amount2 + " Dollar";
            }

            if (Plyr3 == 1 && winrDog == dogNo3)
            {
                // if Player 3rd is winner then incerment the budget of the Palyer one
                Amount3 += Bet3;
                Player3.Text = "Sukhman has " + Amount3+ " Dollar";
            }
            if (Plyr3== 1 && winrDog != dogNo3)
            {
                // if Player 3rd is Looser then incerment the budget of the Palyer one
                Amount3 -= Bet3;
                Player3.Text = "Sukhman has " + Amount3 + " Dollar";
            }



        }
        private void tm_Tick(object sender, EventArgs e)
        {
            ct++;
            //timer is used to move the dog from one location to another 
            if (ct>3)
            {
                // this is used to generate the sound effect while running the dog
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("pic/Bark.wav");
                player.Play();

                // till then the dog1 position is greather the finsihing line the position is decrement
                if (Dog1.Left > 0)
                {
                    //genreate the random no to jump
                    move = rnd.Next(1,obj.jumpDog1());
                    //pas the value to dog to move
                    Dog1.Left -= move;
                }
                else
                {
                    //after reaching the finshing line the timer must have to be disable so the game can be over
                    tm.Enabled = false;
                    winrDog = 1;
                    MessageBox.Show("Dog 1 is Winner");
                    //reset the budget of the players
                    Fndwinner();
                    //reset the all game
                    resetRace();
                }

                // till then the dog1 position is greather the finsihing line the position is decrement
                if (Dog2.Left > 0)
                {
                    //genreate the random no to jump
                    move = rnd.Next(1, obj.jumpDog2());
                    //pas the value to dog to move
                    Dog2.Left -= move;
                }
                else
                {
                    //after reaching the finshing line the timer must have to be disable so the game can be over
                    tm.Enabled = false;
                    winrDog = 2;
                    MessageBox.Show("Dog 2 is Winner");
                    //reset the budget of the players
                    Fndwinner();
                    //reset the all game
                    resetRace();
                }
                // till then the dog1 position is greather the finsihing line the position is decrement
                if (Dog3.Left > 0)
                {

                    //genreate the random no to jump
                    move = rnd.Next(1, obj.jumpDog3());
                    //pas the value to dog to move
                    Dog3.Left -= move;
                }
                else
                {
                    //after reaching the finshing line the timer must have to be disable so the game can be over
                    tm.Enabled = false;
                    winrDog = 3;
                    MessageBox.Show("Dog 3 is Winner");
                    //reset the budget of the players
                    Fndwinner();
                    //reset the all game
                    resetRace();
                }
            }
        }
        //reset the whole image using the reset Method
        public void resetRace() {
            cbDog.Text = "";
            cbPlayer.Text = "";
            betAmount.Text = "";
            Player1.Text = "Jaspreet has "+ Amount1 +" Dollar";
            Player2.Text = "Kirat has " + Amount2 + " Dollar";
            Player3.Text = "Sukhman has " + Amount3 + " Dollar";
            Dog1.Left =700;
            Dog2.Left =700;
            Dog3.Left = 700;

        }
        private void Bet_Click(object sender, EventArgs e)
        {
            if (!betAmount.Text.ToString().Equals(""))
            {
                if (betAmount.Text.All(char.IsNumber) && Convert.ToInt32(betAmount.Text.ToString()) > 9 && !cbPlayer.Text.Equals(""))
                {
                    //verify the player 
                    

                    switch (Convert.ToInt32(cbPlayer.SelectedIndex))
                    {
                        case 0:
                            //pass the amount of the bet
                            Bet1 = Convert.ToInt32(betAmount.Text.ToString());
                            //calling the player method to check player is participating or not 
                            Plyr1 = obj.plyr();
                            // pass the value dog No of the bet 
                            dogNo1 =Convert.ToInt32( cbDog.SelectedItem.ToString());

                            Player1.Text = "Jaspreet set $" + Bet1 + "at Dog no " + dogNo1;

                            Run.Enabled = true;
                            break;
                        case 1:
                            //calling the player method to check player is participating or not 
                            Plyr2 = obj.plyr();
                            // pass the value dog No of the bet 
                            dogNo2 = Convert.ToInt32(cbDog.SelectedItem.ToString());
                            //pass the amount of the bet
                            Bet2 = Convert.ToInt32(betAmount.Text.ToString());

                            Player2.Text = "Kirat set $" + Bet2 + "at Dog no " + dogNo2;
                            Run.Enabled = true;
                            break;
                        case 2:
                            //calling the player method to check player is participating or not 
                            Plyr3 = obj.plyr();

                            //pass the amount of the bet
                            Bet3 = Convert.ToInt32(betAmount.Text.ToString());
                            
                            // pass the value dog No of the bet 
                            dogNo3 = Convert.ToInt32(cbDog.SelectedItem.ToString());


                            Player3.Text = "Sukhman set $" + Bet3 + "at Dog no " + dogNo3;

                            Run.Enabled = true;

                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Check all the Details before Setting the Bet");
                }
            }
            else
            {
                MessageBox.Show("Fill the Bet Amount First");
            }
            
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(betAmount.Text.ToString()) > 9)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("pic/sund.wav");
                player.Play();
                tm.Enabled = true;
                Run.Enabled = false;    
            }
            else {
                MessageBox.Show("Bet Amount Must be More then 9 Dollar");
            }
        }
    }
}
