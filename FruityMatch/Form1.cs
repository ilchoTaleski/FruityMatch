using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    [Serializable]
    public partial class Form1 : Form
    {
        
        private Game game;
        private ChoosingCombinations from;
        private SoundPlayer soundplayer { get; set; }
        private bool notInitialized { get; set; }
        private List<User> users;
        private bool fullScreenMode { get; set; }
        private User currentUser;
        private int modeSelected;
        private UniqueIDGenerator uniqueID { get; set; }
        public static int counter = 0;
        public static double ratioX = 1;
        public static double ratioY = 1;
        public static double formWidth = 980;
        public static double formHeight = 700;
        private Dictionary<string, Tuple<int, int>> avatarPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> salfetkiInfoPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> secondPlayerPicturePosition { get; set; }
        private Dictionary<string, Tuple<int, int>> changeUserButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> welcomeLabelPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> startLabelPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> secondPlayerLabelPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> firstPlayerLabelPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> fullScreenButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> startButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> endButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> quitButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> rankingsButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> behind1ButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> behind2ButtonPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> helpPosition { get; set; }
        private Dictionary<string, Tuple<int, int>> controlsPosition { get; set; }
        private GifImage gif { get; set; }
        public static int usersCount = 1;
        public bool switcher;
        public bool hasTicked;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;

            initializeFolders();
            modeSelected = 1;
            this.Icon = Properties.Resources.icon;
            this.Name = "Fruity Match";
            this.Text = "Fruity Match";
            

            gif = new GifImage(Properties.Resources.computer_avatar);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            notInitialized = false;
            this.BackgroundImage = Properties.Resources.interface_bg;
            //this.Width = this.BackgroundImage.Width;
            //this.Height = this.BackgroundImage.Height + 40;
            salfetkiInfo.Visible = false;
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.DoubleBuffered = true;
            uniqueID = loadUniqueID();
           // MessageBox.Show(ratioX + " " + ratioY);
            updateProportions();
            //MessageBox.Show(ratioX + " " + ratioY);
           // MessageBox.Show(this.Width + " " + this.Height);
            //uniqueID = loadUniqueID();

            this.BackgroundImage = Properties.Resources.image_play;
            try
            {
                Stream str = Properties.Resources.feel_it_still;
                soundplayer = new SoundPlayer(str);
             //   soundplayer.Play();
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

            switcher = true;
            hasTicked = false;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Start();
            timer2.Start();

        }

        public void initializeFolders()
        {
            Directory.CreateDirectory(@".\Users");
            Directory.CreateDirectory(@".\UniqueID");
        }

        public void initializePictures()
        {
            avatarPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(avatarPicture.Left, avatarPicture.Top)},
                {"size",  Tuple.Create(avatarPicture.Width, avatarPicture.Height)}
            };

            salfetkiInfoPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(salfetkiInfo.Left, salfetkiInfo.Top)},
                {"size",  Tuple.Create(salfetkiInfo.Width, salfetkiInfo.Height)}
            };

            secondPlayerPicturePosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(secoudPlayerPicture.Left, secoudPlayerPicture.Top)},
                {"size",  Tuple.Create(secoudPlayerPicture.Width, secoudPlayerPicture.Height)}
            };
        }

        public void initializeLabels()
        {
            welcomeLabelPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(welcomeLabel.Left, welcomeLabel.Top)},
                {"size",  Tuple.Create(welcomeLabel.Width, welcomeLabel.Height)}
            };

            startLabelPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(label1.Left, label1.Top)},
                {"size",  Tuple.Create(label1.Width, label1.Height)},
                {"font", Tuple.Create(13,15) }
            };

            secondPlayerLabelPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(secondPlayerName.Left, secondPlayerName.Top)},
                {"size",  Tuple.Create(secondPlayerName.Width, secondPlayerName.Height)}
            };

            firstPlayerLabelPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(player1Name.Left, player1Name.Top)},
                {"size",  Tuple.Create(player1Name.Width, player1Name.Height)}
            };
        }

        public void initializeButtons()
        {
            changeUserButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(changeUserButton.Left, changeUserButton.Top)},
                {"size",  Tuple.Create(changeUserButton.Width, changeUserButton.Height)}
            };

            fullScreenButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(fullScreenButton.Left, fullScreenButton.Top)},
                {"size",  Tuple.Create(fullScreenButton.Width, fullScreenButton.Height)}
            };

            startButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(newButton.Left, newButton.Top)},
                {"size",  Tuple.Create(newButton.Width, newButton.Height)}
            };

            endButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(endButton.Left, endButton.Top)},
                {"size",  Tuple.Create(endButton.Width, endButton.Height)}
            };

            quitButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(quitButton.Left, quitButton.Top)},
                {"size",  Tuple.Create(quitButton.Width, quitButton.Height)}
            };

            rankingsButtonPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(rankingsButton.Left, rankingsButton.Top)},
                {"size",  Tuple.Create(rankingsButton.Width, rankingsButton.Height)}
            };

            helpPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(button1.Left, button1.Top)},
                {"size",  Tuple.Create(button1.Width, button1.Height)}
            };

            controlsPosition = new Dictionary<string, Tuple<int, int>>()
            {
                {"position",  Tuple.Create(button2.Left, button2.Top)},
                {"size",  Tuple.Create(button2.Width, button2.Height)}
            };

        }

        public void initializeItemsPositions()
        {
            initializePictures();
            initializeButtons();
            initializeLabels();
        }

        public void updateItemsPositions()
        {

            
            updatePicture(avatarPicture, avatarPosition);
            updatePicture(salfetkiInfo, salfetkiInfoPosition);
            updatePicture(secoudPlayerPicture, secondPlayerPicturePosition);
            updateButton(changeUserButton, changeUserButtonPosition);
            updateButton(fullScreenButton, fullScreenButtonPosition);
            updateButton(endButton, endButtonPosition);
            updateButton(newButton, startButtonPosition);
            updateButton(quitButton, quitButtonPosition);
            updateButton(rankingsButton, rankingsButtonPosition);
            updateButton(button1, helpPosition);
            updateButton(button2, controlsPosition);
            updateLabel(welcomeLabel, welcomeLabelPosition);
            updateLabel(label1, startLabelPosition);
            updateLabel(secondPlayerName, secondPlayerLabelPosition);
            updateLabel(player1Name, firstPlayerLabelPosition);
            if(fullScreenMode)
            {
                label1.Font = new Font(label1.Font.FontFamily, 19);
            } else
            {
                label1.Font = new Font(label1.Font.FontFamily, 13);
            }



        }

        public void updatePicture(PictureBox item, Dictionary<string, Tuple<int,int>> position)
        {
            item.Left = getRatioX(position["position"].Item1);
            item.Top = getRatioY(position["position"].Item2);
            item.Width = getRatioX(position["size"].Item1);
            item.Height = getRatioY(position["size"].Item2);
        }

        public void updateButton(Button item, Dictionary<string, Tuple<int, int>> position)
        {
            item.Left = getRatioX(position["position"].Item1);
            item.Top = getRatioY(position["position"].Item2);
            item.Width = getRatioX(position["size"].Item1);
            item.Height = getRatioY(position["size"].Item2);
        }

        public void updateLabel(Label item, Dictionary<string, Tuple<int, int>> position)
        {
            item.Left = getRatioX(position["position"].Item1);
            item.Top = getRatioY(position["position"].Item2);
            item.Width = getRatioX(position["size"].Item1);
            item.Height = getRatioY(position["size"].Item2);
        }

        public void switchFullScreen(bool toFull)
        {
            this.fullScreenMode = toFull;
            if(toFull)
            {
                this.BackgroundImageLayout = ImageLayout.Stretch;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                formWidth = this.Width;
                formHeight = this.Height;
                updateProportions();
                updateItemsPositions();
                fullScreenButton.Text = "Exit Full Screen";
            } else
            {
                this.BackgroundImageLayout = ImageLayout.None;
                FormBorderStyle = FormBorderStyle.FixedSingle;
                WindowState = FormWindowState.Normal;
                this.Width = this.BackgroundImage.Width;
                this.Height = this.BackgroundImage.Height;
                formWidth = this.Width;
                formHeight = this.Height;
                updateProportions();
                updateItemsPositions();
                fullScreenButton.Text = "Enter Full Screen";
            }
        }

        public static int getRatioX(int pixels)
        {
            return (int)Math.Round(pixels * Form1.ratioX);
        }

        public static int getRatioY(int pixels)
        {
            return (int)Math.Round(pixels * Form1.ratioY);
        }

        public static void updateProportions()
        {
           
                ratioX = (formWidth * 1.0) / (980 * 1.0);
                ratioY = (1.0 * formHeight) / (700 * 1.0);
            
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
            usersCount = users.Count();
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
            DialogResult style = chooseForm.ShowDialog();
            if (style == DialogResult.OK)
            {
               // MessageBox.Show(this.Width + " " + this.Height);
                ChangeUser userForm = new ChangeUser(users, uniqueID, true);
                if (userForm.ShowDialog() == DialogResult.OK)
                {

                    initializeSecondPlayer(userForm.selectedUser);
                    
                    foreach (User u in users)
                    {
                        SerializeUser(u);
                    }

                    from = new ChoosingCombinations(player1Name.Text, secondPlayerName.Text, false);
                   
                    DialogResult result = from.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        game = new Game(from.player1Comb, from.player2Comb, player1Name.Text, secondPlayerName.Text, false);
                        game.setUsers(currentUser, userForm.selectedUser);
                        fullScreenButton.Visible = false;
                        quitButton.Visible = false;
                        rankingsButton.Visible = false;

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

            } else if(style == DialogResult.Yes)
            {
                User computerPlayer = new User("Grasshopper",-1);
                computerPlayer.changeAvatar(Properties.Resources.computer_avatar_still);
                from = new ChoosingCombinations(player1Name.Text, secondPlayerName.Text, true);
                DialogResult result = from.ShowDialog();
                if (result == DialogResult.OK)
                {
                    initializeSecondPlayer(computerPlayer);
                    game = new Game(from.player1Comb, from.player2Comb, player1Name.Text, secondPlayerName.Text, true);
                    game.setUsers(currentUser, computerPlayer);
                    fullScreenButton.Visible = false;
                    quitButton.Visible = false;
                    rankingsButton.Visible = false;
                    setStartGame();

                }
                else
                {
                    terminateGame();
                }
                
            }


        }

        public void terminateGame()
        {
            if(game != null)
            {
                if (game.firstUser != null && game.secondUser != null)
                {
                    if (!game.player1.isComputer) SerializeUser(game.firstUser);
                    if (!game.player2.isComputer) SerializeUser(game.secondUser);
                }
            }
            
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
            fullScreenButton.Visible = true;
            quitButton.Visible = true;
            rankingsButton.Visible = true;

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
                Fruit fr = game.doc.fruitIfHit(e.X, e.Y);
                placeFruit(fr);
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

                            if(igrac.isComputer)
                            {

                                this.secoudPlayerPicture.Image = Properties.Resources.computer_avatar;
                                

                                
                                napkin = igrac.getCurrentNapkin();
                                List<LittlePlate> lps = igrac.getCurrentPlates();
                                List<Fruit> fruitComb = igrac.autoplay.nextCombination();
                                for(int i=0; i<4; i++)
                                {
                                    fruitComb[i].MoveTo(lps[i].position.X, lps[i].position.Y);
                                    lps[i].fruitOn = fruitComb[i];
                                    Invalidate(true);
                                }

                                

                                s = game.matchingCombination();
                                gameStatus = game.gameStatus();
                                if(gameStatus == "continue")
                                {
                                    nextTurn(napkin, s);
                                }else
                                {
                                    nextTurn(napkin, s);
                                    RevealingCombinations revealForm = new RevealingCombinations(game.player1, game.player2, gameStatus);
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
                        else
                        {
                            nextTurn(napkin, s);
                            RevealingCombinations revealForm = new RevealingCombinations(game.player1, game.player2, gameStatus);
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
            if (game != null)
            {

                /*if (game.player1.turn && hasTicked)
                {
                    hasTicked = false;
                    if (switcher)
                    {
                        this.avatarPicture.BackgroundImageLayout = ImageLayout.Center;
                        this.avatarPicture.BackColor = Color.Red;
                        this.avatarPicture.Padding = new Padding(5, 5, 5, 5);
                        ControlPaint.DrawBorder(e.Graphics, this.avatarPicture.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);

                    }
                    else
                    {
                        this.avatarPicture.BackgroundImageLayout = ImageLayout.Stretch;
                        this.avatarPicture.BackColor = Color.White;
                        this.avatarPicture.Padding = new Padding(0, 0, 0, 0);
                        ControlPaint.DrawBorder(e.Graphics, this.avatarPicture.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
                    }
                }*/

            }
            if (game!= null) game.Draw(e.Graphics);
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            timer1.Start();
            if (game != null)
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

            //Invalidate(true);
            
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

        public void placeFruit(Fruit fr)
        {
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

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Fruit fr = game.doc.fruitIfHit(e.X, e.Y);
            placeFruit(fr);
            
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
                usersCount = users.Count();

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

            initializeItemsPositions();

            switchFullScreen(true);

            //formWidth = this.Width;
            //formHeight = this.Height;
            //updateProportions();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            //MessageBox.Show(this.BackgroundImage.Width + " " + this.BackgroundImage.Height);
            switchFullScreen(!fullScreenMode);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            Rankings rank = new Rankings();
            rank.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (game != null)
            {
                
                if (switcher)
                {
                    switcher = false;
                }
                else
                {
                    switcher = true;
                }
               // Invalidate(true);
            }
        }

        private void avatarPicture_Paint(object sender, PaintEventArgs e)
        {
            if ( game != null)
            {

               
                if (game.player1.turn)
                {
                    PictureBox pb = this.avatarPicture;
                        
                        if (switcher)
                        {
                            ControlPaint.DrawBorder(e.Graphics, pb.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);

                        }
                        else
                        {
                            ControlPaint.DrawBorder(e.Graphics, pb.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
                        }

                    
                }
                
            }
        }

        private void secoudPlayerPicture_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {

                if (game.player2.turn)
                {
                        
                        if (switcher)
                        {


                            ControlPaint.DrawBorder(e.Graphics, this.secoudPlayerPicture.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);

                        }
                        else
                        {
                            ControlPaint.DrawBorder(e.Graphics, this.secoudPlayerPicture.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
                        }

                    
                }

            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void howToPlayTextBox_MouseEnter(object sender, EventArgs e)
        {
  
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            //howToPlayTextBox.Visible = !howToPlayTextBox.Visible;
            //Invalidate(true);
            Help h = new Help();
            h.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ControlsDetails cd = new ControlsDetails();
            cd.ShowDialog();
        }
    }
}
