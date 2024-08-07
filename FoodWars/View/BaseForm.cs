﻿using FoodWars.Properties;
using FoodWars.Service;
using FoodWars.Utilities;
using System;
using System.Media;
using System.Windows.Forms;

namespace FoodWars.View
{
    public partial class BaseForm : Form
    {
        #region DataMembers
        private GameService game;
        private GameConfig gameConfig;
        private SoundPlayer bgm;
        private SoundPlayer sfx;
        #endregion

        #region Constructors
        public BaseForm(GameService game, GameConfig gameConfig)
        {
            InitializeComponent();
            this.Game = game;
            this.GameConfig = gameConfig;
            bgm = new SoundPlayer(Resources.RestaurantAudio);
            if (GameConfig.BgmOn) Bgm.PlayLooping();
        }
        #endregion

        #region Properties
        public GameService Game
        {
            get => this.game;
            private set
            {
                if (value == null) throw new NullReferenceException("No service specified!");
                else this.game = value;
            }
        }
        public GameConfig GameConfig
        {
            get => this.gameConfig;
            set
            {
                if (value == null) throw new NullReferenceException("No config found!");
                else this.gameConfig = value;
            }
        }
        public SoundPlayer Bgm
        {
            get => bgm;
            private set => bgm = value;
        }

        private SoundPlayer Sfx
        {
            get => sfx;
            set => sfx = value;
        }
        #endregion

        public void PlaySfx(SoundPlayer audio)
        {
/*            if (GameConfig.SfxOn)
            {
                audio.Play();
            }*/
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            MainMenuUserControl mainMenuUserControl = new MainMenuUserControl(this);
            mainPanel.Controls.Add(mainMenuUserControl);
            mainPanel.Dock = DockStyle.Fill;
        }
    }
}
