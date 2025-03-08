using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.UI.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public class UpgradeView : ControlManager
    {

        public bool isShowing = false;
        static Button damageUpgrade,attackSpeedUpgrade,slowingButton,rangeButton;
        static int maxDamageUpgrade = 3, maxAttackSpeed = 3, maxSlowing = 3, maxRange = 3;
        static int costDamageUpgrade = 400, costAttackSpeed = 400, costSlowing = 800, costRange = 800;
        static Tower currentTower = null;
        static FilledRectangle backGround;
        static TextArea text, damageText,speedText,slowingText, rangeText;

        public UpgradeView(Game game) : base(game) 
        {
            
        }

        public override void InitializeComponent()
        {
            damageUpgrade = new Button()
            {
                Text = "Upgrade Damage",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1000, 200),
                BackgroundColor = Color.White
            };
            attackSpeedUpgrade = new Button()
            {
                Text = "Upgrade AttackSpeed",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1000, 300),
                BackgroundColor = Color.White
            };
            slowingButton = new Button()
            {
                Text = "Upgrade Slowing",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1000, 400),
                BackgroundColor = Color.White
            };
            rangeButton = new Button()
            {
                Text = "Upgrade Range",
                TextColor= Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1000, 500),
                BackgroundColor = Color.White
            };
            backGround = new FilledRectangle(975,150,250,450)
            {
                BackgroundColor = Color.DarkGray
            };
            text = new TextArea()
            {
                Text = "Tower Upgrades",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1040, 160),
            };
            damageText = new TextArea()
            {
                Text = "Damage Upgrades",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1040, 260),
            };
            speedText = new TextArea()
            {
                Text = "Speed Upgrades",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1040, 360),
            };
            slowingText = new TextArea()
            {
                Text = "Slowing Upgrades",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1040, 460),
            };
            rangeText = new TextArea()
            {
                Text = "Range Upgrades",
                TextColor = Color.Black,
                Size = new Vector2(200, 50),
                Location = new Vector2(1040, 560),
            };

            Controls.Add(backGround);
            backGround.IsVisible = false;

            Controls.Add(text);
            Controls.Add(damageText);
            Controls.Add(speedText);
            Controls.Add(slowingText);
            Controls.Add(rangeText);
            text.IsVisible = false;
            damageText.IsVisible = false;
            speedText.IsVisible = false;
            slowingText.IsVisible = false;
            rangeText.IsVisible = false;

            damageUpgrade.Clicked += DamageUpgrade_Clicked;
            Controls.Add(damageUpgrade);
            damageUpgrade.IsVisible= false;

            attackSpeedUpgrade.Clicked += AttackSpeedUpgrade_Clicked;
            Controls.Add(attackSpeedUpgrade);
            attackSpeedUpgrade.IsVisible= false;

            slowingButton.Clicked += SlowingUpgrade_Clicked;
            Controls.Add(slowingButton);
            slowingButton.IsVisible = false;

            rangeButton.Clicked += RangeUpgrade_Clicked;
            Controls.Add(rangeButton);
            rangeButton.IsVisible = false;

        }

        

        public static void ShowTowerInformation(Tower tower)
        {
            damageUpgrade.IsVisible = true;
            attackSpeedUpgrade.IsVisible = true;
            slowingButton.IsVisible = true;
            rangeButton.IsVisible = true;
            backGround.IsVisible = true;
            text.IsVisible = true;
            damageText.IsVisible = true;
            speedText.IsVisible = true;
            slowingText.IsVisible = true;
            rangeText.IsVisible = true;


            damageText.Text = "" + tower.damageUpgrade.ToString() + " / " + maxDamageUpgrade + "  Cost: " + costDamageUpgrade;
            speedText.Text = "" + tower.attackSpeedUpgrade.ToString() + " / " + maxAttackSpeed + "  Cost: " + costAttackSpeed;
            slowingText.Text = "" + tower.SlowingUpgrade.ToString() + " / " + maxSlowing + "  Cost: " + costSlowing;
            rangeText.Text = "" + tower.rangeUpgrade.ToString() + " / " + maxRange + "  Cost: " + costRange;
            currentTower = tower;
        }

        public static void HideTowerInformation()
        {
            damageUpgrade.IsVisible = false;
            attackSpeedUpgrade.IsVisible = false;
            slowingButton.IsVisible = false;
            rangeButton.IsVisible = false;
            backGround.IsVisible = false;
            text.IsVisible = false;
            damageText.IsVisible = false;
            speedText.IsVisible = false;
            slowingText.IsVisible = false;
            rangeText.IsVisible = false;
            currentTower = null;
        }


        void DamageUpgrade_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentTower != null)
            {
                if (costDamageUpgrade <= GamemodeManager.resources)
                {
                    if (currentTower.damageUpgrade < maxDamageUpgrade)
                    {
                        currentTower.damageUpgrade++;
                        GamemodeManager.resources -= costDamageUpgrade;
                        damageText.Text = "" + currentTower.damageUpgrade.ToString() + " / " + maxDamageUpgrade + "  Cost: " + costDamageUpgrade;
                    }
                }     

            }
        }

        void AttackSpeedUpgrade_Clicked(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (currentTower != null)
            {
                if (costAttackSpeed <= GamemodeManager.resources)
                {
                    if (currentTower.attackSpeedUpgrade < maxAttackSpeed)
                    {
                        currentTower.attackSpeedUpgrade++;
                        currentTower.attackSpeed -= 100;
                        GamemodeManager.resources -= costAttackSpeed;
                        speedText.Text = "" + currentTower.attackSpeedUpgrade.ToString() + " / " + maxAttackSpeed + "  Cost: " + costAttackSpeed;
                    }
                }

            }
        }

        void SlowingUpgrade_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentTower != null)
            {
                if (costSlowing <= GamemodeManager.resources)
                {
                    if (currentTower.SlowingUpgrade < maxDamageUpgrade)
                    {
                        currentTower.SlowingUpgrade++;
                        GamemodeManager.resources -= costSlowing;
                        slowingText.Text = "" + currentTower.SlowingUpgrade.ToString() + " / " + maxSlowing + "  Cost: " + costSlowing;
                    }
                }

            }
        }

        void RangeUpgrade_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (currentTower != null)
            {
                if (costRange <= GamemodeManager.resources)
                {
                    if (currentTower.rangeUpgrade < maxRange)
                    {
                        currentTower.rangeUpgrade++;
                        currentTower.range += 10;
                        currentTower.UpdateRangeIndicator();
                        GamemodeManager.resources -= costRange;
                        rangeText.Text = "" + currentTower.rangeUpgrade.ToString() + " / " + maxRange + "  Cost: " + costRange; ;
                    }
                }
            }
            
        }
    }
}
