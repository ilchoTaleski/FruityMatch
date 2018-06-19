﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Game game;
        public ChoosingCombinations from;
        public SoundPlayer soundplayer { get; set; }
        public bool notInitialized { get; set; }
        public List<User> users;
        public User currentUser;
        public UniqueIDGenerator uniqueID { get; set; }
        public static int counter = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            notInitialized = false;
            this.BackgroundImage = Properties.Resources.interface_bg;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height + 40;
            salfetkiInfo.Visible = false;

            this.DoubleBuffered = true;

            uniqueID = loadUniqueID();
           
            //uniqueID = loadUniqueID();

            this.BackgroundImage = Properties.Resources.image_play;
            try
            {
                Stream str = Properties.Resources.feel_it_still;
                soundplayer = new SoundPlayer(str);
                soundplayer.Play();
            }
            catch(Exception e)
            {
                MessageBox.Show("Problem occured with the music. Running without music");
            }
            users = new List<User>();

            if(!checkUsers())
            {
                AddNewUser userForm = new AddNewUser();
                DialogResult result = userForm.ShowDialog();
                if(result == DialogResult.OK)
                {
                    User user = new User(userForm.name, uniqueID.generateUniqueId());
                    serializeID(uniqueID);
                    currentUser = user;
                    user.changeAvatar(userForm.image);
                    user.makeDefaultUser();
                    users.Add(user);
                    SerializeUser(user);
                    changeToNewUser(currentUser);

                }
            }
            else
            {
                loadUsers();
                foreach(User u in users)
                {
                    if (u.isDefault())
                    {
                        currentUser = u;
                        changeToNewUser(currentUser);
                        
                    }
                }
                sortUsers();
            }

            
               
        }

        public static UniqueIDGenerator loadUniqueID()
        {
            
            try
            {
                using (FileStream fStream = new FileStream(@".\UniqueID\idGenerator.fmg", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    UniqueIDGenerator id = (UniqueIDGenerator)formatter.Deserialize(fStream);
                    //users.Add(user);
                    return id;
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Something went wrong with reading the users. Check the location of your .exe file");
                UniqueIDGenerator id = new UniqueIDGenerator();
                serializeID(id);
                return id;
            }
        }


        public void changeToNewUser(User currentUser)
        {
            welcomeLabel.Text = "Welcome " + currentUser.name + "!";
            avatarPicture.Image = currentUser.avatar;
            player1Name.Text = currentUser.name;
        }

        public static void serializeID(UniqueIDGenerator id)
        {
            try
            {
                using (FileStream fStream = new FileStream(@".\UniqueID\idGenerator.fmg", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fStream, id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong with saving the user ID's. Check your .exe file location");
            }
        }

        public void SerializeUser(User user)
        {
            String fileName = @".\Users\user" + user.uniqueID + ".fmu";
            try
            {
                using (FileStream fStream = new FileStream(fileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fStream, user);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool checkUsers()
        {
            try
            {
                String[] files = Directory.GetFiles(@".\Users");
                if (files.Length == 0)
                {
                    return false;
                }
                else
                {
                   
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong with reading the users. Check the location of your .exe file");
                return false;
            }
        }



        public void loadUsers()
        {
            String[] files = Directory.GetFiles(@".\Users");
            foreach (String s in files)
            {
                if (s == "\\Users\\desktop.ini")
                {
                    continue;
                }
                try
                {
                    using (FileStream fStream = new FileStream(s, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        User user = (User)formatter.Deserialize(fStream);
                        users.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong with loading the users. Check the location of your .exe file");
                }
            }
        }
       

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        public void setStartGame() {
            salfetkiInfo.Visible = true;
            this.BackgroundImage = Properties.Resources.interface_bg;
            notInitialized = true;
            this.endButton.Visible = true;
            this.newButton.Visible = true;
            label1.Visible = false;

            player1Name.Visible = true;
            welcomeLabel.Visible = false;
            changeUserButton.Visible = false;
        }
    
        public void initializeGame()
        {

            ChoosePlayingStyle chooseForm = new ChoosePlayingStyle();
            if (chooseForm.ShowDialog() == DialogResult.OK)
            {
                ChangeUser userForm = new ChangeUser(users, uniqueID, true);
                if (userForm.ShowDialog() == DialogResult.OK)
                {

                    initializeSecondPlayer(userForm.selectedUser);
                    
                    foreach (User u in users)
                    {
                        SerializeUser(u);
                    }

                    from = new ChoosingCombinations(player1Name.Text, secondPlayerName.Text);
                   
                    DialogResult result = from.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        game = new Game(from.player1Comb, from.player2Comb, player1Name.Text, secondPlayerName.Text);

                        setStartGame();
                        try
                        {

                            soundplayer = new SoundPlayer(@"C:\Users\User\Desktop\Proekt VP\VP-FruityMatch\FruityMatch\Resources\you-dont-know-me.wav");
                            soundplayer.Play();
                        }
                        catch (Exception e)
                        {
                            //  MessageBox.Show("no music for u");
                        }

                    }
                    else
                    {
                        terminateGame();
                    }

                }

            }

            
        }

        public void terminateGame()
        {
            game = null;
            this.BackgroundImage = Properties.Resources.image_play;
            salfetkiInfo.Visible = false;
            this.endButton.Visible = false;
            this.newButton.Visible = false;
            label1.Visible = true;
            changeUserButton.Visible = true;
            player1Name.Visible = false;
            welcomeLabel.Visible = true;
            secondPlayerName.Visible = false;
            secoudPlayerPicture.Visible = false;
         
        }

        public void removeFromPlate(int x, int y)
        {
            LittlePlate plate = game.getPlate(x, y);
            if (plate != null)
            {
                if (plate.row == game.getActiveRow())
                {
                    plate.fruitOn = null;
                }
            }
        }

        public void nextTurn(Napkin napkin, String s)
        {
            game.incrementActiveRow();
            game.changeTurns();
            napkin.changeNapkin(s);
            Invalidate(true);
        }

        public void initializeSecondPlayer(User user)
        {
            secondPlayerName.Visible = true;
            secoudPlayerPicture.Visible = true;
            secoudPlayerPicture.Image = user.avatar;
            secondPlayerName.Text = user.name;
            Invalidate(true);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if(game == null)
            {
                initializeGame(); 
            }

            if (MouseButtons.Right == e.Button && game != null)
            {
                removeFromPlate(e.X, e.Y);
            }
            if(MouseButtons.Left == e.Button && game != null)
            {
                Napkin napkin = game.getNapkin(e.X, e.Y);
                if (napkin.isCollision(e.X, e.Y))
                {
                    String s = game.matchingCombination();
                    if (s == null)
                    {
                        
                        MessageBox.Show("Must fill all the plates with a fruit");
                    }
                    else
                    {
                        String gameStatus = game.gameStatus();
                        if (gameStatus == "continue")
                        {
                            nextTurn(napkin, s);
                            Player igrac = game.getActivePlayer();
                            if (igrac.isComputer)
                            {
                                napkin = game.getActivePlayer().napkins.napkins[0];
                                igrac.guessFruits();
                                s = game.matchingCombination();

                                nextTurn(napkin, s);
                            }
                        }
                        else
                        {
                            nextTurn(napkin, s);
                            RevealingCombinations revealForm = new RevealingCombinations(game.player1.combination, game.player2.combination, gameStatus);
                            DialogResult result = revealForm.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                initializeGame();
                            }
                            else
                            {
                                terminateGame();
                            }
                            
                        }
                        
                    }
                }
            }

            Invalidate(true);
            
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(game!= null) game.Draw(e.Graphics);
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(game != null)
            {
                if (MouseButtons.Left == e.Button)
                {
                    if (game.selectedFruit == null)
                    {
                        game.selectedFruit = game.doc.fruitIfHit(e.X, e.Y);
                        try
                        {
                            Stream str = Properties.Resources.pop_sound;
                            soundplayer = new SoundPlayer(str);
                            soundplayer.Play();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    if (game.selectedFruit != null)
                        game.selectedFruit.MoveTo(e.X, e.Y);
                }
                
                Napkin napkin = game.getNapkin(e.X, e.Y);
                if (napkin != null)
                {
                   
                    if (napkin.isCollision(e.X, e.Y))
                    {
                        napkin.changeNapkin("hover");
                    }
                    else
                    {
                        napkin.changeNapkin("00");
                    }
                }
            }
            
            Invalidate(true);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
          
            if(game != null)
            {
                if (game.selectedFruit != null)
                {
                    LittlePlate plate = game.getPlate(e.X, e.Y);
                    if (plate != null)
                    {
                        game.selectedFruit.MoveTo(plate.position.X, plate.position.Y);
                        plate.fruitOn = game.selectedFruit;
                        try
                        {
                            Stream str = Properties.Resources.pop_sound;
                            soundplayer = new SoundPlayer(str);
                            soundplayer.Play();
                           
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    FruitCollection fCol = game.doc.getFruitCollection(game.selectedFruit.type);
                    fCol.AddFruitLast();
                    fCol.fruits.Remove(game.selectedFruit);
                }

                game.selectedFruit = null;
            }
            
            Invalidate(true);
   
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Fruit fr = game.doc.fruitIfHit(e.X, e.Y);

            if (fr != null)
            {
                try
                {
                    Stream str = Properties.Resources.pop_sound;
                    soundplayer = new SoundPlayer(str);
                    soundplayer.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                LittlePlate nextPlate = game.getNextActiveLittlePlate();
                game.selectedFruit = fr;
                if (nextPlate != null)
                {
                    fr.MoveTo(nextPlate.position.X, nextPlate.position.Y);
                    nextPlate.fruitOn = fr;
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            terminateGame();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            initializeGame();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //terminateGame();
            initializeGame();
        }

        private void changeUserButton_Click(object sender, EventArgs e)
        {
            ChangeUser changeUserForm = new ChangeUser(users, uniqueID, false);
            DialogResult result = changeUserForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                currentUser.defaultUser = false;
               
                changeUserForm.selectedUser.makeDefaultUser();
                currentUser = changeUserForm.selectedUser;
               
                changeToNewUser(currentUser);
                sortUsers();
                foreach (User u in users)
                {
                    SerializeUser(u);
                }

            }
        }

        public void sortUsers()
        {

            users.Sort((a, b) =>
            {
                if (a.isDefault())
                {
                    return -1;
                }
                if (b.isDefault())
                {
                    return 1;
                }
                else return 0;
            });
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
           // label1.ForeColor = Color.AliceBlue;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.Blue;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.ForeColor = Color.Black;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to leave this game?", "Quit Game",
                MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                foreach (User u in users) {
                    SerializeUser(u);
                }

                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
