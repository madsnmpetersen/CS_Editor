using System.Text.RegularExpressions;

/*
 * Partial class defining the feat editing dialog for the Colony Ship character editor
 * application.  Shows the feats the character has and allows adding/removing them.  The
 * drop down has the regular and heroic feats pre-loaded, any other feat can be added by
 * typing in its asset name (F_xxx) or full object path.
 *
 * ----------------------------------------------------------------------------
 *
 * Author: Mads Petersen
 * Date Written: 2026-10-27
 *
 * ----------------------------------------------------------------------------
 */
namespace CS_Editor
{
    public partial class FeatsDlg : Form
    {
        #region Private Consts
        // asset names (in /Game/Gameplay/Feats/) and game display names of the feats offered in the
        // drop down, regular feats first then heroic (character creation only) feats
        private static readonly string[] KNOWN_FEATS = {
            "F_ArmoredWarfare", "F_ArtfulDodger", "F_Basher", "F_Berserker", "F_BigGameHunter", "F_Bionic",
            "F_Bloodlust", "F_Butcher", "F_Captain", "F_Charger", "F_ControlledBurst", "F_CriticalThinker",
            "F_Educated", "F_FastDraw", "F_Ghost", "F_Gladiator", "F_Gunfighter", "F_LotsOfGuns",
            "F_HeavyHitter", "F_LoneWolf", "F_MasterBlaster", "F_MasterTrader", "F_Opportunist",
            "F_PersonalMagnetism", "F_Pistolero", "F_PreciseStrike", "F_Prowler", "F_QuickFingers",
            "F_Rifleman", "F_Sarge", "F_SecondWind", "F_Sharpshooter", "F_TooClose", "F_SkillMonkey",
            "F_SlowMetabolism", "F_Gunner", "F_ThroatSlitter", "F_ToughBastard", "F_TrueGrit",
            "F_TunnelRunner", "F_Warrior",
            "F_H_CultLeader", "F_H_DodgeThis", "F_H_FastRunner", "F_Gifted", "F_H_HealingFactor",
            "F_H_Juggernaut", "F_H_Mastermind" };
        private static readonly string[] KNOWN_NAMES = {
            "Armored Warfare", "Artful Dodger", "Basher", "Berserker", "Big Game Hunter", "Bionic",
            "Bloodlust", "Butcher", "Captain", "Charger", "Controlled Burst", "Critical Thinker", "Educated",
            "Fast Draw", "Ghost", "Gladiator", "Gunfighter", "Guns, Lots of Guns", "Heavy Hitter",
            "Lone Wolf", "Master Blaster", "Master Trader", "Opportunist", "Personal Magnetism", "Pistolero",
            "Precise Strike", "Prowler", "Quick Fingers", "Rifleman", "Sarge", "Second Wind", "Sharpshooter",
            "Shotgunner", "Skill Monkey", "Slow Metabolism", "Sprayer", "Throat Slitter", "Tough Bastard",
            "True Grit", "Tunnel Runner", "Warrior",
            "Cult Leader (heroic)", "Dodge This! (heroic)", "Fast Runner (heroic)", "Gifted (heroic)",
            "Healing Factor (heroic)", "Juggernaut (heroic)", "Mastermind (heroic)" };
        // display names of special feats (companion, quest, etc.) not offered in the drop down
        private static readonly Dictionary<string, string> OTHER_NAMES = new Dictionary<string, string> {
            { "F_C_Cobra", "Spec Ops" },
            { "F_C_Evans_Defender", "Sniper" },
            { "F_C_Evans_Desperado", "Desperado" },
            { "F_C_Faythe_Assassin_1", "Assassin" },
            { "F_C_Faythe_Thief_1", "Thief" },
            { "F_C_Garret", "Enforcer" },
            { "F_C_Harbinger", "The Third Daughter" },
            { "F_C_Jed", "Punisher" },
            { "F_C_Knurl", "Outcast" },
            { "F_C_Mathias", "Unwavering Faith" },
            { "F_C_Zeta", "Special Envoy" },
            { "F_F_Regulator", "Regulator" },
            { "F_G_C_Creeper_1", "Creeper Hunter" },
            { "F_G_C_Frog_1", "Frog Hunter" },
            { "F_G_C_Robot", "Machine Hunter" },
            { "F_G_Mutant", "Mutant" } };
        #endregion

        #region Properties
        private List<string> _feats = new List<string>();
        public List<string> Feats { get { return _feats; } set { _feats = new List<string>(value); } }

        private bool _featsChanged = false;
        public bool FeatsChanged { get { return _featsChanged; } }
        #endregion

        // --------------------------------------------------------------------

        #region Constructor
        public FeatsDlg()
        {
            InitializeComponent();
        }
        #endregion

        // --------------------------------------------------------------------

        #region Private Methods
        // F_H_CultLeader -> 'Cult Leader (heroic) [F_H_CultLeader]'
        private static string DisplayName(string assetName)
        {
            int idx = Array.IndexOf(KNOWN_FEATS, assetName);
            string name;

            if (idx >= 0)
                name = KNOWN_NAMES[idx];
            else if (OTHER_NAMES.ContainsKey(assetName))
                name = OTHER_NAMES[assetName];
            else // unknown, make something readable out of asset name
                name = Regex.Replace(assetName.Substring(2).Replace('_', ' '), "(?<=[a-z])(?=[A-Z])", " ");

            return name + " [" + assetName + "]";
        }

        private void LoadFeatList()
        {
            lbFeats.Items.Clear();
            foreach (string feat in _feats) lbFeats.Items.Add(DisplayName(SaveFeats.FeatAssetName(feat)));
        }

        private string? SelectedFeatPath()
        {
            string text = cbAddFeat.Text.Trim();

            if (cbAddFeat.SelectedIndex >= 0) return SaveFeats.FeatPath(KNOWN_FEATS[cbAddFeat.SelectedIndex]);
            if (text.StartsWith("/Game/")) return text;
            if (Regex.IsMatch(text, "^F_[A-Za-z0-9_]+$")) return SaveFeats.FeatPath(text);

            return null;
        }
        #endregion

        // --------------------------------------------------------------------

        #region Event Handlers
        private void FeatsDlg_Load(object sender, EventArgs e)
        {
            foreach (string feat in KNOWN_FEATS) cbAddFeat.Items.Add(DisplayName(feat));
            LoadFeatList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string? feat = SelectedFeatPath();

            if (feat == null)
            {
                MessageBox.Show("Select a feat, or type in a feat asset name (F_xxx).", this.Text, MessageBoxButtons.OK);
            }
            else if (_feats.Contains(feat))
            {
                MessageBox.Show("Character already has that feat.", this.Text, MessageBoxButtons.OK);
            }
            else
            {
                _feats.Add(feat);
                _featsChanged = true;
                LoadFeatList();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int idx = lbFeats.SelectedIndex;

            if (idx >= 0)
            {
                _feats.RemoveAt(idx);
                _featsChanged = true;
                LoadFeatList();
                if (lbFeats.Items.Count > 0) lbFeats.SelectedIndex = Math.Min(idx, lbFeats.Items.Count - 1);
            }
        }
        #endregion
    }
}
